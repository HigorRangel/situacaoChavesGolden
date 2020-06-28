using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace situacaoChavesGolden
{
    public partial class ConfigurarRelatorioChaves : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();
        string funcionario = "";
        public ConfigurarRelatorioChaves(string user)
        {
            InitializeComponent();
            funcionario = user;
        }

        private void ConfigurarRelatorioChaves_Load(object sender, EventArgs e)
        {

            try
            {
                dpMinDataCadastro.Value = DateTime.Parse(database.selectScalar("SELECT MIN(data_cadastro) FROM chave"));

            }
            catch
            {
                dpMinDataCadastro.Value = DateTime.Now.AddDays(-32);
            }
            dpMaxDataCadastro.Value = DateTime.Now;
            dpMaxDataCadastro.MaxDate = DateTime.Now;

            funcionario = database.selectScalar(string.Format("SELECT nome_usuario FROM usuario WHERE cod_usuario = '{0}'", funcionario));

            gridProp.Columns.Add("codigo", "Cód.");
            gridProp.Columns.Add("nome", "Nome do Proprietário");



            DataGridViewImageColumn cellImage = new DataGridViewImageColumn();
            cellImage.Image = new Bitmap(Properties.Resources.Delete);

            gridProp.Columns.Insert(2, cellImage);




            gridProp.Columns[0].Width = 40;
            gridProp.Columns[1].Width = 277;
            gridProp.Columns[2].Width = 30;


        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string sitImovel = groupBoxSituacaoIm.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string sitChave = groupBoxSituacaoCh.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string tipoImovel = groupBoxTipoImovel.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string finalidade = groupBoxFinalidade.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string ordenar = groupBoxOrdenar.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string ordem = groupOrdem.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();

            string funcionario = this.funcionario;

            if (sitImovel == "TODOS") { sitImovel = ""; }
            if (sitChave == "TODOS") { sitChave = ""; }
            if (tipoImovel == "TODOS") { tipoImovel = ""; }
            if (finalidade == "TODOS") { finalidade = ""; }
            if (ordenar == "COD CHAVE")
            {
                ordenar = "c.cod_chave";
            }
            else if (ordenar == "RUA")
            {
                ordenar = "c.rua";
            }
            else if (ordenar == "COD IMOB")
            {
                ordenar = "c.cod_imob";
            }
            else
            {
                ordenar = "c.data_cadastro";    
            }

            if(ordem == "CRESCENTE")
            {
                ordem = "ASC";
            }
            else
            {
                ordem = "DESC";
            }

            GerarRelatorio relatorio = new GerarRelatorio();


            relatorio.sitImovel = sitImovel;
            relatorio.sitChave = sitChave;
            relatorio.tipo = tipoImovel;
            relatorio.finalidade = finalidade;
            relatorio.ordenar = ordenar;
            relatorio.funcionario = funcionario;
            List<string> listaProp = new List<string>();
            relatorio.selecData = checkDataCadastro.Checked;
            relatorio.dataFrom = dpMinDataCadastro.Value;
            relatorio.dataTo = dpMaxDataCadastro.Value;
            relatorio.ordem = ordem;

            if (!checkProp.Checked)
            {
                foreach(DataGridViewRow row in gridProp.Rows)
                {
                    listaProp.Add(row.Cells[0].Value.ToString());
                }
            }
            relatorio.listProp = listaProp;

            relatorio.chaves();

            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void atualizarGridProp()
        {
            string codigosEscolhidos = "";
            int cont = 0;
            foreach(DataGridViewRow row in gridProp.Rows)
            {
                if(cont == 0)
                {
                    codigosEscolhidos += "  AND  ";
                }
                codigosEscolhidos += string.Format(" cod_proprietario != {0}", row.Cells[0].Value.ToString());

                if (cont != gridProp.Rows.Count - 1)
                {
                    codigosEscolhidos += " AND ";

                }

                cont++;
            }
            DataTable dadosProp = new DataTable();

            dadosProp = database.select(string.Format("SELECT cod_proprietario, nome" +
                                                        " FROM proprietario" +
                                                        " WHERE (cod_proprietario::text ILIKE '%{0}%' OR " +
                                                        " nome ILIKE '%{0}%' OR  (unaccent(lower(nome))) ILIKE '%{0}%') " +
                                                        "  {1} ORDER BY nome", boxBusca.Text, codigosEscolhidos));

            gridPropTotal.DataSource = dadosProp;

            gridPropTotal.Columns[0].HeaderText = "Cód";
            gridPropTotal.Columns[1].HeaderText = "Nome do proprietário";

            gridPropTotal.Columns[0].Width = 40;
            gridPropTotal.Columns[1].Width = 319;

        }

        private void BtnBaixa_Click(object sender, EventArgs e)
        {
            panelChaves.Visible = true;
            atualizarGridProp();
        }

        private void CheckProp_CheckedChanged(object sender, EventArgs e)
        {
            if (checkProp.Checked)
            {
                gridProp.Enabled = false;
                btnAddProp.Enabled = false;
                btnAddProp.Cursor = Cursors.Arrow;
                btnAddProp.Image = Properties.Resources.AdicionarGray;
            }
            else
            {
                gridProp.Enabled = true;
                btnAddProp.Enabled = true;
                btnAddProp.Cursor = Cursors.Hand;
                btnAddProp.Image = Properties.Resources.Adicionar1;
            }
        }

        private void BtnCancelarChave_Click(object sender, EventArgs e)
        {
            panelChaves.Visible = false;

        }

        private void BtnConfirmChave_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in gridPropTotal.SelectedRows)
            {
                gridProp.Rows.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
            }

            panelChaves.Visible = false;

        }

        private void BoxBusca_TextChanged(object sender, EventArgs e)
        {
            atualizarGridProp();
        }

        private void GridProp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 2)
            {
                gridProp.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void GridProp_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                gridProp.Cursor = Cursors.Hand;
            }
            else
            {
                gridProp.Cursor = Cursors.Arrow;
            }
        }

        private void CheckDataRetirada_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDataCadastro.Checked)
            {
                dpMinDataCadastro.Enabled = true;
                dpMaxDataCadastro.Enabled = true;
            }
            else
            {
                dpMinDataCadastro.Enabled = false;
                dpMaxDataCadastro.Enabled = false;
            }

        }
    }
}
