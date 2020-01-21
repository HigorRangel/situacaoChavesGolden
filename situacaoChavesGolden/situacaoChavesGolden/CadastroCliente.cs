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
    public partial class CadastroCliente : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();
        bool seletorTela = false;


        public CadastroCliente()
        {
            InitializeComponent();
        }

        public CadastroCliente(string codCliente)
        {
            InitializeComponent();

            seletorTela = true;
        }

        private void CadastroCliente_Load(object sender, EventArgs e)
        {
            comboDoc.Items.Add("RG");
            comboDoc.Items.Add("RNE");
            comboDoc.Items.Add("CNH");
            comboDoc.Items.Add("Outro");

        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            string erros = "";
            int contErros = 0;

            if (boxCpf.Text.Length > 0 && boxCpf.Text.Length < 11)
            {
                erros += "\n-CPF (É necessário ter 11 dígitos)";
                contErros++;
            }

            if(boxNome.Text.Length == 0)
            {
                erros += "\n-Nome (campo obrigatório)";
                contErros++;
            }

            if(comboDoc.SelectedIndex == -1)
            {
                erros += "\n-Tipo do documento (Escolha obrigatória)";
                contErros++;
            }
            if(boxEmail.Text.Length > 0 && (!boxEmail.Text.Contains("@") || !boxEmail.Text.Contains(".")))
            {
                erros += "\n-Email (Formato incorreto)";
                contErros++;
            }
            if(boxContato.Text.Length > 0 && boxContato.Text.Length < 10){
                erros += "\n-Contato principal (Precisa ter no mínimo 10 números";
                contErros++;
            }
            if(boxContato2.Text.Length > 0 && boxContato2.Text.Length < 10)
            {
                erros += "\n-Contato secundário (Precisa ter no mínimo 10 números";
                contErros++;
            }


            if(contErros == 0)
            {
                if(seletorTela == false)
                {
                    database.insertInto(string.Format("" +
                        "INSERT INTO cliente (nome_cliente, cpf, email, tipo_documento, documento, contato_principal, contato_secundario, endereco)" +
                        " VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}')", boxNome.Text.Trim(),
                        boxCpf.Text.Trim(), boxEmail.Text.Trim(), comboDoc.SelectedItem.ToString().Trim(),
                        boxNumDoc.Text.Trim(), boxContato.Text.Trim(), boxContato2.Text.Trim(), boxEndereco.Text.Trim()));

                    Message caixaMessage = new Message("Cliente cadastrado com sucesso!", "Sucesso", "sucesso", "confirma");
                    caixaMessage.ShowDialog();

                    this.Close();
                    this.DialogResult = DialogResult.Yes;
                }
                else
                {

                }
            }
            else
            {
                Message caixaMessage = new Message("Há erros no preenchemento do formulário! Confira: \n" + erros, "Erro no preenchimento", "erro", "confirma");
                caixaMessage.ShowDialog();
            }
        }
    }
}
