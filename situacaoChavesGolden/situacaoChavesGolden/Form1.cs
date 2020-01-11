using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace situacaoChavesGolden
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }


       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnEntrar_MouseEnter(object sender, EventArgs e)
        {
            btnEntrar.ForeColor = Color.White;

        }

        private void BtnEntrar_MouseLeave(object sender, EventArgs e)
        {
            btnEntrar.ForeColor = Color.FromArgb(0, 149, 255);
        }
    }
}
