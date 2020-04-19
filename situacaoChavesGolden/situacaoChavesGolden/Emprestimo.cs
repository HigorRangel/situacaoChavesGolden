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
        PostgreSQL database = new PostgreSQL();
        public Emprestimo()
        {
            InitializeComponent();
        }

        private void atualizarGridEmprestimo()
        {
            try
            {
                database.select("SELECT * FROM emprestimo");
            }
            catch
            {

            }
        }

        private void Emprestimo_Load(object sender, EventArgs e)
        {

        }
    }
}
