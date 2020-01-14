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
    public partial class cadastroChave : MetroFramework.Forms.MetroForm
    {
        bool seletorTela = false;

        public cadastroChave(string codigoChave)
        {
            InitializeComponent();
            seletorTela = true;
        }

        public cadastroChave()
        {
            InitializeComponent();
        }

        private void CadastroChave_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.ForeColor = Color.White;
        }

        private void ComboProprietario_SelectedValueChanged(object sender, EventArgs e)
        {
            if(comboProprietario.SelectedItem.ToString() == "--NOVO--")
            {
                MessageBox.Show("oi");
            }
        }
    }
}
