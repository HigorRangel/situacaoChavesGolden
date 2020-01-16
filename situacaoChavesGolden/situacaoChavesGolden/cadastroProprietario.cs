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
            
            
            if(contatoBox.Text.Length ==0)
            {
                contErros++;
            }
            if(emailBox.Text.Length == 0)
            {
                contErros++;
            }
            
            if(contErros == 0)
            {
                if (seletorTela == false)
                {
                    try
                    {

                        database.insertInto(string.Format("INSERT INTO proprietario (nome, contato, email)" +
                            " VALUES ('{0}', '{1}', '{2}')", nomeBox.Text.Trim(), contatoBox.Text.Trim(),
                            emailBox.Text.Trim()));
                      

                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                }

            }
            else
            {
                MessageBox.Show("Há campos preenchidos incorretamente! Por favor verifique.");
            }

            
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
