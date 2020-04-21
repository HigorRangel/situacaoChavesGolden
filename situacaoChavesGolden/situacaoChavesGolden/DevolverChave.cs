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
    public partial class DevolverChave : MetroFramework.Forms.MetroForm
    {
        string codigoChave = "";

        PostgreSQL database = new PostgreSQL();

        public DevolverChave(string codChave)
        {
            InitializeComponent();
            codigoChave = codChave;
        }

        private void DevolverChave_Load(object sender, EventArgs e)
        {
            DataTable dadosEmprestimo = new DataTable();

            dadosEmprestimo = database.select(string.Format(""))
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

    
    }
}
