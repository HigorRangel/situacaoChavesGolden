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
    public partial class Retirados : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();
        public Retirados()
        {
            InitializeComponent();
        }

        private void atualizarGrid()
        {
            string tipoImovel = groupMenuSup.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string situacaoQuemRetirou = groupBoxQuemRetirou.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            if (situacaoQuemRetirou == "TODOS") { situacaoQuemRetirou = ""; }
            if (tipoImovel == "TODOS") { tipoImovel = ""; }



            string dataRetirada = string.Format("data_Retirada BETWEEN '{0}' AND '{1}' AND ", dpMinDataRetirada.Value, dpMaxDataRetirada.Value);

            if (!checkDataRetirada.Checked) { dataRetirada = ""; }

            string busca = textBoxBusca.Text;
            if (busca == "Buscar") { busca = ""; }
            if(tipoImovel == "TODOS") { tipoImovel = ""; }




            DataTable tabela = new DataTable();

            tabela = database.select(string.Format("SELECT r.cod_retirado, c.cod_imob, c.rua || ', ' || c.numero || ' - ' || c.bairro as endereco,  " +
                                                    " data_retirada " +
                                                    " FROM retirado r " +
                                                    " INNER JOIN chave c ON c.indice_chave = r.cod_chave " +
                                                    " WHERE ({0} c.finalidade ILIKE '%{1}%' AND r.tipo_retirada ILIKE '%{2}%') " +
                                                            " AND (c.cod_chave::text ILIKE '%{3}%' OR c.rua ILIKE '%{3}%' OR c.bairro  ILIKE '%{3}%' OR " +
                                                                " r.quem_retirou  ILIKE '%{3}%' OR r.descricao  ILIKE '%{3}%' OR c.cod_imob  ILIKE '%{3}%')",
                                                                dataRetirada, tipoImovel, situacaoQuemRetirou, busca));

            gridRetirados.DataSource = tabela.DefaultView;

            gridRetirados.Columns[0].HeaderText = "Cód";
            gridRetirados.Columns[1].HeaderText = "Cód Imob";
            gridRetirados.Columns[2].HeaderText = "Endereço";
            gridRetirados.Columns[3].HeaderText = "Data Retirada";

            gridRetirados.Columns[0].Width = 60;
            gridRetirados.Columns[1].Width = 68;
            gridRetirados.Columns[2].Width = 260;
            gridRetirados.Columns[3].Width = 220;



        }

        private void Retirados_Load(object sender, EventArgs e)
        {
            atualizarGrid();
        }

        private void GridRetirados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnFiltro_Click(object sender, EventArgs e)
        {
            filtrosPanel.Visible = true;
        }

        private void CheckDataProposta_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDataRetirada.Checked)
            {
                dpMinDataRetirada.Enabled = true;
                dpMaxDataRetirada.Enabled = true;
            }
            else
            {
                dpMinDataRetirada.Enabled = false;
                dpMaxDataRetirada.Enabled = false;
            }
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            metroRadioButton3.Checked = true;
            checkDataRetirada.Checked = false;
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            atualizarGrid();
            filtrosPanel.Visible = false;
        }

        private void radioTipo(object sender, EventArgs e)
        {
            atualizarGrid();
        }

        private void GridRetirados_SelectionChanged(object sender, EventArgs e)
        {
            DataTable tabela = new DataTable();

            tabela = database.select(string.Format("SELECT c.cod_imob, c.cod_chave, r.tipo_retirada, r.quem_retirou, r.descricao, " +
                                                    " r.data_retirada, (u.cod_usuario || ' - ' || u.nome_usuario) " +
                                                    " FROM retirado r " +
                                                    " INNER JOIN usuario u ON u.cod_usuario = r.cod_usuario " +
                                                    " LEFT JOIN chave c ON c.indice_chave = r.cod_chave " +
                                                    " WHERE r.cod_retirado = '{0}'", gridRetirados.CurrentRow.Cells[0].Value.ToString()));

            if(tabela.Rows.Count == 0)
            {
                codigoImob.Text = "";
                codChave.Text = "";
                tipoRetirante.Text = "";
                nomeRetirante.Text = "";
                descricao.Text = "";
                dataRetirada.Text = "";
                funcionario.Text = "";
            }

            foreach(DataRow row in tabela.Rows)
            {
                codigoImob.Text = row[0].ToString();
                codChave.Text = row[1].ToString();
                tipoRetirante.Text = row[2].ToString();
                nomeRetirante.Text = row[3].ToString();
                descricao.Text = row[4].ToString();
                dataRetirada.Text = row[5].ToString();
                funcionario.Text = row[6].ToString();
            }

        }

        private void TextBoxBusca_Click(object sender, EventArgs e)
        {
            textBoxBusca.Text = "";
        }

        private void TextBoxBusca_Leave(object sender, EventArgs e)
        {
            textBoxBusca.Text = "Buscar";
        }

        private void TextBoxBusca_TextChanged(object sender, EventArgs e)
        {
            atualizarGrid();
        }
    }
}
