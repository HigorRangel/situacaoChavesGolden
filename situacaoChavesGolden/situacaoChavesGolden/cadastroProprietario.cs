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

        string codProprietario = "";

        bool seletorTela = false;

        public cadastroProprietario(string codigoProprietario)
        {
            InitializeComponent();

            seletorTela = true;

            codProprietario = codigoProprietario;
        }

        public cadastroProprietario()
        {
            InitializeComponent();
        }

        private void CadastroProprietario_Load(object sender, EventArgs e)
        {
            DataTable dadosPro = new DataTable();
            if(seletorTela == true)
            {
                dadosPro = database.select(string.Format("SELECT * FROM proprietario WHERE cod_proprietario = '{0}'", codProprietario));
            }


            foreach(DataRow row in dadosPro.Rows)
            {
                nomeBox.Text = row[1].ToString();
                contatoBox.Text = row[2].ToString();
                emailBox.Text = row[3].ToString();
            }
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

                try
                {
                    if (seletorTela == false)
                    {
                        database.insertInto(string.Format("INSERT INTO proprietario (nome, contato, email)" +
                            " VALUES ('{0}', '{1}', '{2}')", nomeBox.Text.Trim(), contatoBox.Text.Trim(),
                            emailBox.Text.Trim()));

                        Message caixaMensagem = new Message("O cadastro foi efetuado com sucesso!",
                       "Sucesso", "sucesso", "confirma");
                        caixaMensagem.ShowDialog();

                        this.Close();
                        this.DialogResult = DialogResult.OK;

                    }

                    else
                    {
                        database.update(string.Format("UPDATE proprietario " +
                            " SET nome = '{0}', contato = '{1}', email = '{2}'" +
                            " WHERE cod_proprietario = '{3}'", nomeBox.Text.Trim(), contatoBox.Text.Trim(), emailBox.Text.Trim(), codProprietario));

                        Message caixaMensagem = new Message("O cadastro foi atualizado com sucesso!",
                       "Sucesso", "sucesso", "confirma");
                        caixaMensagem.ShowDialog();

                        this.Close();
                        this.DialogResult = DialogResult.Yes;
                    }
                }
                catch (Exception erro)
                {
                    Message caixaMensagem = new Message("Não foi possível acessar o banco de dados no momento! Tente novamente mais tarde",
                        "Erro no banco de dados", "erro", "confirma");
                    caixaMensagem.ShowDialog();
                }
                

            }
            else
            {
                Message caixaMensagem = new Message("Há campos não preenchidos corretamente! Verifique e tente novamente",
                        "Erro no banco de dados", "erro", "confirma");
                caixaMensagem.ShowDialog();
            }

            
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
