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
    public partial class Reserva : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();
        DateTime dataHoje = DateTime.Now;
        string usuario = "";
        public Reserva(string user)
        {
            InitializeComponent();

            usuario = user;
        }

        private void atualizarGrid()
        {
            DataTable tabelaReserva = new DataTable();

            string situacao = groupMenuSup.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string tipo = groupTipoReserva.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string busca = textBoxBusca.Text;

            string dataReserva = string.Format(" AND data_reserva BETWEEN '{0}' AND '{1}'", dpMinDataReserva.Value, dpMaxDataReserva.Value);

            if (!checkDataReserva.Checked) { dataReserva = ""; }

            if (situacao == "TODOS") { situacao = ""; }
            if (tipo == "TODOS") { tipo = ""; }
            if (busca == "Buscar") { busca = ""; }

            tabelaReserva = database.select(string.Format("SELECT DISTINCT r.cod_reserva,  r.data_reserva, r.situacao" +
                                                           " FROM reserva r" +
                                                           " INNER JOIN chaves_reserva cr ON cr.cod_reserva = r.cod_reserva" +
                                                           " LEFT JOIN chave c ON c.indice_chave = cr.cod_chave " +
                                                           " LEFT JOIN proprietario p ON p.cod_proprietario = r.cod_proprietario " +
                                                           " LEFT JOIN cliente cl ON cl.cod_cliente = r.cod_cliente " +
                                                           " WHERE(r.cod_reserva::TEXT ILIKE '%{0}%' OR c.cod_chave::TEXT ILIKE '%{0}%' OR c.rua  ILIKE '%{0}%' OR c.bairro  ILIKE '%{0}%' OR " +
                                                           " c.cidade  ILIKE '%{0}%' OR cl.cod_cliente::TEXT ILIKE " +
                                                           " '%{0}%' OR cl.nome_cliente ILIKE '%{0}%' OR p.nome ILIKE '%{0}%')" +
                                                           " AND (r.situacao ILIKE '%{1}%' {2}" +
                                                                "  AND (CASE WHEN r.cod_proprietario is null AND r.cod_cliente is null THEN 'FUNCIONARIO' " +
                                                                " WHEN r.cod_proprietario is null AND r.cod_cliente is not null THEN 'CLIENTE' " +
                                                                " WHEN r.cod_proprietario is not null AND r.cod_cliente is null THEN 'PROPRIETARIO' END) ILIKE '%{3}%')",
                                                                busca, situacao, dataReserva, tipo));

            gridReserva.DataSource = tabelaReserva.DefaultView;

            gridReserva.Columns[0].HeaderText = "Reserva";
            gridReserva.Columns[1].HeaderText = "Data Reserva";
            gridReserva.Columns[2].HeaderText = "Situação";


            gridReserva.Columns[0].Width = 60;
            gridReserva.Columns[1].Width = 137;
            gridReserva.Columns[2].Width = 136;
        }

        private void Reserva_Load(object sender, EventArgs e)
        {
            atualizarGrid();
        }

        private void textBoxBusca_TextChanged(object sender, EventArgs e)
        {
            atualizarGrid();
        }

        private void radioSuperior(object sender, EventArgs e)
        {
            atualizarGrid();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            int contErro = 0;
            string msgErro = "A data mínima não pode ser superior à data máxima nos seguintes campos!\n\n";

            if (dpMinDataReserva.Value > dpMaxDataReserva.Value && checkDataReserva.Checked)
            {
                msgErro += "- Data de Retirada";
                contErro++;
            }

            if (contErro != 0)
            {
                Message popup = new Message(msgErro, "", "erro", "confirma");
                popup.ShowDialog();
            }
            else
            {
                filtrosPanel.Visible = false;
                atualizarGrid();
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            metroRadioButton1.Checked = true;
            checkDataReserva.Checked = false;

            dpMaxDataReserva.MaxDate = dataHoje;
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            filtrosPanel.Visible = true;
        }

        private void checkDataReserva_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDataReserva.Checked)
            {
                dpMinDataReserva.Enabled = true;
                dpMaxDataReserva.Enabled = true;
            }
            else
            {
                dpMinDataReserva.Enabled = false;
                dpMaxDataReserva.Enabled = false;
            }
        }

        private void gridReserva_SelectionChanged(object sender, EventArgs e)
        {

            if (gridReserva.CurrentRow != null)
            {
                btnExcluir.Enabled = true;
                btnExcluir.Image = Properties.Resources.Delete;
                btnEmprestar.Enabled = true;
                btnEmprestar.Image = Properties.Resources.ChaveEmprestar;

                DataTable dadosReserva = new DataTable();

                dadosReserva = database.select(string.Format("SELECT c.cod_imob, c.cod_chave, r.situacao, " +
                                                             " (CASE WHEN r.cod_proprietario is null AND r.cod_cliente is null THEN 'FUNCIONARIO' " +
                                                                          " WHEN r.cod_proprietario is null AND r.cod_cliente is not null THEN 'CLIENTE' " +
                                                                          " WHEN r.cod_proprietario is not null AND r.cod_cliente is null THEN 'PROPRIETARIO' END) as tipo, " +
                                                                      " '(' || cl.cod_cliente || ') - ' || cl.nome_cliente, cl.contato_principal || ' / ' || cl.contato_secundario, " +
                                                                      " '(' || p.cod_proprietario || ') - ' || p.nome as proprietario, p.contato, u.nome_usuario, r.descricao, " +
                                                                      " r.data_reserva, " +
                                                                      " (CASE WHEN(SELECT COUNT(*) FROM emprestimo WHERE cod_chave = '{0}' AND data_entrega is null) = 0 THEN 'EMPRESTADA' " +
                                                                       " ELSE 'LIVRE' END) " +
                                                                       " FROM reserva r " +
                                                                       " LEFT JOIN chave c ON c.indice_chave = r.cod_chave " +
                                                                       " LEFT JOIN proprietario p ON p.cod_proprietario = r.cod_proprietario " +
                                                                       " LEFT JOIN cliente cl ON cl.cod_cliente = r.cod_cliente " +
                                                                       " LEFT JOIN usuario u ON u.cod_usuario = r.cod_usuario" +
                                                                       " WHERE r.cod_reserva = '{1}'", gridReserva.CurrentRow.Cells[6].Value.ToString(), gridReserva.CurrentRow.Cells[0].Value.ToString()));


                foreach (DataRow row in dadosReserva.Rows)
                {
                    codigoImob.Text = row[0].ToString();
                    codChave.Text = row[1].ToString();
                    sitReserva.Text = row[2].ToString();

                    if (row[3].ToString() == "FUNCIONARIO")
                    {
                        dadosReservante.Text = string.Format("{0} [{1}]", row[8].ToString(), row[3].ToString());

                    }
                    else if (row[3].ToString() == "CLIENTE")
                    {
                        dadosReservante.Text = string.Format("{0} [{1}]", row[4].ToString(), row[3].ToString());
                        contato.Text = row[5].ToString();
                    }
                    else
                    {
                        dadosReservante.Text = string.Format("{0} [{1}]", row[6].ToString(), row[3].ToString());
                        contato.Text = row[7].ToString();
                    }
                    descricao.Text = row[9].ToString();
                    dataReserva.Text = row[10].ToString();
                    situacaoChave.Text = row[11].ToString();
                    funcionario.Text = row[8].ToString();
                }
            }
            else
            {
                codigoImob.Text = "";
                codChave.Text = "";
                sitReserva.Text = "";
                dadosReservante.Text = "";
                contato.Text = "";
                descricao.Text = "";
                dataReserva.Text = "";
                situacaoChave.Text = "";
                funcionario.Text = "";

                btnExcluir.Enabled = false;
                btnExcluir.Image = Properties.Resources.DeleteGray;
                btnEmprestar.Enabled = false;
                btnEmprestar.Image = Properties.Resources.ChaveEmprestarGray;
            }
            
        }

        private void gridReserva_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = gridReserva.Rows[e.RowIndex];

            if(row.Cells[5].Value.ToString() == "LIVRE" && row.Cells[4].Value.ToString() != "FINALIZADO")
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(199, 237, 166);
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(131, 173, 94);
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            Message telaMsg = new Message("Você tem certeza que quer excluir esta reserva?", "Confirmação", "aviso", "escolha");
            telaMsg.ShowDialog();

            if(telaMsg.DialogResult == DialogResult.Yes)
            {
                database.update(string.Format("UPDATE reserva" +
                                                  " SET situacao = 'FINALIZADO'" +
                                                  " WHERE cod_reserva = '{0}'", gridReserva.CurrentRow.Cells[0].Value.ToString()));
                atualizarGrid();
            }

           
        }

        private void BtnEmprestar_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lista = new List<string>();

                foreach (DataGridViewRow row in gridChavesReserva.Rows)
                {
                    lista.Add(row.Cells[2].Value.ToString());
                }

                CadastrarEmprestimo emprestimo = new CadastrarEmprestimo(usuario, gridReserva.CurrentRow.Cells[0].Value.ToString(),
                    lista);
                emprestimo.ShowDialog();

                atualizarGrid();
            }
            catch
            {
                Message msg = new Message("Opção indisponível no momento! Tente novamente mais tarde.",
                    "Erro", "erro", "confirma");

                msg.ShowDialog();
            }


        }

        private void GridReserva_SelectionChanged_1(object sender, EventArgs e)
        {
            if (gridReserva.CurrentRow != null)
            {
                btnExcluir.Enabled = true;
                btnExcluir.Image = Properties.Resources.Delete;
                btnEmprestar.Enabled = true;
                btnEmprestar.Image = Properties.Resources.ChaveEmprestar;
                atualizarGridChavesReserva();


                try
                {
                    DataTable dadosEmprestimo = new DataTable();


                    dadosEmprestimo = database.select(string.Format("" +
                        "SELECT  " +
                        " situacao, " +
                        " (CASE WHEN r.cod_proprietario is null AND r.cod_cliente is null THEN 'FUNCIONARIO' " +
                              "  WHEN r.cod_proprietario is null AND r.cod_cliente is not null THEN 'CLIENTE' " +
                               " WHEN r.cod_proprietario is not null AND r.cod_cliente is null THEN 'PROPRIETARIO' END) as tipo, " +
                               " '(' || cl.cod_cliente || ') - ' || cl.nome_cliente, cl.contato_principal || ' / ' || cl.contato_secundario, " +
                               " '(' || p.cod_proprietario || ') - ' || p.nome as proprietario, p.contato, u.nome_usuario, r.descricao, " +
                               "  r.data_reserva " +
                        " FROM reserva r " +
                        " LEFT JOIN cliente cl ON cl.cod_cliente = r.cod_cliente " +
                        " LEFT JOIN usuario u ON u.cod_usuario = r.cod_usuario " +
                        " LEFT JOIN proprietario p ON p.cod_proprietario = r.cod_proprietario" +
                        " WHERE cod_reserva = '{0}'", gridReserva.CurrentRow.Cells[0].Value.ToString()));


                    foreach (DataRow row in dadosEmprestimo.Rows)
                    {


                        sitReserva.Text = row[0].ToString();

                        if (row[1].ToString() == "FUNCIONARIO")
                        {
                            dadosReservante.Text = string.Format("{0} [{1}]", row[5].ToString(), row[1].ToString());

                        }
                        else if (row[1].ToString() == "CLIENTE")
                        {
                            dadosReservante.Text = string.Format("{0} [{1}]", row[2].ToString(), row[1].ToString());
                            contato.Text = row[3].ToString();
                        }
                        else
                        {
                            dadosReservante.Text = string.Format("{0} [{1}]", row[4].ToString(), row[1].ToString());
                            contato.Text = row[5].ToString();
                        }

                        descricao.Text = row[7].ToString();
                        funcionario.Text = row[6].ToString();
                        dataReserva.Text = row[8].ToString();

                    }
                }
                catch { }
            }
            else
            {
                codigoImob.Text = "";
                codChave.Text = "";
                sitReserva.Text = "";
                dadosReservante.Text = "";
                contato.Text = "";
                descricao.Text = "";
                dataReserva.Text = "";
                situacaoChave.Text = "";
                funcionario.Text = "";

                btnExcluir.Enabled = false;
                btnExcluir.Image = Properties.Resources.DeleteGray;
                btnEmprestar.Enabled = false;
                btnEmprestar.Image = Properties.Resources.ChaveEmprestarGray;
            }


        }

        void atualizarGridChavesReserva()
        {
            DataTable dadosEmprestimo = new DataTable();

            try
            {

                dadosEmprestimo = database.select(string.Format("SELECT c.cod_chave," +
                                                               " c.rua || ', ' || c.numero || (CASE WHEN c.complemento is null OR c.complemento = '' THEN '' ELSE ' - ' || c.complemento END)" +
                                                               " as endereco, c.indice_chave," +
                                                               " (CASE WHEN(SELECT COUNT(*) " +
                                                            "      FROM emprestimo e" +
                                                            "      INNER JOIN chaves_emprestimo ce ON e.cod_emprestimo = ce.cod_emprestimo" +
                                                            "      WHERE ce.cod_chave = c.indice_chave AND data_entrega is null) != 0 THEN 'EMPRESTADA' " +
                                                                       " ELSE 'LIVRE' END), c.situacao" +
                                                               " FROM chave c" +
                                                               " INNER JOIN chaves_reserva cr ON cr.cod_chave = c.indice_chave" +
                                                               " INNER JOIN reserva r ON r.cod_reserva = cr.cod_reserva" +
                                                               " WHERE r.cod_reserva = '{0}'" +
                                                               " ORDER BY c.cod_chave", gridReserva.CurrentRow.Cells[0].Value.ToString()));

                if (dadosEmprestimo.Rows.Count == 0)
                {
                    dadosEmprestimo.Clear();
                    gridChavesReserva.DataSource = null;
                    gridChavesReserva.Rows.Clear();

                }
                else
                {
                    gridChavesReserva.DataSource = dadosEmprestimo;

                    gridChavesReserva.Columns[0].Width = 40;
                    gridChavesReserva.Columns[1].Width = 225;
                    gridChavesReserva.Columns[2].Visible = false;
                    gridChavesReserva.Columns[3].Visible = false;
                    gridChavesReserva.Columns[4].Visible = false;



                    gridChavesReserva.Columns[0].HeaderText = "Chave";
                    gridChavesReserva.Columns[1].HeaderText = "Endereço";
                }

            }
            catch
            {
                dadosEmprestimo.Clear();
                gridChavesReserva.DataSource = null;
                gridChavesReserva.Rows.Clear();
            }
            //DataTable dadosEmprestimo = new DataTable();

            //try
            //{

            //    dadosEmprestimo = database.select(string.Format("SELECT c.cod_chave," +
            //                                                   " c.rua || ', ' || c.numero || (CASE WHEN c.complemento is null OR c.complemento = '' THEN '' ELSE ' - ' || c.complemento END)" +
            //                                                   " as endereco, c.indice_chave" +
            //                                                   " FROM chave c" +
            //                                                   " INNER JOIN chaves_emprestimo ce ON ce.cod_chave = c.indice_chave" +
            //                                                   " INNER JOIN emprestimo e ON e.cod_emprestimo = ce.cod_emprestimo" +
            //                                                   " WHERE e.cod_emprestimo = '{0}'" +
            //                                                   " ORDER BY c.cod_chave", gridEmprestimo.CurrentRow.Cells[0].Value.ToString()));

            //    if (dadosEmprestimo.Rows.Count == 0)
            //    {
            //        dadosEmprestimo.Clear();
            //        gridChavesEmprestimo.DataSource = null;
            //        gridChavesEmprestimo.Rows.Clear();

            //    }
            //    else
            //    {
            //        gridChavesEmprestimo.DataSource = dadosEmprestimo;

            //        gridChavesEmprestimo.Columns[0].Width = 40;
            //        gridChavesEmprestimo.Columns[1].Width = 225;
            //        gridChavesEmprestimo.Columns[2].Visible = false;

            //        gridChavesEmprestimo.Columns[0].HeaderText = "Chave";
            //        gridChavesEmprestimo.Columns[1].HeaderText = "Endereço";
            //    }

            //}
            //catch
            //{
            //    dadosEmprestimo.Clear();
            //    gridChavesEmprestimo.DataSource = null;
            //    gridChavesEmprestimo.Rows.Clear();
            //}

        }

        private void GridChavesReserva_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                DataTable dadosChaves = new DataTable();

                
                dadosChaves = database.select(string.Format("SELECT c.cod_imob, c.cod_chave, " +
                                                            " (CASE WHEN(SELECT COUNT(*) " +
                                                            "      FROM emprestimo e" +
                                                            "      INNER JOIN chaves_emprestimo ce ON e.cod_emprestimo = ce.cod_emprestimo" +
                                                            "      WHERE ce.cod_chave = c.indice_chave AND data_entrega is null) != 0 THEN 'EMPRESTADA' " +
                                                                       " ELSE 'LIVRE' END)" +
                                                            " FROM chave c " +
                                                            " INNER JOIN chaves_reserva cr ON cr.cod_chave = c.indice_chave " +
                                                            " WHERE c.indice_chave = '{0}' AND cr.cod_reserva = '{1}'",
                                                             gridChavesReserva.CurrentRow.Cells[2].Value.ToString(), gridReserva.CurrentRow.Cells[0].Value.ToString()));

                foreach (DataRow row in dadosChaves.Rows)
                {
                    codigoImob.Text = row[0].ToString();
                    codChave.Text = row[1].ToString();
                    situacaoChave.Text = row[2].ToString();
                    
                }

            }
            catch { }
        }

        private void GridReserva_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void GridChavesReserva_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                DataGridViewRow row = gridChavesReserva.Rows[e.RowIndex];
                string situacao = gridChavesReserva.Rows[e.RowIndex].Cells[3].Value.ToString();
                string sitChave = gridChavesReserva.Rows[e.RowIndex].Cells[4].Value.ToString();

                if (situacao == "LIVRE" && sitChave == "DISPONIVEL")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(182, 255, 145);
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(105, 184, 66);

                    int contLivres = 0;

                    foreach (DataGridViewRow linha in gridChavesReserva.Rows)
                    {
                        if (linha.Cells[3].Value.ToString() == "LIVRE" && linha.Cells[4].Value.ToString() == "DISPONIVEL")
                        {
                            contLivres++;
                        }
                    }


                    if (contLivres == gridChavesReserva.Rows.Count)
                    {
                        gridReserva.CurrentRow.DefaultCellStyle.BackColor = Color.FromArgb(182, 255, 145);
                        gridReserva.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(105, 184, 66);
                    }
                }
                
            }
            catch
            {

            }
            

        }

        private void GridReserva_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
