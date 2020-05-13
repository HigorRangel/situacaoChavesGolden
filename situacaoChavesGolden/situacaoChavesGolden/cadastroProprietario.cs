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
        FormatarStrings format = new FormatarStrings();

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

                nomeBox.Enabled = false;        
                contatoBox.Enabled = false;
                emailBox.Enabled = false;
                btnCadastrar.Enabled = false;
                metroLabel4.Text = "Visualizar Proprietário";
            }
        }

        private bool verificarExistencia()
        {
            DataTable tabelaProp = new DataTable();

            tabelaProp = database.select(string.Format("SELECT * FROM proprietario" +
                                                        " WHERE nome ILIKE '%{0}%' OR email ILIKE '%{1}%' OR" +
                                                        " contato::text ILIKE '%{2}%'", nomeBox.Text.Trim(), emailBox.Text.Trim(),
                                                        contatoBox.Text.Trim()));

            
            foreach(DataRow row in tabelaProp.Rows)
            {
                int contIgual = 0;
                string aviso = "";
                
                
                if(nomeBox.Text.Trim() == row[1].ToString())
                {
                    aviso = string.Format("Ja existe um cadastro com nome {0}.\n Deseja cadastrar mesmo assim?", row[1].ToString());
                    contIgual++;    
                }

                else if (emailBox.Text.Trim() == row[3].ToString() && emailBox.Text != "" && emailBox.Text != " ")
                {
                    aviso = string.Format("Ja existe um cadastro com email {0}. ({1}) \nDeseja cadastrar mesmo assim?", 
                        row[3].ToString(), row[1]);

                    contIgual++;
                }
                else if (contatoBox.Text.Trim() == row[2].ToString())
                {
                    aviso = string.Format("Ja existe um cadastro com o contato {0}. ({1})\n Deseja cadastrar mesmo assim?",
                        row[2].ToString(), row[1]);
                    contIgual++;
                }

                if(contIgual > 0)
                {
                    Message popUp = new Message(aviso, "Aviso", "aviso", "escolha");
                    popUp.ShowDialog();

                    if (popUp.DialogResult == DialogResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
               

                
                
            }
            return true;
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            bool verifExist = verificarExistencia();


            if(verifExist == true)
            {
                int contErros = 0;

                if (nomeBox.Text.Length == 0 || !nomeBox.Text.Contains(" "))
                {
                    contErros++;
                }


                if (contatoBox.Text.Length == 0)
                {
                    contErros++;
                }


                if (contErros == 0)
                {
                    FormatarStrings format = new FormatarStrings();
                    try
                    {
                        if (seletorTela == false)
                        {
                            database.insertInto(string.Format("INSERT INTO proprietario (nome, contato, email)" +
                                " VALUES ('{0}', '{1}', '{2}')", format.inserirBD(nomeBox.Text.Trim()), contatoBox.Text.Trim(),
                                format.inserirBD(emailBox.Text.Trim())));

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
                                " WHERE cod_proprietario = '{3}'", format.inserirBD(nomeBox.Text.Trim()), contatoBox.Text.Trim(), format.inserirBD(emailBox.Text.Trim()), codProprietario));

                            Message caixaMensagem = new Message("O cadastro foi atualizado com sucesso!",
                           "Sucesso", "sucesso", "confirma");
                            caixaMensagem.ShowDialog();

                            this.Close();
                            this.DialogResult = DialogResult.Yes;
                        }
                    }
                    catch (Exception erro)
                    {
                        Message caixaMensagem = new Message("Não foi possível acessar o banco de dados no momento pelo seguinte motivo:\n\n" + erro.Message,
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


        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;    
        }

        private void ContatoBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            format.permitirNumeros(e);
        }
    }
}
