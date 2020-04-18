﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace situacaoChavesGolden
{

    public partial class CadastrarEmprestimo : MetroFramework.Forms.MetroForm
    {
        bool seletorTela = false;
        string codigoChave = "";
        string user = "";

        public CadastrarEmprestimo(string usuario, int codEmprestimo)
        {
            InitializeComponent();
            seletorTela = true;
            user = usuario;
        }

        public CadastrarEmprestimo(string usuario, string codChave)
        {
            InitializeComponent();
            codigoChave = codChave;
            user = usuario;
        }



        DateTime dataHoje = DateTime.Now;
        PostgreSQL database = new PostgreSQL();

        List<string> cpfClientes = new List<string>();
        List<string> codigosClientes = new List<string>();
        string codigoCliente = "";


        private void criarCadastroCliente()
        {

            CadastroCliente cadastro = new CadastroCliente();
            cadastro.ShowDialog();


            if (cadastro.DialogResult == DialogResult.Yes)
            {

                atualizarComboBox();

                string codigoProp = "";
                string nomeProp = "";
                try
                {
                    codigoProp = database.selectScalar("SELECT cod_cliente " +
                                                        " FROM cliente " +
                                                        " ORDER BY cod_cliente DESC " +
                                                        " LIMIT 1");

                    nomeProp = database.selectScalar("SELECT nome_cliente " +
                                                        " FROM cliente " +
                                                        " ORDER BY cod_cliente DESC " +
                                                        " LIMIT 1");

                    comboClientes.SelectedItem = nomeProp;

                    buscarDadosCliente(codigoProp);


                }
                catch (Exception erro)
                {
                    Message caixaMensagem = new Message("Não foi possível buscar os dados pelo seguinte erro: \n\n- " +
                        erro.Message, "Erro", "erro", "confirma");

                    caixaMensagem.ShowDialog();
                }

                
            }
        }

        private void buscarDadosChave()
        {
            DataTable dadosChave = new DataTable();

            dadosChave = database.select(string.Format("" +
                "SELECT cod_imob, rua, numero, complemento, bairro, cidade, estado" +
                " FROM chave" +
                " WHERE cod_chave = '{0}'", codigoChave));

            foreach(DataRow row in dadosChave.Rows)
            {
                codigoChaveBox.Text = row[0].ToString();
                textoCodChave.Text = row[0].ToString();
                endereco.Text = string.Format("{0}, {1} ({2}) - {3} - {4}/{5}", row[1], row[2], row[3], row[4], row[5], row[6]);
            }
        }

        private void buscarDadosCliente(string cliente)
        {


            string tipo = "";
            if(cliente.Length == 11)
            {
                tipo = "cpf";
            }
            else
            {
                tipo = "cod_cliente";
            }


            try
            {
                DataTable dadosClientes = new DataTable();

                dadosClientes = database.select(string.Format("" +
                    "SELECT cpf, nome_cliente, contato_principal, contato_secundario, email" +
                    " FROM cliente" +
                    " WHERE {0} = '{1}'", tipo, cliente));

                //MessageBox.Show(dadosClientes.Rows.Count.ToString());



                if (dadosClientes.Rows.Count == 0)
                {
                    boxCpf.Text = ""; //CPF
                    textoCpf.Text = ""; //cpf
                    nome.Text = ""; //nome
                    textoTel1.Text = ""; //contato1
                    textoTel2.Text = "";  //contato2
                    email.Text = ""; //email

                    
                }
                else
                {
                    foreach (DataRow row in dadosClientes.Rows)
                    {
                        boxCpf.Text = row[0].ToString();
                        textoCpf.Text = row[0].ToString();
                        nome.Text = row[1].ToString();
                        textoTel1.Text = row[2].ToString();
                        textoTel2.Text = row[3].ToString();
                        email.Text = row[4].ToString();
                    }
                }
                            

                
            }
            catch (Exception erro)
            {
                Message caixaMensagem = new Message("Não foi possível encontrar os dados do usuário pelo" +
                    " seguinte motivo: \n" + erro.Message, "Erro ao buscar os dados", "erro", "confirma");
                caixaMensagem.ShowDialog();
            }

        }

        private void atualizarComboBox()
        {
            codigosClientes.Clear();
            cpfClientes.Clear();
            comboClientes.Items.Clear();

            DataTable clientes = new DataTable();

            clientes = database.select("SELECT cod_cliente, nome_cliente, cpf FROM cliente ORDER BY nome_cliente");

            foreach(DataRow row in clientes.Rows)
            {
                cpfClientes.Add(row[2].ToString());
                comboClientes.Items.Add(row[1].ToString());
                codigosClientes.Add(row[0].ToString());

                //boxCpf.Text = row[0].ToString();
            }
        }

        

        private void CadastrarEmprestimo_Load(object sender, EventArgs e)
        {
            atualizarComboBox();
            buscarDadosChave();

            endereco.MaximumSize = new Size(160, 49);
            endereco.AutoSize = true;

            email.MaximumSize = new Size(160, 25);
            email.AutoSize = true;


            comboDocs.Items.Add("RG");
            comboDocs.Items.Add("RNE");
            comboDocs.Items.Add("CNH");
            comboDocs.Items.Add("Outro");

            datePrevisao.Value = dataHoje.AddDays(1);
            datePrevisao.MinDate = dataHoje.AddDays(1);
            datePrevisao.MaxDate = dataHoje.AddDays(30);

            radioCliente.Checked = true;
            radioProprietario.Checked = false;
        }

        private void AddCliente_Click(object sender, EventArgs e)
        {
            criarCadastroCliente();

            atualizarComboBox();
        }

        private void BoxCpf_Leave(object sender, EventArgs e)
        {
            
            if(boxCpf.Text.Length > 0)
            {
                if (cpfClientes.Contains(boxCpf.Text.Trim()))
                {
                    buscarDadosCliente(boxCpf.Text.Trim());
                    comboClientes.SelectedIndex = cpfClientes.IndexOf(boxCpf.Text.Trim());
                }
                else
                {
                    Message caixaMensagem = new Message(string.Format("Não foi encontrado cliente com o CPF {0}." +
                        " Deseja cadastrar um novo cliente?", boxCpf.Text), "Cliente não encontrado",
                        "erro", "escolha");
                    caixaMensagem.ShowDialog();

                    if (caixaMensagem.DialogResult == DialogResult.Yes)
                    {
                        criarCadastroCliente();
                    }
                }
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dataPrevisao = datePrevisao.Value;
            //int dias = dataPrevisao.Subtract(dataHoje);

            TimeSpan intervalo = dataPrevisao - dataHoje;

            previsaoLabel.Text = string.Format("{0} dia (s)", Math.Ceiling(intervalo.TotalDays));
            


        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            if (radioProprietario.Checked)
            {
                groupDadosCliente.Enabled = false;
                boxCpf.Style = MetroFramework.MetroColorStyle.Silver;
                boxDescDoc.Style = MetroFramework.MetroColorStyle.Silver;

            }
            else
            {
                boxCpf.Style = MetroFramework.MetroColorStyle.Blue;
                boxDescDoc.Style = MetroFramework.MetroColorStyle.Blue;
                groupDadosCliente.Enabled = true;
            }
        }

        private void ComboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboClientes.SelectedIndex == -1)
            {
                btnEditarCliente.Enabled = false;
            }
            else
            {
                btnEditarCliente.Enabled = true;
            }

            buscarDadosCliente(codigosClientes[comboClientes.SelectedIndex]);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnEditarCliente_Click(object sender, EventArgs e)
        {
            CadastroCliente editar = new CadastroCliente(codigosClientes[comboClientes.SelectedIndex]);
            editar.ShowDialog();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            int contErros = 0;
            string erros = "";

            string quemEmpresta = groupQuemEmpresta.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text; ;
            string quantChaves = qtdChaves.Value.ToString();
            string quantControles = qtdControles.Value.ToString();
            string descricao = descBox.Text;
            string cpfCliente = boxCpf.Text;
            string descricaoDocumento = boxDescDoc.Text;
            string nomeCliente = "";
            string documentoDeixado = "";
            string codCliente = "";
            DateTime dataHojeUs = new DateTime();
            DateTime dataPrevisao = new DateTime();

            //Código do cliente
            try
            {
                codCliente = codigosClientes[comboClientes.SelectedIndex];
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                contErros++;
                erros += "\n-Código do Cliente (Não identificado)";
            }

            //Data de previsão
            try
            {
                dataPrevisao = datePrevisao.Value;

                dataPrevisao = Convert.ToDateTime(dataPrevisao.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            catch
            {
                contErros++;
                erros += "\n-Previsão de entrega (Escolha obrigatória)";
            }

            //ComboBox de nomes dos clientes
            try
            {
                nomeCliente = comboClientes.SelectedItem.ToString();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                contErros++;
                erros += "\n-Nome do Cliente (Escolha obrigatória)";
            }
            //ComboBox de documentos
            try
            {
                 documentoDeixado = comboDocs.SelectedItem.ToString();
            }
            catch
            {
                contErros++;
                erros += "\n-Documento Deixado (Escolha obrigatória)";
            }

            //Quem está emprestando
            if(quemEmpresta.Length == 0)
            {
                contErros++;
                erros += "\n-Quem está emprestando (Seleção obrigatória)";
            }
            //Data previsão
            if(dataPrevisao.Date == null)
            {
                contErros++;
                erros += "\n-Previsão de entrega (Seleção obrigatória)";
            }
            //Quantidade de chaves
            if(quantChaves.Length == 0)
            {
                contErros++;
                erros += "\n-Quantidade de chaves (Inserção obrigatória)";
            }
            //Quantidade de controles
            if (quantControles.Length == 0)
            {
                contErros++;
                erros += "\n-Quantidade de controles (Inserção obrigatória)";
            }
            //Número do CPF do cliente
            if(cpfCliente.Length == 0)
            {
                contErros++;
                erros += "\n-CPF (Inserção obrigatória)";
            }
            if(comboDocs.SelectedIndex != -1 && descricaoDocumento.Length == 0)
            {
                contErros++;
                erros += "\n-Descrição do Documento (Inserção obrigatória)";
            }

            if(contErros == 0)
            {
                //try
                //{
                    database.insertInto(string.Format("" +
                        "INSERT INTO emprestimo (cliente, usuario, cod_chave, quant_chaves, quant_controles, tipo_doc, documento," +
                        " descricao, data_retirada, data_prevista)" +
                        " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                        codCliente, user, codigoChave, quantChaves, quantControles, documentoDeixado, descricaoDocumento,
                        descricao, dataHoje, dataPrevisao ));

                    Message caixaMensagem = new Message("Empréstimo cadastrado com sucesso!", "", "sucesso", "confirma");
                    caixaMensagem.ShowDialog();

                    this.Close();
                    this.DialogResult = DialogResult.OK;
                //}
                //catch (Exception erro)
                //{
                //    Message caixaMensagem = new Message("Erro ao cadastrar! \n\nDescrição: " + erro.Message, "Erro no banco de dados", "erro", "confirma");
                //    caixaMensagem.ShowDialog();
                //}
               
            }
            else
            {
                Message caixaMensagem = new Message("Corrija os erros abaixo antes de continuar!\n-" + erros, "Erro de preenchimento",
                    "erro", "confirma");
                caixaMensagem.ShowDialog();
            }

        }
    }
}