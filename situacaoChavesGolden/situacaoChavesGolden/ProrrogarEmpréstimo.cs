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
    public partial class ProrrogarEmpréstimo : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();

        string codEmprestimo = "";
        public ProrrogarEmpréstimo(string codEmp)
        {
            InitializeComponent();

            codEmprestimo = codEmp;
            novaData.MinDate = DateTime.Now;
        }

        private void ProrrogarEmpréstimo_Load(object sender, EventArgs e)
        {
            novaData.Value = DateTime.Now;        
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            database.update(string.Format("UPDATE emprestimo" +
                                           " SET entrega_prevista = '{0}'" +
                                           " WHERE cod_emprestimo = '{1}'", novaData.Value, codEmprestimo));

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
