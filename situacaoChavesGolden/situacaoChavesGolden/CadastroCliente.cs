﻿using System;
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
        string codigoCliente = "";


        public CadastroCliente()
        {
            InitializeComponent();
        }

        public CadastroCliente(string codCliente)
        {
            InitializeComponent();

            seletorTela = true;
            codigoCliente = codCliente;
        }

        private void CadastroCliente_Load(object sender, EventArgs e)
        {
            comboDoc.Items.Add("RG");
            comboDoc.Items.Add("RNE");
            comboDoc.Items.Add("CNH");
            comboDoc.Items.Add("Outro");

            if(seletorTela == true)
            {
                DataTable dadosCliente = new DataTable();

                dadosCliente = database.select(string.Format("" +
                    "SELECT * FROM cliente WHERE cod_cliente = '{0}'", codigoCliente));

                foreach(DataRow row in dadosCliente.Rows)
                {
                    boxCpf.Text = row[2].ToString();
                    comboDoc.SelectedItem = row[8].ToString();
                    boxNumDoc.Text = row[4].ToString();
                    boxNome.Text = row[1].ToString();
                    boxEmail.Text = row[3].ToString();
                    boxContato.Text = row[5].ToString();
                    boxContato2.Text = row[6].ToString();
                    boxEndereco.Text = row[7].ToString();   

                }
            }

        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            string cpf = boxCpf.Text.Trim();
            string verifCliente = "";


            if(cpf != "")
            {
                try
                {
                    verifCliente = database.selectScalar(string.Format("" +
                    "SELECT count(cpf) FROM cliente WHERE cpf = '{0}'", cpf));
                }
                catch { }

                if (int.Parse(verifCliente) > 0)
                {
                    Message caixaMensagem = new Message(string.Format("O CPF {0} ja está cadastrado!", boxCpf.Text.Trim()),
                        "Cliente já cadastrado", "erro", "confirma");
                    caixaMensagem.ShowDialog();

                    boxCpf.Text = "";
                }
                else
                {
                    string erros = "";
                    int contErros = 0;

                    if (boxCpf.Text.Length > 0 && boxCpf.Text.Length < 11)
                    {
                        erros += "\n-CPF (É necessário ter 11 dígitos)";
                        contErros++;
                    }

                    if (boxNome.Text.Length == 0)
                    {
                        erros += "\n-Nome (campo obrigatório)";
                        contErros++;
                    }

                    if (comboDoc.SelectedIndex == -1)
                    {
                        erros += "\n-Tipo do documento (Escolha obrigatória)";
                        contErros++;
                    }
                    if (boxEmail.Text.Length > 0 && (!boxEmail.Text.Contains("@") || !boxEmail.Text.Contains(".")))
                    {
                        erros += "\n-Email (Formato incorreto)";
                        contErros++;
                    }
                    if (boxContato.Text.Length > 0 && boxContato.Text.Length < 10)
                    {
                        erros += "\n-Contato principal (Precisa ter no mínimo 10 números";
                        contErros++;
                    }
                    if (boxContato2.Text.Length > 0 && boxContato2.Text.Length < 10)
                    {
                        erros += "\n-Contato secundário (Precisa ter no mínimo 10 números";
                        contErros++;
                    }


                    if (contErros == 0)
                    {
                        if (seletorTela == false)
                        {
                            try
                            {
                                database.insertInto(string.Format("" +
                                "INSERT INTO cliente (nome_cliente, cpf, email, tipo_documento, documento, contato_principal, contato_secundario, endereco)" +
                                " VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}')", boxNome.Text.Trim(),
                                boxCpf.Text.Trim(), boxEmail.Text.Trim(), comboDoc.SelectedItem.ToString().Trim(),
                                boxNumDoc.Text.Trim(), boxContato.Text.Trim(), boxContato2.Text.Trim(), boxEndereco.Text.Trim()));

                                Message caixaMessage = new Message("Cliente cadastrado com sucesso!", "Sucesso", "sucesso", "confirma");
                                caixaMessage.ShowDialog();

                                this.DialogResult = DialogResult.Yes;
                                this.Close();
                            }
                            catch (Exception erro)
                            {
                                Message caixaMessage = new Message("Não foi possível cadastrar pelo seguinte erro: \n\n-" + erro.Message, "Erro", "erro", "confirma");
                                caixaMessage.ShowDialog();
                            }
                            
                            
                        }
                        else
                        {
                            database.update(string.Format("" +
                                "UPDATE cliente" +
                                " SET nome_cliente = '{0}', cpf = '{1}', email = '{2}', tipo_documento = '{3}', documento = '{4}'," +
                                " contato_principal = '{5}', contato_secundario = '{6}', endereco = '{7}'," +
                                " WHERE cod_cliente = '{8}'", boxNome.Text.Trim(),
                                boxCpf.Text.Trim(), boxEmail.Text.Trim(), comboDoc.SelectedItem.ToString().Trim(),
                                boxNumDoc.Text.Trim(), boxContato.Text.Trim(), boxContato2.Text.Trim(), boxEndereco.Text.Trim(), codigoCliente));
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;    
        }
    }
}
