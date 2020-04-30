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
            DataTable clientes = new DataTable();

            clientes = database.select(string.Format("" +
                "SELECT c.cod_cliente, c.nome_cliente, c.email, c.contato_principal, c.contato_secundario, COUNT(e.cod_emprestimo) " +
                 " FROM cliente c " +
                 " LEFT JOIN emprestimo e ON e.cod_cliente = c.cod_cliente " +
                 " GROUP BY c.cod_cliente " +
                 " ORDER BY c.cod_cliente"));

            gridCliente.DataSource = clientes.DefaultView;

            gridCliente.Columns[0].HeaderText = "Código";
            gridCliente.Columns[1].HeaderText = "Nome do Cliente";
            gridCliente.Columns[2].HeaderText = "Email";
            gridCliente.Columns[3].HeaderText = "Contato 1";
            gridCliente.Columns[4].HeaderText = "Contato 2";
            gridCliente.Columns[5].HeaderText = "Empréstimos";

            gridCliente.Columns[0].Width = 50;
            gridCliente.Columns[1].Width = 188;
            gridCliente.Columns[2].Width = 160;
            gridCliente.Columns[3].Width = 70;
            gridCliente.Columns[4].Width = 70;
            gridCliente.Columns[5].Width = 70;

            gridCliente.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            atualizarClientes();
        }
    }
}
