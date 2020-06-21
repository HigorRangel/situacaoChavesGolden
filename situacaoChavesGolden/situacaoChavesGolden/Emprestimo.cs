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
    public partial class Emprestimo : MetroFramework.Forms.MetroForm
    {

        DateTime dataHoje = DateTime.Now;
        PostgreSQL database = new PostgreSQL();
        string usuario = "";
        public Emprestimo(string user)
        {
            InitializeComponent();
            usuario = user;
        }

        private void atualizarGridEmprestimo()
        {

            try
            {
                DataTable dadosEmprestimo = new DataTable();

                string situacao = groupMenuSup.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
                string tipo = groupTipoEmprestimo.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
                string dataRetirada = string.Format(" AND data_Retirada BETWEEN '{0}' AND '{1}'", dpMinDataRetirada.Value, dpMaxDataRetirada.Value);
                string entregaPrevista = string.Format(" AND entrega_prevista BETWEEN '{0}' AND '{1}'  ", dpMinPrevisEntrega.Value, dpMaxPrevisEntrega.Value);
                string dataEntrega = string.Format(" AND data_entrega BETWEEN '{0}' AND '{1}' ", dpMinDataEntrega.Value, dpMaxDataEntrega.Value);
                string busca = textBoxBusca.Text;

                if(!checkDataRetirada.Checked) { dataRetirada = ""; }
                if(!checkPrevisEntrega.Checked) { entregaPrevista = ""; }
                if(!checkDataEntrega.Checked) { dataEntrega = ""; }

                string selecData = "";
                string tituloColData = "";


                if (situacao == "TODOS") { situacao = ""; selecData = "e.entrega_prevista"; tituloColData = "Prev Entrega"; }
                else if (situacao == "FINALIZADO") { selecData = "e.data_entrega"; tituloColData = "Data entrega"; }
                else { selecData = "e.entrega_prevista"; tituloColData = "Prev entrega"; }
                if (tipo == "TODOS") { tipo = ""; }

                if(busca == "Buscar") { busca = ""; }

                

                //MessageBox.Show(situacao);
                dadosEmprestimo = database.select(string.Format("SELECT e.cod_emprestimo, e.data_retirada, {6}, " +
                                                  " (CASE WHEN e.data_entrega is null THEN 'EM ANDAMENTO' ELSE 'FINALIZADO' END) as situacao" +
                                                  " FROM emprestimo e " +
                                                  " INNER JOIN chaves_emprestimo ce ON ce.cod_emprestimo = e.cod_emprestimo" +
                                                  " LEFT JOIN chave c ON ce.cod_chave = c.indice_chave " +
                                                  " LEFT JOIN cliente cl ON cl.cod_cliente = e.cod_cliente " +
                                                  " LEFT JOIN usuario u ON u.cod_usuario = e.cod_usuario " +
                                                  " LEFT JOIN proprietario p ON p.cod_proprietario = e.cod_proprietario " +
                                                  " WHERE " +
                                                        " ((CASE WHEN e.data_entrega is null THEN 'EM ANDAMENTO' ELSE 'FINALIZADO' END) ILIKE '%{0}%' " +
                                                        "  AND (CASE WHEN e.cod_proprietario is null AND e.cod_cliente is null THEN 'FUNCIONARIO' " +
                                                            " WHEN e.cod_proprietario is null AND e.cod_cliente is not null THEN 'CLIENTE' " +
                                                            " WHEN e.cod_proprietario is not null AND e.cod_cliente is null THEN 'PROPRIETARIO' END) ILIKE '%{1}%'" +
                                                            " {2} " +
                                                            " {3} " +
                                                            " {4} ) " +
                                                         " AND (cl.nome_cliente ILIKE '%{5}%' OR e.descricao ILIKE '%{5}%' OR " +
                                                         " c.rua ILIKE '%{5}%' OR u.nome_usuario ILIKE '%{5}%' OR  p.nome  ILIKE '%{5}%'OR" +
                                                         " c.cod_chave::TEXT || 'c' ILIKE '%{5}%' OR c.cod_imob::TEXT ILIKE '%{5}%')" +
                                                         " GROUP BY e.cod_emprestimo" +
                                                         " ORDER BY {6}", 
                                                         situacao, tipo,  dataRetirada, entregaPrevista, dataRetirada, busca, selecData));


 

                gridEmprestimo.DataSource = dadosEmprestimo;

                

                

                gridEmprestimo.Columns[0].HeaderText = "Código";        
                gridEmprestimo.Columns[1].HeaderText = "Data Retirada";
                gridEmprestimo.Columns[2].HeaderText = tituloColData;
                gridEmprestimo.Columns[3].HeaderText = "Situação";

                gridEmprestimo.Columns[0].Width = 40;
                gridEmprestimo.Columns[1].Width = 98;
                gridEmprestimo.Columns[2].Width = 97;
                gridEmprestimo.Columns[3].Width = 98;

            }
            catch (Exception erro)
            {
            }

            string sitEmprestimo = "";
            try
            {
                sitEmprestimo = gridEmprestimo.CurrentRow.Cells[3].Value.ToString();

            }
            catch
            {
                sitEmprestimo = "FINALIZADO";
            }

            if (sitEmprestimo == "FINALIZADO" || gridEmprestimo.CurrentRow == null)
            {
                btnBaixa.Enabled = false;
                btnProrrogar.Enabled = false;

                btnBaixa.Image = Properties.Resources.BaixaEmprestimoGray;
                btnProrrogar.Image = Properties.Resources.ProrrogarEmprestimoGray;
            }
            else
            {
                btnBaixa.Enabled = true;
                btnProrrogar.Enabled = true;

                btnBaixa.Image = Properties.Resources.BaixaEmprestimo;
                btnProrrogar.Image = Properties.Resources.ProrrogarEmprestimo;
            }

        }

        private void Emprestimo_Load(object sender, EventArgs e)
        {
            atualizarGridEmprestimo();

            

            dpMinDataRetirada.Value = dataHoje.AddMonths(-3);
            dpMinPrevisEntrega.Value = dataHoje.AddMonths(-3);
            dpMinDataEntrega.Value = dataHoje.AddMonths(-3);

            dpMaxDataRetirada.Value = dataHoje.AddDays(7);
            dpMaxPrevisEntrega.Value = dataHoje.AddDays(7);
            dpMaxDataEntrega.Value = dataHoje.AddDays(7);

            dpMaxDataRetirada.MaxDate = dataHoje;
            dpMaxDataEntrega.MaxDate = dataHoje;
        }

        void atualizarGridChavesEmprestimo()
        {
                           DataTable dadosEmprestimo = new DataTable();


            try
            {
                dadosEmprestimo = database.select(string.Format("SELECT c.cod_chave," +
                                                               " c.rua || ', ' || c.numero || (CASE WHEN c.complemento is null OR c.complemento = '' THEN '' ELSE ' - ' || c.complemento END)" +
                                                               " as endereco, c.indice_chave" +
                                                               " FROM chave c" +
                                                               " INNER JOIN chaves_emprestimo ce ON ce.cod_chave = c.indice_chave" +
                                                               " INNER JOIN emprestimo e ON e.cod_emprestimo = ce.cod_emprestimo" +
                                                               " WHERE e.cod_emprestimo = '{0}'" +
                                                               " ORDER BY c.cod_chave", gridEmprestimo.CurrentRow.Cells[0].Value.ToString()));

                if (dadosEmprestimo.Rows.Count == 0)
                {
                    dadosEmprestimo.Clear();
                    gridChavesEmprestimo.DataSource = null;
                    gridChavesEmprestimo.Rows.Clear();

                }
                else
                {
                    gridChavesEmprestimo.DataSource = dadosEmprestimo;

                    gridChavesEmprestimo.Columns[0].Width = 40;
                    gridChavesEmprestimo.Columns[1].Width = 225;
                    gridChavesEmprestimo.Columns[2].Visible = false;

                    gridChavesEmprestimo.Columns[0].HeaderText = "Chave";
                    gridChavesEmprestimo.Columns[1].HeaderText = "Endereço";
                }
               
            }
            catch 
            {
                dadosEmprestimo.Clear();
                gridChavesEmprestimo.DataSource = null;
                gridChavesEmprestimo.Rows.Clear();
            }

        }

        private void GridEmprestimo_SelectionChanged(object sender, EventArgs e)
        {
            //if(gridEmprestimo.CurrentRow.Index < 0)
            //{
            //    gridChavesEmprestimo.Rows.Clear();
            //}

            painelDados.Visible = false;


            codImobChave.Text = "";
            finalidade.Text = "";
            sitImovel.Text = "";
            endereco.Text = "";
            proprietario.Text = "";
            tipoImovel.Text = "";
            sitChave.Text = "";
            localizacao.Text = "";
            codEmprestimo.Text = "";

            atualizarGridChavesEmprestimo();

            try
            {
                if (gridEmprestimo.CurrentRow.Cells[3].Value.ToString() == "FINALIZADO")
                {
                    btnBaixa.Enabled = false;
                    btnProrrogar.Enabled = false;

                    btnBaixa.Image = Properties.Resources.BaixaEmprestimoGray;
                    btnProrrogar.Image = Properties.Resources.ProrrogarEmprestimoGray;
                }
                else
                {
                    btnBaixa.Enabled = true;
                    btnProrrogar.Enabled = true;

                    btnBaixa.Image = Properties.Resources.BaixaEmprestimo;
                    btnProrrogar.Image = Properties.Resources.ProrrogarEmprestimo;
                }
            }
            catch { }


            try
            {
                DataTable dadosEmprestimo = new DataTable();
               

                dadosEmprestimo = database.select(string.Format("" +
                    "SELECT  " +
                    " (CASE WHEN e.data_entrega is null THEN 'EM ANDAMENTO' ELSE 'FINALIZADO' END) as situacao, " +
                    " (CASE WHEN e.cod_proprietario is null AND e.cod_cliente is null THEN 'FUNCIONARIO' " +
                          "  WHEN e.cod_proprietario is null AND e.cod_cliente is not null THEN 'CLIENTE' " +
                           " WHEN e.cod_proprietario is not null AND e.cod_cliente is null THEN 'PROPRIETARIO' END) as tipo, " +
                           " '(' || cl.cod_cliente || ') - ' || cl.nome_cliente, cl.contato_principal || ' / ' || cl.contato_secundario, " +
                           " '(' || p.cod_proprietario || ') - ' || p.nome as proprietario, p.contato, u.nome_usuario, " +
                           " (CASE WHEN e.desc_devolucao = '' OR e.desc_devolucao is null THEN e.descricao ELSE 'ENTREGA: ' || e.descricao END), " +
                           "  e.data_retirada, e.entrega_prevista, e.data_entrega, (SELECT nome_usuario FROM usuario WHERE cod_usuario = e.usuario_devolucao)," +
                           " (CASE WHEN e.desc_devolucao = '' OR e.desc_devolucao is null THEN '' ELSE 'DEVOLUÇÃO: ' || e.desc_devolucao END) " +
                    " FROM emprestimo e " +
                    " LEFT JOIN cliente cl ON cl.cod_cliente = e.cod_cliente " +
                    " LEFT JOIN usuario u ON u.cod_usuario = e.cod_usuario " +
                    " LEFT JOIN proprietario p ON p.cod_proprietario = e.cod_proprietario" +
                    " WHERE cod_emprestimo = '{0}'", gridEmprestimo.CurrentRow.Cells[0].Value.ToString()));


                    foreach (DataRow row in dadosEmprestimo.Rows)
                    {
               

                    sitEmprestimo.Text = row[0].ToString();

                    if (row[1].ToString() == "FUNCIONARIO")
                    {
                        dadosRetirante.Text = string.Format("{0} [{1}]", row[6].ToString(), row[1].ToString());

                    }
                    else if (row[1].ToString() == "CLIENTE")
                    {
                        dadosRetirante.Text = string.Format("{0} [{1}]", row[2].ToString(), row[1].ToString());
                        contato.Text = row[3].ToString();
                    }
                    else
                    {
                        dadosRetirante.Text = string.Format("{0} [{1}]", row[4].ToString(), row[1].ToString());
                        contato.Text = row[5].ToString();
                    }

                    descricao.Text = row[7].ToString() + "\n" + row[12].ToString();
                    funcionario.Text = row[6].ToString();
                    dataRetirada.Text = row[8].ToString();
                    previsEntrega.Text = row[9].ToString();
                    dataEntrega.Text = row[10].ToString();
                    funcionarioDevolucao.Text = row[11].ToString();

                }
            }
            catch { }

        }


        private void BtnFiltro_Click(object sender, EventArgs e)
        {
            filtrosPanel.Visible = true;
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            metroRadioButton1.Checked = true;
            checkDataRetirada.Checked = false;
            checkPrevisEntrega.Checked = false;
            checkDataEntrega.Checked = false;


            dpMinDataRetirada.Value = dataHoje.AddMonths(-3);
            dpMinPrevisEntrega.Value = dataHoje.AddMonths(-3);
            dpMinDataEntrega.Value = dataHoje.AddMonths(-3);

           

            dpMaxDataRetirada.MaxDate = dataHoje;
            dpMaxDataEntrega.MaxDate = dataHoje;
        }

        private void TextBoxBusca_Click(object sender, EventArgs e)
        {
            if (textBoxBusca.Text == "Buscar")
            {
                textBoxBusca.Text = "";
            }
        }

        private void TextBoxBusca_TextChanged(object sender, EventArgs e)
        {
            atualizarGridEmprestimo();
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            int contErro = 0;
            string msgErro = "A data mínima não pode ser superior à data máxima nos seguintes campos!\n\n";

            if(dpMinDataRetirada.Value > dpMaxDataRetirada.Value && checkDataRetirada.Checked)
            {
                msgErro += "- Data de Retirada";
                contErro++;
            }

            if (dpMinPrevisEntrega.Value > dpMaxPrevisEntrega.Value && checkPrevisEntrega.Checked)
            {
                msgErro += "- Previsão de entrega";
                contErro++;
            }

            if (dpMinDataEntrega.Value > dpMaxDataEntrega.Value && checkDataEntrega.Checked)
            {
                msgErro += "- Data de entrega";
                contErro++;
            }

            if(contErro != 0)
            {
                Message popup = new Message(msgErro, "", "erro", "confirma");
                popup.ShowDialog();
            }
            else
            {
                filtrosPanel.Visible = false;
                atualizarGridEmprestimo();
            }

            
        }

        private void MetroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FiltrosPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBoxBusca_Leave(object sender, EventArgs e)
        {
            if (textBoxBusca.Text == "")
            {
                textBoxBusca.Text = "Buscar";
            }
        }

        private void RadioTodos_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("oii");
            atualizarGridEmprestimo();
        }

        private void GroupMenuSup_Enter(object sender, EventArgs e)
        {

        }

        private void CheckDataRetirada_CheckedChanged(object sender, EventArgs e)
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

        private void CheckPrevisEntrega_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPrevisEntrega.Checked)
            {
                dpMinPrevisEntrega.Enabled = true;
                dpMaxPrevisEntrega.Enabled = true;
            }
            else
            {
                dpMinPrevisEntrega.Enabled = false;
                dpMaxPrevisEntrega.Enabled = false;
            }
        }

        private void CheckDataEntrega_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDataEntrega.Checked)
            {
                dpMinDataEntrega.Enabled = true;
                dpMaxDataEntrega.Enabled = true;
            }
            else
            {
                dpMinDataEntrega.Enabled = false;
                dpMaxDataEntrega.Enabled = false;
            }
        }

        private void MetroRadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnProrrogar_Click(object sender, EventArgs e)
        {
            ProrrogarEmpréstimo prorrogar = new ProrrogarEmpréstimo(gridEmprestimo.CurrentRow.Cells[0].Value.ToString());
            prorrogar.ShowDialog();

            atualizarGridEmprestimo();
        }

        private void gridEmprestimo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //try
            //{
                string situacao = groupMenuSup.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
                DataGridViewRow row = gridEmprestimo.Rows[e.RowIndex];


                //MessageBox.Show(row.Cells[4].Value.ToString());

                if (situacao == "EM ANDAMENTO" || situacao == "TODOS" && row.Cells[3].Value.ToString() != "FINALIZADO")
                {
                    try
                    {

                        DateTime data = DateTime.Parse(row.Cells[2].Value.ToString());

                        if (data < dataHoje)
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 176, 176);
                            row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(212, 55, 61);
                        }

                    }
                    catch { }
                }

            //}
            //catch { }
            


        }

        private void btnBaixa_Click(object sender, EventArgs e)
        {
            DevolverChave telaDevolver = new DevolverChave(gridEmprestimo.CurrentRow.Cells[0].Value.ToString(), usuario);
            telaDevolver.ShowDialog();

            atualizarGridEmprestimo();

        }

        private void GridEmprestimo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void gridChavesEmprestimo_SelectionChanged(object sender, EventArgs e)
        {
            painelDados.Visible = false;


            codImobChave.Text = "";
            finalidade.Text = "";
            sitImovel.Text = "";
            endereco.Text = "";
            proprietario.Text = "";
            tipoImovel.Text = "";
            sitChave.Text = "";
            localizacao.Text = "";
            codEmprestimo.Text = "";

            try
            {
                DataTable dadosChaves = new DataTable();


                dadosChaves = database.select(string.Format("SELECT c.cod_imob, c.cod_chave, ce.quant_chaves, ce.quant_controles " +
                                                            " FROM chave c " +
                                                            " INNER JOIN chaves_emprestimo ce ON ce.cod_chave = c.indice_chave " +
                                                            " WHERE c.indice_chave = '{0}' AND ce.cod_emprestimo = '{1}'",
                                                             gridChavesEmprestimo.CurrentRow.Cells[2].Value.ToString(), gridEmprestimo.CurrentRow.Cells[0].Value.ToString()));

                foreach (DataRow row in dadosChaves.Rows)
                {
                    codigoImob.Text = row[0].ToString();
                    codChave.Text = row[1].ToString();
                    qtdChaves.Text = row[2].ToString();
                    qtdControles.Text = row[3].ToString();
                }

            }
            catch { }


        }

        private void gridEmprestimo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (gridEmprestimo.Rows.Count == 0)
            {
                gridChavesEmprestimo.DataSource = null;
                gridChavesEmprestimo.Rows.Clear();
            }
        }

        private void gridEmprestimo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (gridEmprestimo.Rows.Count == 0)
            {
                gridChavesEmprestimo.DataSource = null;
                gridChavesEmprestimo.Rows.Clear();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ConfigurarReciboEmprestimo config = new ConfigurarReciboEmprestimo(gridEmprestimo.Rows[gridEmprestimo.CurrentRow.Index].Cells[0].Value.ToString());
            config.ShowDialog();
        }

        private void gridEmprestimo_SizeChanged(object sender, EventArgs e)
        {

        }

        private void gridChavesEmprestimo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow linha = gridEmprestimo.CurrentRow;

            codChavePainel.Text = gridChavesEmprestimo.CurrentRow.Cells[0].Value.ToString();

            painelDados.Location = new Point(gridEmprestimo.Location.X - 10, 22 * (linha.Index - gridEmprestimo.FirstDisplayedScrollingRowIndex) + 100);

            //MessageBox.Show();



            try
            {
                string codigoChave = gridChavesEmprestimo.CurrentRow.Cells[2].Value.ToString();

                DataTable dadosChave = new DataTable();

                dadosChave = database.select(string.Format("SELECT c.*, p.nome, p.cod_proprietario " +
                                                           " FROM chave c  " +
                                                           " INNER JOIN proprietario p ON p.cod_proprietario = c.proprietario " +
                                                           " WHERE indice_chave = {0}", codigoChave));


                foreach (DataRow row in dadosChave.Rows)
                {
                    codImobChave.Text = row[10].ToString();
                    finalidade.Text = row[12].ToString();
                    sitImovel.Text = row[13].ToString().Replace("/", " E ");
                    endereco.Text = string.Format("{0}, {1} - {2} - {3}/{4} [{6} {5}]", row[1].ToString(),
                        row[5].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(),
                        row[6].ToString(), row[16].ToString());
                    proprietario.Text = string.Format("{0} - {1}", row[20].ToString(), row[19].ToString());
                    tipoImovel.Text = row[11].ToString();
                    sitChave.Text = row[7].ToString();
                    localizacao.Text = row[8].ToString();
                    codEmprestimo.Text = gridEmprestimo.Rows[gridEmprestimo.CurrentRow.Index].Cells[0].Value.ToString();

                }
                painelDados.Visible = true;
            }
            catch { }

            
        }

        private void label27_Click(object sender, EventArgs e)
        {
            painelDados.Visible = false;


            codImobChave.Text = "";
            finalidade.Text = "";
            sitImovel.Text = "";
            endereco.Text =  "";
            proprietario.Text = "";
            tipoImovel.Text = "";
            sitChave.Text = "";
            localizacao.Text = "";
            codEmprestimo.Text = "";

        }
    }
}
