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
    public partial class EmManutencao : MetroFramework.Forms.MetroForm
    {
        string txt = "";
        public EmManutencao(string str)
        {
            txt = str;
            InitializeComponent();
        }

        private void EmManutencao_Load(object sender, EventArgs e)
        {
            texto.Text = txt.ToUpper();
        }
    }
}
