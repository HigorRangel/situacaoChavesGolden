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

            clientes = database.select(string.Format("" +
                "SELECT c.cod_cliente, c.nome_cliente, c.email, c.contato_principal, c.contato_secundario, COUNT(e.cod_emprestimo) " +
                 " FROM cliente c " +
                 " LEFT JOIN emprestimo e ON e.cod_cliente = c.cod_cliente " +
                 " GROUP BY c.cod_cliente " +
                 " ORDER BY c.cod_cliente"));

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
            try
            {
                DataTable tabelaDados = new DataTable();

                tabelaDados = database.select(string.Format("SELECT e.cod_emprestimo, e.data_retirada, e.data_entrega, u.nome_usuario" +
                    " FROM emprestimo e" +
                    " INNER JOIN usuario u ON u.cod_usuario = e.cod_usuario" +
                    " WHERE cod_cliente = '{0}'", gridCliente.Rows[gridCliente.CurrentRow.Index].Cells[1].Value.ToString()));

                gridEmprestimos.DataSource = tabelaDados;


                gridEmprestimos.Columns[0].Width = 158;
                gridEmprestimos.Columns[1].Width = 158;
                gridEmprestimos.Columns[2].Width = 158;
                gridEmprestimos.Columns[3].Width = 158;

                gridEmprestimos.Columns[0].HeaderText = "Código Empréstimo";
                gridEmprestimos.Columns[1].HeaderText = "Data de Retirada";
                gridEmprestimos.Columns[2].HeaderText = "Data de Entrega";
                gridEmprestimos.Columns[3].HeaderText = "Funcionário";
            }
            catch (Exception erro)
            {
            }
            
                                                  
        }
    }
}
