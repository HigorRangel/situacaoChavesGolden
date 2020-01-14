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
    public partial class cadastroProprietario : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();

        

        bool seletorTela = false;

        public cadastroProprietario(string codigoProprietario)
        {
            InitializeComponent();

            seletorTela = true;
        }

        public cadastroProprietario()
        {
            InitializeComponent();
        }

        private void CadastroProprietario_Load(object sender, EventArgs e)
        {

        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            int contErros = 0;

            if (nomeBox.Text.Length == 0 || !nomeBox.Text.Contains(" "))
            {
                contErros++;
            }
            
            if(emailBox.Text.Length == 0 || !emailBox.Text.Contains("@") || !emailBox.Text.Contains("."))
            {
                contErros++;
            }
            if(contatoBox.Text.Length < 10)
            {
                contErros++;
            }
            
            if(contErros == 0)
            {
                if (seletorTela == false)
                {
                    try
                    {
                        database.insertInto("INSERT INTO proprietario (nome, contato, email)");

                    }
                    catch { }
                }

            }

            
        }
    }
}
