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

    public partial class CadastrarEmprestimo : MetroFramework.Forms.MetroForm
    {
        DateTime dataHoje = DateTime.Now;
        PostgreSQL database = new PostgreSQL();

        List<string> cpfClientes = new List<string>();
        List<string> codigosClientes = new List<string>();
        string codigoCliente = "";

        private void atualizarComboBox()
        {
            cpfClientes.Clear();
            comboClientes.Items.Clear();

            DataTable clientes = new DataTable();

            clientes = database.select("SELECT cod_cliente, nome_cliente, cpf FROM cliente ORDER BY nome_cliente");

            foreach(DataRow row in clientes.Rows)
            {
                cpfClientes.Add(row[2].ToString());
                comboClientes.Items.Add(row[1].ToString());
                codigosClientes.Add(row[0].ToString());
            }
        }

        public CadastrarEmprestimo()
        {
            InitializeComponent();
        }

        private void CadastrarEmprestimo_Load(object sender, EventArgs e)
        {
            atualizarComboBox();

            comboDocs.Items.Add("RG");
            comboDocs.Items.Add("RNE");
            comboDocs.Items.Add("CNH");
            comboDocs.Items.Add("Outro");

            datePrevisao.Value = dataHoje.AddDays(1);
            datePrevisao.MinDate = dataHoje;
            datePrevisao.MaxDate = dataHoje.AddDays(30);

            radioCliente.Checked = true;
            radioProprietario.Checked = false;
        }

        private void AddCliente_Click(object sender, EventArgs e)
        {
            CadastroCliente cadastrar = new CadastroCliente();
            cadastrar.ShowDialog();

            atualizarComboBox();
        }

        private void BoxCpf_Leave(object sender, EventArgs e)
        {
            if(boxCpf.Text.Length > 0)
            {
                if (cpfClientes.Contains(boxCpf.Text.Trim()))
                {
                    comboClientes.SelectedIndex = cpfClientes.IndexOf(boxCpf.Text.Trim());
                }
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dataPrevisao = datePrevisao.Value;
            //int dias = dataPrevisao.Subtract(dataHoje);

            MessageBox.Show(dias.ToString());


        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            if (radioProprietario.Checked)
            {
                groupDadosCliente.Enabled = false;
                boxCpf.Style = MetroFramework.MetroColorStyle.Silver;
                boxDescDoc.Style = MetroFramework.MetroColorStyle.Silver;

            }
            else
            {
                boxCpf.Style = MetroFramework.MetroColorStyle.Blue;
                boxDescDoc.Style = MetroFramework.MetroColorStyle.Blue;
                groupDadosCliente.Enabled = true;
            }
        }
    }
}
