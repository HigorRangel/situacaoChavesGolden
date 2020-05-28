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
    public partial class Propostas : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();
        public Propostas()
        {
            InitializeComponent();
        }

        void atualizarGrid()
        {

          

            string tipoImovel = groupMenuSup.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string situacaoProposta = groupBoxSitProposta.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            if(situacaoProposta == "TODOS") { situacaoProposta = ""; }
            if(tipoImovel == "TODOS") { tipoImovel = ""; }

            string dataRetirada = string.Format(" AND data_Retirada BETWEEN '{0}' AND '{1}'", dpMinDataProposta.Value, dpMaxDataProposta.Value);

            if (!checkDataProposta.Checked) { dataRetirada = ""; }

            string busca = textBoxBusca.Text;
            if(busca == "Buscar") { busca = ""; }

            gridPropostas.DataSource = database.select(string.Format("SELECT p.cod_proposta, c.rua || ', ' || c.numero || ' - ' || c.bairro as endereco, p.data, p.situacao " +
                                                        " FROM proposta p " +
                                                        " INNER JOIN chave c ON c.indice_chave = p.cod_chave " +
                                                        " INNER JOIN emprestimo e ON e.cod_emprestimo = p.emprestimo " +
                                                        " LEFT JOIN cliente cl ON cl.cod_cliente = e.cod_cliente " +
                                                        " LEFT JOIN usuario u ON u.cod_usuario = e.cod_usuario " +
                                                        " LEFT JOIN proprietario pr ON pr.cod_proprietario = e.cod_proprietario " +
                                                        " WHERE (p.situacao ILIKE '%{0}%' AND c.finalidade ILIKE '%{1}%' {2})" +
                                                         " AND (cl.nome_cliente ILIKE '%{3}%' OR p.outros ILIKE '%{3}%' OR " +
                                                         " c.rua ILIKE '%{3}%' OR u.nome_usuario ILIKE '%{3}%' OR  pr.nome  ILIKE '%{3}%' OR" +
                                                         " c.cod_chave::TEXT ILIKE '%{3}%' OR c.cod_imob::TEXT ILIKE '%{3}%')", situacaoProposta, tipoImovel,
                                                         dataRetirada, busca));

            gridPropostas.Columns[0].HeaderText = "Código";
            gridPropostas.Columns[1].HeaderText = "Endereço";
            gridPropostas.Columns[2].HeaderText = "Data";
            gridPropostas.Columns[3].HeaderText = "Situação";

            gridPropostas.Columns[0].Width = 60;
            gridPropostas.Columns[1].Width = 258;
            gridPropostas.Columns[2].Width = 145;
            gridPropostas.Columns[3].Width = 145;


            string situacao = "";
            try
            {
                gridPropostas.CurrentRow.Cells[3].Value.ToString();
            }
            catch
            {
                situacao = "REPROVADA";
            }
           
            if (gridPropostas.CurrentRow != null && (situacao != "APROVADA" && situacao != "REPROVADA"))
            {
                btnAprovar.Enabled = true;
                btnContraProposta.Enabled = true;
                btnReprovar.Enabled = true;

                btnAprovar.Image = new Bitmap(Properties.Resources.Sucess);
                btnContraProposta.Image = new Bitmap(Properties.Resources.contraProposta);
                btnReprovar.Image = new Bitmap(Properties.Resources.Delete);
            }
            else
            {
                btnAprovar.Enabled = false;
                btnContraProposta.Enabled = false;
                btnReprovar.Enabled = false;

                btnAprovar.Image = new Bitmap(Properties.Resources.SucessGray);
                btnContraProposta.Image = new Bitmap(Properties.Resources.contraPropostagGray);
                btnReprovar.Image = new Bitmap(Properties.Resources.DeleteGray);
            }
        }

        private void Propostas_Load(object sender, EventArgs e)
        {
            atualizarGrid();
        }



        private void GridPropostas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string situacao = gridPropostas.CurrentRow.Cells[3].Value.ToString();
                if (situacao == "APROVADA" || situacao == "REPROVADA")
                {
                    btnAprovar.Enabled = false;
                    btnAprovar.Image = Properties.Resources.SucessGray;
                    btnContraProposta.Enabled = false;
                    btnContraProposta.Image = Properties.Resources.contraPropostagGray;
                    btnReprovar.Enabled = false;
                    btnReprovar.Image = Properties.Resources.DeleteGray;
                }
                else
                {
                    btnAprovar.Enabled = true;
                    btnAprovar.Image = Properties.Resources.Sucess;
                    btnContraProposta.Enabled = true;
                    btnContraProposta.Image = Properties.Resources.contraProposta;
                    btnReprovar.Enabled = true;
                    btnReprovar.Image = Properties.Resources.Delete;
                }
            }
            catch
            {

            }
            try
            {


                DataTable tabelaPropostas = new DataTable();

                if (gridPropostas.CurrentRow == null)
                {
                    codigoImob.Text = "";
                    codChave.Text = "";
                    sitProposta.Text = "";
                    dadosPropostante.Text = "";
                    descricao.Text = "";
                    codEmprestimo.Text = "";
                    dataProposta.Text = "";
                    funcionario.Text = "";
                    valorProposta.Text = "";
                    valorCond.Text = "";
                    formaLoc.Text = "";
                }

                tabelaPropostas = database.select(string.Format("SELECT c.cod_imob, c.cod_chave, pr.situacao, (CASE WHEN e.cod_proprietario is null AND e.cod_cliente is null THEN 'FUNCIONARIO' " +
                                                " WHEN e.cod_proprietario is null AND e.cod_cliente is not null THEN 'CLIENTE' " +
                                                                           " WHEN e.cod_proprietario is not null AND e.cod_cliente is null THEN 'PROPRIETARIO' END) as tipo, " +
                                                                           " '(' || cl.cod_cliente || ') - ' || cl.nome_cliente as cliente, cl.contato_principal || ' / ' || " +
                                                                           " cl.contato_secundario as contato_cliente, '(' || p.cod_proprietario || ') - ' || " +
                                                                           " p.nome as proprietario, p.contato, u.nome_usuario, pr.outros, pr.emprestimo, pr.data, " +
                                                                           " pr.valor, pr.condominio, pr.forma_locacao " +
                                                " FROM proposta pr " +
                                                " INNER JOIN emprestimo e ON e.cod_emprestimo = pr.emprestimo " +
                                                " INNER JOIN chave c ON c.indice_chave = pr.cod_chave " +
                                                " LEFT JOIN cliente cl ON e.cod_cliente = cl.cod_cliente " +
                                                " LEFT JOIN proprietario p ON p.cod_proprietario = e.cod_proprietario " +
                                                " LEFT JOIN usuario u ON u.cod_usuario = e.cod_usuario" +
                                                " WHERE pr.cod_proposta = '{0}'", gridPropostas.CurrentRow.Cells[0].Value.ToString()));


                foreach (DataRow row in tabelaPropostas.Rows)
                {
                    codigoImob.Text = row[0].ToString();
                    codChave.Text = row[1].ToString();
                    sitProposta.Text = row[2].ToString();
                    if (row[3].ToString() == "FUNCIONARIO")
                    {
                        dadosPropostante.Text = string.Format("{0} [{1}]", row[8].ToString(), row[3].ToString());

                    }
                    else if (row[3].ToString() == "CLIENTE")
                    {
                        dadosPropostante.Text = string.Format("{0} [{1}]", row[4].ToString(), row[3].ToString());
                        contato.Text = row[5].ToString();
                    }
                    else
                    {
                        dadosPropostante.Text = string.Format("{0} [{1}]", row[6].ToString(), row[3].ToString());
                        contato.Text = row[7].ToString();
                    }

                    descricao.Text = row[9].ToString();
                    codEmprestimo.Text = row[10].ToString();
                    dataProposta.Text = row[11].ToString();
                    funcionario.Text = row[8].ToString();
                    valorProposta.Text = string.Format("R$ {0}", row[12].ToString());
                    valorCond.Text = string.Format("R$ {0}", row[13].ToString());
                    formaLoc.Text = row[14].ToString();
                }
            }
            catch (Exception erro)
            {//{
             //    codigoImob.Text = "";
             //    codChave.Text = "";
             //    sitProposta.Text = "";
             //    dadosPropostante.Text = "";
             //    descricao.Text = "";
             //    codEmprestimo.Text = "";
             //    dataProposta.Text = "";
             //    funcionario.Text = "";
             //    valorProposta.Text = "";
             //    valorCond.Text = "";
             //    formaLoc.Text = "";


                //    btnAprovar.Enabled = false;
                //    btnAprovar.Image = Properties.Resources.SucessGray;
                //    btnContraProposta.Enabled = false;
                //    btnContraProposta.Image = Properties.Resources.contraPropostagGray;
                //    btnReprovar.Enabled = false;
                //    btnReprovar.Image = Properties.Resources.DeleteGray;
            }

        }

        private void RadioVenda_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnAprovar_Click(object sender, EventArgs e)
        {
            database.update(string.Format("UPDATE proposta" +
                                          " SET situacao = 'APROVADA'" +
                                          " WHERE cod_proposta = '{0}'", gridPropostas.CurrentRow.Cells[0].Value));
            atualizarGrid();
        }

        private void BtnContraProposta_Click(object sender, EventArgs e)
        {
            database.update(string.Format("UPDATE proposta" +
                                          " SET situacao = 'CONTRA-PROPOSTA'" +
                                          " WHERE cod_proposta = '{0}'", gridPropostas.CurrentRow.Cells[0].Value));
            atualizarGrid();
        }

        private void BtnReprovar_Click(object sender, EventArgs e)
        {
            database.update(string.Format("UPDATE proposta" +
                                         " SET situacao = 'REPROVADA'" +
                                         " WHERE cod_proposta = '{0}'", gridPropostas.CurrentRow.Cells[0].Value));
            atualizarGrid();
        }

        private void CheckDataProposta_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDataProposta.Checked)
            {
                dpMinDataProposta.Enabled = true;
                dpMaxDataProposta.Enabled = true;
            }
            else
            {
                dpMinDataProposta.Enabled = false;
                dpMaxDataProposta.Enabled = false;
            }
            
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            metroRadioButton3.Checked = true;
            checkDataProposta.Checked = false;
            
        }

        private void radioTipo(object sender, EventArgs e)
        {
            atualizarGrid();
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            atualizarGrid();
            filtrosPanel.Visible = false;
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

        private void BtnFiltro_Click(object sender, EventArgs e)
        {
            filtrosPanel.Visible = true;
        }

        private void GridPropostas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
           
        }
    }
}
