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
        cadastroChave cadChave = new cadastroChave("");
        string codigoChaveAtual = "";

        public Retirados()
        {
            InitializeComponent();
        }

        private void atualizarGrid()
        {
            gridRetirados.Columns.Clear();

            string tipoImovel = groupMenuSup.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string situacaoQuemRetirou = groupBoxQuemRetirou.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            if (situacaoQuemRetirou == "TODOS") { situacaoQuemRetirou = ""; }
            if (tipoImovel == "TODOS") { tipoImovel = ""; }



            string dataRetirada = string.Format("data_Retirada BETWEEN '{0}' AND '{1}' AND ", dpMinDataRetirada.Value, dpMaxDataRetirada.Value);

            if (!checkDataRetirada.Checked) { dataRetirada = ""; }

            string busca = textBoxBusca.Text;
            if (busca == "Buscar") { busca = ""; }
            if(tipoImovel == "TODOS") { tipoImovel = ""; }

            DataGridViewImageColumn cellImageEdit = new DataGridViewImageColumn();
            cellImageEdit.Image = new Bitmap(Properties.Resources.Back2);


            gridRetirados.Columns.Insert(0, cellImageEdit);


            DataTable tabela = new DataTable();

            tabela = database.select(string.Format("SELECT r.codigo_desativado, c.cod_imob, c.rua || ', ' || c.numero || ' - ' || c.bairro as endereco, " +
                                                    " data_retirada,  r.cod_retirado" +
                                                    " FROM retirado r " +
                                                    " INNER JOIN chave c ON c.indice_chave = r.cod_chave " +
                                                    " WHERE ({0} c.finalidade ILIKE '%{1}%' AND r.tipo_retirada ILIKE '%{2}%') " +
                                                            " AND (c.cod_chave::text ILIKE '%{3}%' OR c.rua ILIKE '%{3}%' OR c.bairro  ILIKE '%{3}%' OR " +
                                                                " r.quem_retirou  ILIKE '%{3}%' OR r.descricao  ILIKE '%{3}%' OR c.cod_imob  ILIKE '%{3}%')",
                                                                dataRetirada, tipoImovel, situacaoQuemRetirou, busca));

            gridRetirados.DataSource = tabela.DefaultView;

            gridRetirados.Columns[1].HeaderText = "Cód Retirado";
            gridRetirados.Columns[2].HeaderText = "Cód Imob";
            gridRetirados.Columns[3].HeaderText = "Endereço";
            gridRetirados.Columns[4].HeaderText = "Data Retirada";
            gridRetirados.Columns[5].Visible = false;

           


            gridRetirados.Columns[0].Width = 40;
            gridRetirados.Columns[1].Width = 50;
            gridRetirados.Columns[2].Width = 68;
            gridRetirados.Columns[3].Width = 340;
            gridRetirados.Columns[5].Width = 100;


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
            try
            {
                DataTable tabela = new DataTable();

                tabela = database.select(string.Format("SELECT c.cod_imob, c.cod_chave, r.tipo_retirada, r.quem_retirou, r.descricao, " +
                                                        " r.data_retirada, (u.cod_usuario || ' - ' || u.nome_usuario) , codigo_desativado, r.cod_chave " +
                                                        " FROM retirado r " +
                                                        " INNER JOIN usuario u ON u.cod_usuario = r.cod_usuario " +
                                                        " LEFT JOIN chave c ON c.indice_chave = r.cod_chave " +
                                                        " WHERE r.cod_retirado = '{0}'", gridRetirados.CurrentRow.Cells[5].Value.ToString()));

                if (tabela.Rows.Count == 0)
                {
                    codigoImob.Text = "";
                    codChave.Text = "";
                    tipoRetirante.Text = "";
                    nomeRetirante.Text = "";
                    descricao.Text = "";
                    dataRetirada.Text = "";
                    funcionario.Text = "";
                }

                foreach (DataRow row in tabela.Rows)
                {
                    codigoImob.Text = row[0].ToString();
                    codChave.Text = row[1].ToString();
                    tipoRetirante.Text = row[2].ToString();
                    nomeRetirante.Text = row[3].ToString();
                    descricao.Text = row[4].ToString();
                    dataRetirada.Text = row[5].ToString();
                    funcionario.Text = row[6].ToString();
                    codChave.Text = row[7].ToString();
                    codigoChaveAtual = row[8].ToString();
                }
            }
            catch { }

        }

        private void TextBoxBusca_Click(object sender, EventArgs e)
        {
            textBoxBusca.Text = "";
        }

        private void TextBoxBusca_Leave(object sender, EventArgs e)
        {
            if(textBoxBusca.Text == "")
            {
                textBoxBusca.Text = "Buscar";
            }
            
        }

        private void TextBoxBusca_TextChanged(object sender, EventArgs e)
        {
            atualizarGrid();
        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void DataRetirada_Click(object sender, EventArgs e)
        {

        }

        private void Label15_Click(object sender, EventArgs e)
        {

        }

        private void Funcionario_Click(object sender, EventArgs e)
        {

        }

        private void gridRetirados_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                gridRetirados.Cursor = Cursors.Hand;
            }
            else
            {
                gridRetirados.Cursor = Cursors.Arrow;
            }
        }

        private void gridRetirados_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            

            if (e.ColumnIndex == 0)
            {
                Message msg = new Message("Você tem certeza que deseja recadastrar a chave?", "", "info", "escolha");
                msg.ShowDialog();

                string proxCod = cadChave.proximoCodigo();


                


                if (msg.DialogResult == DialogResult.Yes)
                {


                    database.update(string.Format("" +
                   " UPDATE chave " +
                   " SET situacao = 'DISPONIVEL', localizacao = 'IMOBILIARIA', cod_chave = '{0}' " +
                   " WHERE indice_chave = '{1}'", proxCod, codigoChaveAtual));


                    Message popup = new Message("A chave foi cadastrada com o código " + proxCod + "!" +
                              "\n Deseja imprimir a etiqueta da chave?", "", "sucesso", "escolha");
                    popup.ShowDialog();

                    if (popup.DialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            ImprimirEtiquetas imprimir = new ImprimirEtiquetas(
                                database.selectScalar(string.Format("SELECT indice_chave" +
                                                        " FROM chave" +
                                                        " WHERE cod_chave = '{0}'", proxCod)));


                            imprimir.ShowDialog();
                        }
                        catch (Exception error)
                        {
                            Message erroMsg = new Message("Não foi possível imprimir a etiqueta. \n\nERRO: " + error.Message
                                , "", "erro", "confirma");
                            erroMsg.ShowDialog();
                        }

                    }


                    

                    database.delete(string.Format("" +
                                                  " DELETE FROM  retirado " +
                                                  " WHERE cod_retirado = '{0}'", gridRetirados.CurrentRow.Cells[5].Value.ToString()));

                    


                    atualizarGrid();
                }
               


            }
            
        }
    }
}
