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
            if(gridChaves.CurrentRow == null)
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
            
            if(textoBusca == "Buscar") { textoBusca = ""; }
            if (filtroSitImovel == "TODOS") { filtroSitImovel = ""; }
            if (filtroSitChave == "TODOS") { filtroSitChave = ""; }
            if (typeImovel == "TODOS") { typeImovel = ""; }
            if (filtro == "TODOS") { filtro = ""; }

            
            try
            {
                chaves = database.select(string.Format("SELECT c.cod_chave, c.cod_imob, c.rua || ', ' || c.numero as endereco, c.bairro, c.situacao_imovel, c.indice_chave," +
                                             " (CASE WHEN r.cod_reserva is null THEN '' ELSE 'RESERVADO' END)" +
                                             " FROM chave C" +
                                             " LEFT JOIN reserva r ON r.cod_chave = c.indice_chave" +
                                             " LEFT JOIN proprietario p ON p.cod_proprietario = c.proprietario " +
                                             " WHERE (rua ILIKE '%{0}%' OR bairro ILIKE '%{0}%' OR cidade ILIKE '%{0}%' OR estado ILIKE '%{0}%' OR" +
                                             " numero  ILIKE '%{0}%' OR complemento ILIKE '%{0}%' OR cod_imob ILIKE '%{0}%' OR p.nome ILIKE '%{0}%') AND" +
                                             " (finalidade ILIKE '%{1}%' AND situacao ILIKE '{2}%' AND situacao_imovel ILIKE '{3}%' AND " +
                                             "  tipo_imovel ILIKE '%{4}%')" +
                                             " ORDER BY situacao_imovel, rua, cod_imob", textoBusca, filtro, filtroSitChave,
                                              filtroSitImovel, typeImovel));
               

                gridChaves.DataSource = chaves;

                gridChaves.Columns[0].HeaderText = "Código";
                gridChaves.Columns[1].HeaderText = "Cód Imob";
                gridChaves.Columns[2].HeaderText = "Endereço";
                gridChaves.Columns[3].HeaderText = "Bairro";
                gridChaves.Columns[4].HeaderText = "Situação";
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
                    gridChaves.Columns[4].HeaderText = "Situação";
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

                    if(proprietario.Text != " ")
                    {
                        proprietario.Cursor = Cursors.Hand;
                    }
                    

                }

                
            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.Message);
            }


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

        private void GridChaves_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
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
                        sitImovel.Text = row[13].ToString();
                        endereco.Text = string.Format("{0}, {1} - {2} - {3}/{4} [{5}]", row[1].ToString(),
                            row[5].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(),
                            row[6].ToString());
                        proprietario.Text = row[15].ToString();
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
                                            " INNER JOIN chave c ON c.indice_chave = e.cod_chave" +
                                            " WHERE e.cod_chave = {0} AND e.data_entrega is null", codigoChave));
                        emprestimo.Text = codEmprestimo;
                        emprestimo.Cursor = Cursors.Hand;

                    }
                    catch (NullReferenceException)
                    {
                        emprestimo.Text = "N/A";
                        emprestimo.Cursor = Cursors.Default;
                    }

                }
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
            cadastroChave cadastro = new cadastroChave();

            cadastro.ShowDialog();

            if(cadastro.DialogResult == DialogResult.Yes)
            {
                atualizarGridChaves();
            }
        }

        private void textBoxBusca_Click(object sender, EventArgs e)
        {
            if(textBoxBusca.Text == "Buscar")
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
            if(textBoxBusca.Text == "")
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
            if(proprietario.Text != " ")
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

        private void GridChaves_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            string codigoChaveRetirar = gridChaves.CurrentRow.Cells[5].Value.ToString();

            RetirarChave telaRetirar = new RetirarChave(codigoChaveRetirar);
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

            }
        }

        private void BtnEmprestar_Click(object sender, EventArgs e)
        {
            if(emprestimo.Text == "N/A")
            {
                CadastrarEmprestimo cadastrarEmp = new CadastrarEmprestimo(usuario, gridChaves.CurrentRow.Cells[5].Value.ToString());
                cadastrarEmp.ShowDialog();
                atualizarGridChaves();
            }
            else
            {
                DevolverChave devolucao = new DevolverChave(emprestimo.Text);
                devolucao.ShowDialog();
                atualizarGridChaves();
            }
           
        }

        private void BtnReservar_Click(object sender, EventArgs e)
        {
            ReservarChave reservar = new ReservarChave(gridChaves.CurrentRow.Cells[5].Value.ToString(), usuario);
            reservar.ShowDialog();

            atualizarGridChaves();
        }

        private void GridChaves_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = gridChaves.Rows[e.RowIndex];

            if(row.Cells[6].Value.ToString() == "RESERVADO")
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 135);
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
