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
    public partial class Cliente : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();

        public Cliente()
        {
            InitializeComponent();
        }

        private void atualizarClientes()
        {
            gridCliente.DataSource = null;
            gridCliente.Rows.Clear();
            gridCliente.Columns.Clear();

            DataTable clientes = new DataTable();
            clientes.Rows.Clear();

            clientes = database.select(string.Format("SELECT c.cod_cliente, c.nome_cliente, c.email, c.contato_principal, c.contato_secundario," +
                                                        " (SELECT COUNT(cod_emprestimo)" +
                                                                " FROM emprestimo" +
                                                                " WHERE cod_cliente = c.cod_cliente)  " +
                                                        " FROM cliente c  " +
                                                        " LEFT JOIN emprestimo e ON e.cod_cliente = c.cod_cliente" +
                                                        " LEFT JOIN chaves_emprestimo ce ON ce.cod_emprestimo = e.cod_emprestimo" +
                                                        " LEFT JOIN chave ch ON ch.indice_chave = ce.cod_chave" +
                                                        " WHERE c.cod_cliente::text || 'c' ILIKE '%{0}%' OR c.nome_cliente ILIKE '%{0}%' OR unaccent(c.nome_cliente) ILIKE '%{0}%' OR" +
                                                        " email ILIKE '%{0}%' OR unaccent(email) ILIKE '%{0}%' OR contato_principal ILIKE '%{0}%' OR unaccent(contato_principal) ILIKE '%{0}%'" +
                                                        " OR  contato_secundario ILIKE '%{0}%' OR unaccent(contato_secundario) ILIKE '%{0}%' OR ch.rua ILIKE '%{0}%' OR unaccent(ch.rua) ILIKE" +
                                                        " '%{0}%' OR ch.cond ILIKE '%{0}%' OR ch.cond ILIKE '%{0}%'" +
                                                        " GROUP BY c.cod_cliente" +
                                                        " ORDER BY c.nome_cliente", boxBusca.Text));

            gridCliente.DataSource = clientes.DefaultView;

            gridCliente.Columns[0].HeaderText = "Cód";
            gridCliente.Columns[1].HeaderText = "Nome do Cliente";
            gridCliente.Columns[2].HeaderText = "Email";
            gridCliente.Columns[3].HeaderText = "Contato 1";
            gridCliente.Columns[4].HeaderText = "Contato 2";
            gridCliente.Columns[5].HeaderText = "Emprést";

            DataGridViewImageColumn cellImageEdit = new DataGridViewImageColumn();
            cellImageEdit.Image = new Bitmap(Properties.Resources.Edit);

            gridCliente.Columns.Insert(0, cellImageEdit);


            gridCliente.Columns[0].Width = 30;
            gridCliente.Columns[1].Width = 30;
            gridCliente.Columns[2].Width = 210;
            gridCliente.Columns[3].Width = 150;
            gridCliente.Columns[4].Width = 80;
            gridCliente.Columns[5].Width = 80;
            gridCliente.Columns[6].Width = 50;

            // gridCliente.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            

          
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            atualizarClientes();
        }

        private void GridCliente_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            if(e.ColumnIndex == 0)
            {
                gridCliente.Cursor = Cursors.Hand;
            }
            else
            {
                gridCliente.Cursor = Cursors.Arrow;
            }
        }

        private void GridCliente_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                CadastroCliente cadastrar = new CadastroCliente(gridCliente.Rows[e.RowIndex].Cells[1].Value.ToString());
                cadastrar.ShowDialog();

                atualizarClientes();
            }


        
        }

        private void GridCliente_SelectionChanged(object sender, EventArgs e)
        {
            zerarPainelEmprestimos();
            try
            {
                DataTable tabelaDados = new DataTable();

                tabelaDados = database.select(string.Format("" +
                    "SELECT e.cod_emprestimo, e.data_retirada, e.entrega_prevista," +
                    " e.data_entrega, u.nome_usuario, u2.nome_usuario" +
                    " FROM emprestimo e" +
                    " INNER JOIN usuario u ON u.cod_usuario = e.cod_usuario" +
                    " LEFT JOIN usuario u2 ON u2.cod_usuario = e.usuario_devolucao" +
                    " WHERE cod_cliente = '{0}'", gridCliente.Rows[gridCliente.CurrentRow.Index].Cells[1].Value.ToString()));

                gridEmprestimos.DataSource = tabelaDados;


                gridEmprestimos.Columns[0].Width = 40;
                gridEmprestimos.Columns[1].Width = 100;
                gridEmprestimos.Columns[2].Width = 100;
                gridEmprestimos.Columns[3].Width = 100;
                gridEmprestimos.Columns[4].Width = 147;
                gridEmprestimos.Columns[5].Width = 147;

                gridEmprestimos.Columns[0].HeaderText = "Código Empréstimo";
                gridEmprestimos.Columns[1].HeaderText = "Data de Retirada";
                gridEmprestimos.Columns[2].HeaderText = "Prev Entrega";
                gridEmprestimos.Columns[3].HeaderText = "Data Entrega";
                gridEmprestimos.Columns[4].HeaderText = "Func. Entrega";
                gridEmprestimos.Columns[5].HeaderText = "Func. Devolução";
            }
            catch (Exception erro)
            {
            }
            
                                                  
        }

        private void boxBusca_TextChanged(object sender, EventArgs e)
        {
            atualizarClientes();
        }

        private void gridEmprestimos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            painelEmprestimo.Location = new Point(23, 16);
            painelEmprestimo.Visible = true;


            try
            {
                DataTable dadosEmprestimo = new DataTable();
                dadosEmprestimo = database.select(string.Format("SELECT c.cod_chave, c.cod_imob," +
                                                               " c.rua || ', ' || c.numero || (CASE WHEN c.complemento is null OR c.complemento = '' THEN '' ELSE ' - ' || c.complemento END) || " +
                                                               " (CASE WHEN c.cond IS NULL OR c.cond = '' THEN '' ELSE ' (' || c.cond || ')' END) as endereco, c.situacao, c.indice_chave" +
                                                               " FROM chave c" +
                                                               " INNER JOIN chaves_emprestimo ce ON ce.cod_chave = c.indice_chave" +
                                                               " INNER JOIN emprestimo e ON e.cod_emprestimo = ce.cod_emprestimo" +
                                                               " WHERE e.cod_emprestimo = '{0}'" +
                                                               " ORDER BY c.cod_chave", gridEmprestimos.CurrentRow.Cells[0].Value.ToString()));

                if (dadosEmprestimo.Rows.Count == 0)
                {
                    dadosEmprestimo.Clear();
                    gridChavesEmp.DataSource = null;
                    gridChavesEmp.Rows.Clear();

                }
                else
                {
                    gridChavesEmp.DataSource = dadosEmprestimo;

                    gridChavesEmp.Columns[0].Width = 40;
                    gridChavesEmp.Columns[1].Width = 100;
                    gridChavesEmp.Columns[2].Width = 320;
                    gridChavesEmp.Columns[3].Width = 129;
                    gridChavesEmp.Columns[4].Visible = false;

                    gridChavesEmp.Columns[0].HeaderText = "Chave";
                    gridChavesEmp.Columns[1].HeaderText = "Cod Imob";
                    gridChavesEmp.Columns[2].HeaderText = "Endereço";
                    gridChavesEmp.Columns[3].HeaderText = "Sit Imóvel";


                   
                }



            try
            {
                DataTable dadosEmp = new DataTable();


                dadosEmp = database.select(string.Format("" +
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


                foreach (DataRow row in dadosEmp.Rows)
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
            catch
            {
                gridChavesEmp.DataSource = null;
                gridChavesEmp.Rows.Clear();
            }
        }

        private void gridEmprestimo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dadosChaves = new DataTable();


                dadosChaves = database.select(string.Format("SELECT c.cod_imob, c.cod_chave, ce.quant_chaves, ce.quant_controles," +
                                                            " c.rua || ', ' || c.numero || (CASE WHEN c.complemento is null OR c.complemento = '' THEN '' ELSE ' - ' || c.complemento END) || " +
                                                               " (CASE WHEN c.cond IS NULL OR c.cond = '' THEN '' ELSE ' (' || c.cond || ')' END) as endereco" +
                                                            " FROM chave c " +
                                                            " INNER JOIN chaves_emprestimo ce ON ce.cod_chave = c.indice_chave " +
                                                            " WHERE c.indice_chave = '{0}' AND ce.cod_emprestimo = '{1}'",
                                                             gridChavesEmp.CurrentRow.Cells[4].Value.ToString(), gridEmprestimos.CurrentRow.Cells[0].Value.ToString()));

                foreach (DataRow row in dadosChaves.Rows)
                {
                    codImobEmprestimos.Text = row[0].ToString();
                    codChave.Text = row[1].ToString();
                    qtdChaves.Text = row[2].ToString();
                    qtdControles.Text = row[3].ToString();
                    endereco.Text = row[4].ToString();
                }
            }
            catch { }
            
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            zerarPainelEmprestimos();
        }
        void zerarPainelEmprestimos()
        {
            painelEmprestimo.Visible = false;

            sitEmprestimo.Text = "";
            dadosRetirante.Text = "";
            contato.Text = "";
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

            gridChavesEmp.DataSource = null;
        }

        private void GridEmprestimos_SelectionChanged(object sender, EventArgs e)
        {
            zerarPainelEmprestimos();
        }
    }
}
