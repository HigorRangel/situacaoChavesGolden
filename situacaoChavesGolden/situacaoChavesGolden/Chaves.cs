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
    public partial class Chaves : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();


        public void atualizarGridChaves()
        {
            if (gridChaves.CurrentRow == null)
            {
                btnExcluir.Enabled = false;
                btnEmprestar.Enabled = false;
                btnReservar.Enabled = false;

                btnExcluir.Image = new Bitmap(Properties.Resources.DeleteGray);
                btnEmprestar.Image = new Bitmap(Properties.Resources.ChaveEmprestarGray);
                btnReservar.Image = new Bitmap(Properties.Resources.ChaveReservarGray);
            }
            DataTable chaves = new DataTable();

            string textoBusca = textBoxBusca.Text;
            string filtroSitImovel = groupBoxSituacaoIm.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string filtroSitChave = groupBoxSituacaoCh.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string typeImovel = groupBoxTipoImovel.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string filtro = groupMenuSup.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();

            if (textoBusca == "Buscar") { textoBusca = ""; }
            if (filtroSitImovel == "TODOS") { filtroSitImovel = ""; }
            if (filtroSitChave == "TODOS") { filtroSitChave = ""; }
            if (typeImovel == "TODOS") { typeImovel = ""; }
            if (filtro == "TODOS") { filtro = ""; }


            //try
            //{
            chaves = database.select(string.Format("SELECT c.cod_chave, c.cod_imob, c.rua || ', ' || c.numero || (CASE WHEN c.complemento is null OR c.complemento = '' THEN '' ELSE ' - ' || c.complemento END)" +
                                         " as endereco, c.bairro, c.situacao_imovel, c.indice_chave," +
                                         " (SELECT COUNT((CASE WHEN r.cod_reserva is not null AND " +
                                         " r.situacao != 'FINALIZADO' THEN 'RESERVADO' ELSE '' END)) " +
                                         " FROM reserva r " +
                                         " INNER JOIN chaves_reserva cr ON cr.cod_reserva = r.cod_reserva" +
                                         " WHERE cod_chave = c.indice_chave AND situacao = 'EM ANDAMENTO') as emprestimo," +
                                         " (SELECT COUNT(*) FROM emprestimo e LEFT JOIN chaves_emprestimo ce ON ce.cod_emprestimo = e.cod_emprestimo WHERE ce.cod_chave = c.indice_chave AND e.data_entrega IS NULL ) " +
                                         " FROM chave C" +
                                         " LEFT JOIN proprietario p ON p.cod_proprietario = c.proprietario " +
                                         " WHERE (cod_chave::text || 'c' ILIKE '{0}%' OR (unaccent(lower(c.rua))) ILIKE '%{0}%' OR (unaccent(lower(c.bairro))) ILIKE '%{0}%' OR (unaccent(lower(c.cidade))) ILIKE '%{0}%' OR (unaccent(lower(c.estado))) ILIKE '%{0}%' OR" +
                                         " (unaccent(lower(c.numero)))  ILIKE '%{0}%' OR (unaccent(lower(c.complemento))) ILIKE '%{0}%' OR (unaccent(lower(c.cod_imob))) ILIKE '%{0}%' OR (unaccent(lower(p.nome))) ILIKE '%{0}%'" +
                                         " OR c.rua  ILIKE '%{0}%' OR c.bairro ILIKE '%{0}%' OR c.cidade ILIKE '%{0}%' OR c.estado ILIKE '%{0}%' OR c.numero ILIKE '%{0}%' OR " +
                                         " c.complemento  ILIKE '%{0}%' OR c.cod_imob ILIKE '%{0}%') AND " +
                                         " (c.finalidade ILIKE '%{1}%' AND c.situacao ILIKE '{2}%' AND c.situacao_imovel ILIKE '{3}%' AND " +
                                         "  c.tipo_imovel ILIKE '%{4}%')" +
                                         " ORDER BY c.situacao_imovel, c.rua, c.cod_imob", textoBusca, filtro, filtroSitChave,
                                          filtroSitImovel, typeImovel));


            gridChaves.DataSource = chaves;

            gridChaves.Columns[0].HeaderText = "Código";
            gridChaves.Columns[1].HeaderText = "Cód Imob";
            gridChaves.Columns[2].HeaderText = "Endereço";
            gridChaves.Columns[3].HeaderText = "Bairro";
            gridChaves.Columns[4].HeaderText = "Imóvel";
            gridChaves.Columns[5].Visible = false;
            gridChaves.Columns[6].Visible = false;

            gridChaves.Columns[0].Width = 60;
            gridChaves.Columns[1].Width = 60;
            gridChaves.Columns[2].Width = 275;
            gridChaves.Columns[3].Width = 112;
            gridChaves.Columns[4].Width = 100;




            endereco.MaximumSize = new Size(520, 0);

            if (chaves.Rows.Count == 0)
            {
                codigoImob.Text = "";
                finalidade.Text = "";
                sitImovel.Text = "";
                endereco.Text = "";
                proprietario.Text = "";
                tipoImovel.Text = "";
                sitChave.Text = "";
                localizacao.Text = "";
            }
            else
            {
                gridChaves.Columns[0].HeaderText = "Código";
                gridChaves.Columns[1].HeaderText = "Cód Imob";
                gridChaves.Columns[2].HeaderText = "Endereço";
                gridChaves.Columns[3].HeaderText = "Bairro";
                gridChaves.Columns[4].HeaderText = "Imóvel";
                gridChaves.Columns[5].Visible = false;

                gridChaves.Columns[0].Width = 60;
                gridChaves.Columns[1].Width = 60;
                gridChaves.Columns[2].Width = 275;
                gridChaves.Columns[3].Width = 112;
                gridChaves.Columns[4].Width = 100;




                endereco.MaximumSize = new Size(520, 0);
                endereco.AutoSize = true;
                gridChaves.ClearSelection();
                gridChaves.Rows[0].Selected = false;

                if (proprietario.Text != " ")
                {
                    proprietario.Cursor = Cursors.Hand;
                }


            }


            //}
            //catch (Exception erro)
            //{

            //    MessageBox.Show(erro.Message);
            //}


        }

        string usuario = "";
        public Chaves(string codUser)
        {
            InitializeComponent();

            usuario = codUser;
        }

        private void Chaves_Load(object sender, EventArgs e)
        {

            atualizarGridChaves();

        }

        private void gridChaves_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {

                gridChaves.AccessibilityObject.HitTest(MousePosition.X, MousePosition.Y).Select(AccessibleSelection.TakeSelection);

            }
            catch { }


        }

        void mostrarAviso(string codigo)
        {
            try
            {
                string codChave = database.selectScalar(string.Format("SELECT cod_chave FROM chave WHERE indice_chave = {0}", codigo));
                string aviso = database.selectScalar(string.Format("SELECT aviso FROM chave WHERE indice_chave = {0}", codigo));
                aviso = aviso.Trim();

                if (aviso != "" && aviso != null && aviso != " ")
                {
                    Message msg = new Message(string.Format("Aviso da chave {0}:\n{1}", codChave, aviso), "", "aviso", "confirma");
                    msg.ShowDialog();
                }
            }
            catch { }

        }

        private void GridChaves_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                painelInfo.Visible = false;
                gridReserva.DataSource = null;

                if (gridChaves.CurrentRow.Cells[0].Value.ToString() == "")
                {
                    btnExcluir.Enabled = false;
                    btnEmprestar.Enabled = false;
                    btnReservar.Enabled = false;

                    btnExcluir.Image = new Bitmap(Properties.Resources.DeleteGray);
                    btnEmprestar.Image = new Bitmap(Properties.Resources.ChaveEmprestarGray);
                    btnReservar.Image = new Bitmap(Properties.Resources.ChaveReservarGray);
                }
                else
                {
                    btnExcluir.Enabled = true;
                    btnEmprestar.Enabled = true;
                    btnReservar.Enabled = true;

                    btnExcluir.Image = new Bitmap(Properties.Resources.Delete);
                    btnEmprestar.Image = new Bitmap(Properties.Resources.ChaveEmprestar);
                    btnReservar.Image = new Bitmap(Properties.Resources.ChaveReservar);
                }

                if (gridChaves.CurrentRow == null)
                {
                    codigoImob.Text = "";
                    finalidade.Text = "";
                    sitImovel.Text = "";
                    endereco.Text = "";
                    proprietario.Text = "";
                    tipoImovel.Text = "";
                    sitChave.Text = "";
                    localizacao.Text = "";
                }

                if (gridChaves.CurrentRow != null)
                {

                    string codigoChave = gridChaves.CurrentRow.Cells[5].Value.ToString();

                    DataTable dadosChave = new DataTable();

                    dadosChave = database.select(string.Format("SELECT c.*, p.nome " +
                                                               " FROM chave c  " +
                                                               " INNER JOIN proprietario p ON p.cod_proprietario = c.proprietario " +
                                                               " WHERE indice_chave = {0}", codigoChave));


                    foreach (DataRow row in dadosChave.Rows)
                    {
                        codigoImob.Text = row[10].ToString();
                        finalidade.Text = row[12].ToString();
                        sitImovel.Text = row[13].ToString().Replace("/", " E ");
                        endereco.Text = string.Format("{0}, {1} - {2} - {3}/{4} [{6} {5}]", row[1].ToString(),
                            row[5].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(),
                            row[6].ToString(), row[16].ToString());
                        proprietario.Text = row[19].ToString();
                        tipoImovel.Text = row[11].ToString();
                        sitChave.Text = row[7].ToString();
                        localizacao.Text = row[8].ToString();

                        if (row[7].ToString() == "INDISPONIVEL")
                        {
                            btnEmprestar.Image = Properties.Resources.ChaveDevolver;

                            ToolTipEmprestar.SetToolTip(btnEmprestar, "Devolver Chaves");
                        }
                        else
                        {
                            btnEmprestar.Image = Properties.Resources.ChaveEmprestar;

                            ToolTipEmprestar.SetToolTip(btnEmprestar, "Registrar Empréstimo");
                        }

                    }

                    string codEmprestimo = "";
                    try
                    {
                        codEmprestimo = database.selectScalar(string.Format("" +
                                            " SELECT e.cod_emprestimo" +
                                            " FROM emprestimo e" +
                                            " INNER JOIN chaves_emprestimo ce ON ce.cod_emprestimo = e.cod_emprestimo" +
                                            " INNER JOIN chave c ON c.indice_chave = ce.cod_chave" +
                                            " WHERE c.indice_chave = {0} AND e.data_entrega is null", codigoChave));


                        emprestimo.Text = codEmprestimo;
                        emprestimo.Cursor = Cursors.Hand;

                        if (codEmprestimo == "")
                        {
                            emprestimo.Text = "N/A";
                        }

                    }
                    catch
                    {
                        emprestimo.Text = "N/A";
                        emprestimo.Cursor = Cursors.Default;
                    }

                }

                mostrarAviso(gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[5].Value.ToString());
            }
            catch
            {

            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void RadioTodos_CheckedChanged(object sender, EventArgs e)
        {
            atualizarGridChaves();
        }

        private void EditarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BtnCadastrarChave_Click(object sender, EventArgs e)
        {

        }

        private void textBoxBusca_Click(object sender, EventArgs e)
        {
            if (textBoxBusca.Text == "Buscar")
            {
                textBoxBusca.Text = "";
            }

        }

        private void X(object sender, EventArgs e)
        {

        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            filtrosPanel.Visible = true;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtrosPanel.Visible = false;
            atualizarGridChaves();
        }


        private void TextBoxBusca_Leave(object sender, EventArgs e)
        {
            if (textBoxBusca.Text == "")
            {
                textBoxBusca.Text = "Buscar";
            }
        }

        private void TextBoxBusca_TextChanged(object sender, EventArgs e)
        {
            atualizarGridChaves();
        }

        private void Proprietario_Click(object sender, EventArgs e)
        {
            if (proprietario.Text != " ")
            {
                string codigoProp = database.selectScalar(string.Format("SELECT cod_proprietario FROM proprietario" +
                                                                        " WHERE nome = '{0}'", proprietario.Text));

                cadastroProprietario showProprietario = new cadastroProprietario(codigoProp);
                showProprietario.ShowDialog();
            }
        }

        private void ExcluirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            metroRadioButton3.Checked = true;
            metroRadioButton5.Checked = true;
            metroRadioButton9.Checked = true;
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            string codigoChaveRetirar = gridChaves.CurrentRow.Cells[5].Value.ToString();

            RetirarChave telaRetirar = new RetirarChave(codigoChaveRetirar, usuario);
            telaRetirar.ShowDialog();

            if (telaRetirar.DialogResult == DialogResult.OK)
            {
                atualizarGridChaves();
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (gridChaves.CurrentRow != null)
            {

                string codigoChave = gridChaves.CurrentRow.Cells[5].Value.ToString();


                cadastroChave editarChave = new cadastroChave(codigoChave);

                editarChave.ShowDialog();

                atualizarGridChaves();

            }
        }

        private void BtnEmprestar_Click(object sender, EventArgs e)
        {

            if (emprestimo.Text == "N/A")
            {

                CadastrarEmprestimo cadastrarEmp = new CadastrarEmprestimo(usuario, new List<string> { gridChaves.CurrentRow.Cells[5].Value.ToString() });
                cadastrarEmp.ShowDialog();
                atualizarGridChaves();
            }
            else
            {
                DevolverChave devolucao = new DevolverChave(emprestimo.Text, usuario);
                devolucao.ShowDialog();
                atualizarGridChaves();
            }

        }

        private void BtnReservar_Click(object sender, EventArgs e)
        {
            CadastroReserva reservar = new CadastroReserva(gridChaves.CurrentRow.Cells[5].Value.ToString(), usuario);
            reservar.ShowDialog();

            atualizarGridChaves();
        }

        private void GridChaves_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = gridChaves.Rows[e.RowIndex];

            if (int.Parse(row.Cells[6].Value.ToString()) > 0 && int.Parse(row.Cells[7].Value.ToString()) > 0)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 169, 122);
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(209, 112, 59);
            }
            else
            {
                if (int.Parse(row.Cells[6].Value.ToString()) > 0)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 135);
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(201, 170, 83);
                }

                if (int.Parse(row.Cells[7].Value.ToString()) > 0)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(242, 174, 174);
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(212, 55, 61);
                }
            }


        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintTags_Click(object sender, EventArgs e)
        {
            ImprimirEtiquetas imprimirTags = new ImprimirEtiquetas(gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[5].Value.ToString());
            imprimirTags.ShowDialog();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            ConfigurarRelatorioChaves configurar = new ConfigurarRelatorioChaves(usuario);
            configurar.ShowDialog();
        }

        private void gridChaves_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void gridChaves_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow linha = gridChaves.CurrentRow;

            painelInfo.Location = new Point(gridChaves.Location.X - 10, 22 * (linha.Index - gridChaves.FirstDisplayedScrollingRowIndex) + 112);


            try
            {
                codChaveReserva.Text = gridChaves.Rows[e.RowIndex].Cells[0].Value.ToString();

                DataGridViewRow row = gridChaves.Rows[e.RowIndex];
                if ((int.Parse(row.Cells[6].Value.ToString()) > 0))
                {
                    painelInfo.Visible = true;

                    //painelInfo.Location = new Point(gridChaves.Location.X + 10, Cursor.Position.Y - 145);

                    DataTable tabelaReservas = database.select(string.Format("SELECT r.cod_reserva, (CASE WHEN r.cod_proprietario is null AND r.cod_cliente is null THEN 'FUNCIONARIO'" +
                            " WHEN r.cod_proprietario is null AND r.cod_cliente is not null THEN 'CLIENTE'" +
                            " WHEN r.cod_proprietario is not null AND r.cod_cliente is null THEN 'PROPRIETARIO' END) as tipo, " +
                            " (CASE WHEN r.cod_proprietario is null AND r.cod_cliente is null" +
                            " THEN '('|| u.cod_usuario || ') - ' || u.nome_usuario" +
                            "  WHEN r.cod_proprietario is null AND r.cod_cliente is not null THEN '('|| cl.cod_cliente || ') - ' || cl.nome_cliente" +
                            " WHEN r.cod_proprietario is not null AND r.cod_cliente is null THEN '('|| p.cod_proprietario || ') - ' || p.nome  END) as tipo," +
                    " r.data_reserva, u.nome_usuario" +
                    " FROM reserva r" +
                    " LEFT JOIN cliente cl ON cl.cod_cliente = r.cod_cliente" +
                    "  LEFT JOIN usuario u ON u.cod_usuario = r.cod_usuario" +
                    "  LEFT JOIN proprietario p ON p.cod_proprietario = r.cod_proprietario" +
                    " LEFT JOIN chaves_reserva cr ON cr.cod_reserva = r.cod_reserva" +
                    " INNER JOIN chave c ON c.indice_chave = cr.cod_chave" +
                    "  WHERE c.indice_chave = '{0}' AND r.situacao = 'EM ANDAMENTO'", gridChaves.Rows[e.RowIndex].Cells[5].Value));


                    gridReserva.DataSource = tabelaReservas;

                    gridReserva.Columns[0].HeaderText = "Reserva";
                    gridReserva.Columns[1].HeaderText = "Tipo";
                    gridReserva.Columns[2].HeaderText = "Quem retirou";
                    gridReserva.Columns[3].HeaderText = "Data da reserva";
                    gridReserva.Columns[4].HeaderText = "Funcionário";


                    gridReserva.Columns[0].Width = 60;
                    gridReserva.Columns[1].Width = 80;
                    gridReserva.Columns[2].Width = 284;
                    gridReserva.Columns[3].Width = 100;
                    gridReserva.Columns[4].Width = 80;
                }
            }
            catch { }








        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            painelInfo.Visible = false;
            gridReserva.DataSource = null;
        }

        private void Chaves_Leave(object sender, EventArgs e)
        {

        }

        private void painelReservas_Leave(object sender, EventArgs e)
        {
            painelInfo.Visible = false;
        }

        private void btnAddChave_Click(object sender, EventArgs e)
        {
            cadastroChave cadastro = new cadastroChave();

            cadastro.ShowDialog();

            if (cadastro.DialogResult == DialogResult.Yes)
            {
                atualizarGridChaves();
            }
        }

        private void GridChaves_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridChaves_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void gridChaves_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 69 && painelEmprestimos.Visible == false)
            {
                atualizarGridEmprestimos();
            }
            else if (e.KeyValue == 69 && painelEmprestimos.Visible == true)
            {
                painelEmprestimos.Visible = false;
            }
        }

        void atualizarGridEmprestimos()
        {
            painelEmprestimos.Location = new Point(22, 9);
            try
            {
                DataTable tabelaEmprestimos = new DataTable();

                tabelaEmprestimos = database.select(string.Format("SELECT e.cod_emprestimo,  " +
                                                                "(CASE WHEN e.cod_proprietario is null AND e.cod_cliente is null THEN '[' || u.cod_usuario || '] - ' || u.nome_usuario || ' (' ||'FUNCIONARIO' || ')'  " +
                                                                    " WHEN e.cod_proprietario is null AND e.cod_cliente is not null THEN '[' || cl.cod_cliente || '] - ' || cl.nome_cliente || ' (' || 'CLIENTE' || ')' " +
                                                                    " WHEN e.cod_proprietario is not null AND e.cod_cliente is null THEN '[' || p.cod_proprietario || '] - ' || p.nome || ' (' || 'PROPRIETÁRIO' || ')' END) as tipo," +
                                                                    "  e.data_retirada, e.data_entrega, " +
                                                                   " (CASE WHEN e.data_entrega is null THEN 'EM ANDAMENTO' ELSE 'FINALIZADO' END) as situacao " +
                                                                   " FROM emprestimo e " +
                                                                   " INNER JOIN chaves_emprestimo ce ON ce.cod_emprestimo = e.cod_emprestimo" +
                                                                   " INNER JOIN chave c ON c.indice_chave = ce.cod_chave" +
                                                                   " LEFT JOIN cliente cl ON cl.cod_cliente = e.cod_cliente" +
                                                                   " LEFT JOIN usuario u ON u.cod_usuario = e.cod_usuario" +
                                                                   " LEFT JOIN proprietario p ON p.cod_proprietario = e.cod_proprietario" +
                                                                   " WHERE ce.cod_chave = {0}" +
                                                                   " ORDER BY situacao, e.data_retirada", gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[5].Value.ToString()));

                gridEmprestimos.DataSource = tabelaEmprestimos;

                gridEmprestimos.Columns[0].HeaderText = "Código";
                gridEmprestimos.Columns[1].HeaderText = "Quem Retirou";
                gridEmprestimos.Columns[2].HeaderText = "Data Retirada";
                gridEmprestimos.Columns[3].HeaderText = "Data Entrega";
                gridEmprestimos.Columns[4].HeaderText = "Situação";

                gridEmprestimos.Columns[0].Width = 40;
                gridEmprestimos.Columns[1].Width = 225;
                gridEmprestimos.Columns[2].Width = 110;
                gridEmprestimos.Columns[3].Width = 110;
                gridEmprestimos.Columns[4].Width = 109;

                painelEmprestimos.Visible = true;
                painelInfo.Visible = false;
            }
            catch { }


        }

        private void gridEmprestimos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = gridEmprestimos.Rows[e.RowIndex];

            //MessageBox.Show(row.Cells[4].Value.ToString());
            if (row.Cells[4].Value.ToString() == "EM ANDAMENTO")
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(206, 242, 116);
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(126, 161, 39);
            }
        }

        private void gridEmprestimos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 69 && painelEmprestimos.Visible == true)
            {
                painelEmprestimos.Visible = false;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            painelEmprestimos.Visible = false;
            gridEmprestimos.DataSource = null;
        }

        private void gridEmprestimos_SelectionChanged(object sender, EventArgs e)
        {

            
            if(gridEmprestimos.SelectedRows.Count == 0)
            {
                descricao.Text = "";
                funcionario.Text = "";
                dataRetirada.Text = "";
                previsEntrega.Text = "";
                dataEntrega.Text = "";
                funcionarioDevolucao.Text = "";
                codImobEmprestimos.Text = "";
                codChave.Text = "";
                qtdChaves.Text = "";
                qtdControles.Text = "";
                dadosRetirante.Text = "";
                contato.Text = "";

            }
            else
            {
                try
                {
                    codChavePainelEmprestimo.Text = gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[0].Value.ToString();
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
                        " WHERE cod_emprestimo = '{0}'", gridEmprestimos.CurrentRow.Cells[0].Value.ToString()));


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
                catch
                {
                    descricao.Text = "";
                    funcionario.Text = "";
                    dataRetirada.Text = "";
                    previsEntrega.Text = "";
                    dataEntrega.Text = "";
                    funcionarioDevolucao.Text = "";
                    codImobEmprestimos.Text = "";
                    codChave.Text = "";
                    qtdChaves.Text = "";
                    qtdControles.Text = "";
                    dadosRetirante.Text = "";
                    contato.Text = "";
                }

                try
                {
                    DataTable dadosChaves = new DataTable();


                    dadosChaves = database.select(string.Format("SELECT c.cod_imob, c.cod_chave, ce.quant_chaves, ce.quant_controles " +
                                                                " FROM chave c " +
                                                                " INNER JOIN chaves_emprestimo ce ON ce.cod_chave = c.indice_chave " +
                                                                " WHERE c.indice_chave = '{0}' AND ce.cod_emprestimo = '{1}'",
                                                                 gridChaves.CurrentRow.Cells[5].Value.ToString(), gridEmprestimos.CurrentRow.Cells[0].Value.ToString()));

                    foreach (DataRow row in dadosChaves.Rows)
                    {
                        codImobEmprestimos.Text = row[0].ToString();
                        codChave.Text = row[1].ToString();
                        qtdChaves.Text = row[2].ToString();
                        qtdControles.Text = row[3].ToString();
                    }

                }
                catch
                {
                    codImobEmprestimos.Text = "";
                    codChave.Text = "";
                    qtdChaves.Text = "";
                    qtdControles.Text = "";
                    descricao.Text = "";
                    funcionario.Text = "";
                    dataRetirada.Text = "";
                    previsEntrega.Text = "";
                    dataEntrega.Text = "";
                    funcionarioDevolucao.Text = "";
                    dadosRetirante.Text = "";
                    contato.Text = "";
                }


            }


        }
    }
}
