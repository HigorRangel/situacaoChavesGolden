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
    public partial class ReservarChave : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();

        DateTime dataHoje = DateTime.Now;
        bool seletorTela = false;
        string codigoChave = "";
        string user = "";

        public ReservarChave(string codChave, string usuario)
        {
            InitializeComponent();

            codigoChave = codChave;
            user = usuario;

        }

        private void btnAdicionarPessoa_Click(object sender, EventArgs e)
        {
            atualizarGrid(groupQuemEmpresta.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper());
            painelProp.Visible = true;
            groupQuemEmpresta.Enabled = false;
            groupDadosEmp.Enabled = false;
            groupDadosCliente.Enabled = false;
            groupBox4.Enabled = false;
            btnConfirmar.Enabled = false;
        }

        private void atualizarGrid(string tipo)
        {
            if (tipo == "CLIENTE")
            {
                gridPessoas.DataSource = database.select(string.Format("SELECT cod_cliente, nome_cliente" +
                                                                       " FROM cliente" +
                                                                       " WHERE nome_cliente ILIKE '%{0}%'" +
                                                                       " ORDER BY nome_cliente", boxProcurarProp.Text));

                gridPessoas.Columns[0].HeaderText = "Código";
                gridPessoas.Columns[1].HeaderText = "Nome do Cliente";

                btnNovoProp.Visible = true;


            }
            else if (tipo == "FUNCIONARIO")
            {
                gridPessoas.DataSource = database.select(string.Format("SELECT cod_usuario, nome_usuario" +
                                                                       " FROM usuario" +
                                                                       " WHERE nome_usuario ILIKE '%{0}%'" +
                                                                       " ORDER BY nome_usuario", boxProcurarProp.Text));
                gridPessoas.Columns[0].HeaderText = "Código";
                gridPessoas.Columns[1].HeaderText = "Nome do Usuário";

                btnNovoProp.Visible = false;
            }

            gridPessoas.Columns[0].Width = 45;
            gridPessoas.Columns[1].Width = 270;

            gridPessoas.Columns[0].MinimumWidth = 45;
            gridPessoas.Columns[1].MinimumWidth = 265;
        }

        private void buscarDadosChave()
        {
            DataTable dadosChave = new DataTable();

            dadosChave = database.select(string.Format("" +
                "SELECT cod_imob, rua, numero, complemento, bairro, cidade, estado" +
                " FROM chave" +
                " WHERE indice_chave = '{0}'", codigoChave));

            foreach (DataRow row in dadosChave.Rows)
            {
                textoCodChave.Text = row[0].ToString();
                endereco.Text = string.Format("{0}, {1} ({2}) - {3} - {4}/{5}", row[1], row[2], row[3], row[4], row[5], row[6]);
            }
        }

        private void ReservarChave_Load(object sender, EventArgs e)
        {
            buscarDadosChave();

            endereco.MaximumSize = new Size(160, 49);
            endereco.AutoSize = true;

            email.MaximumSize = new Size(160, 25);
            email.AutoSize = true;



            radioCliente.Checked = true;
            radioProprietario.Checked = false;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void LabelProp_Click(object sender, EventArgs e)
        {

        }

        private void NomePessoaBox_Click(object sender, EventArgs e)
        {

        }

        private void GroupDadosCliente_Enter(object sender, EventArgs e)
        {

        }


        private void btnCancelarProp_Click(object sender, EventArgs e)
        {
            painelProp.Visible = false;
            groupQuemEmpresta.Enabled = true;
            groupDadosEmp.Enabled = true;
            groupDadosCliente.Enabled = true;
            groupBox4.Enabled = true;
            btnConfirmar.Enabled = true;
        }

        private void btnConfirmarProp_Click(object sender, EventArgs e)
        {
            if (gridPessoas.CurrentRow.Index != -1)
            {
                codPessoaBox.Text = gridPessoas.CurrentRow.Cells[0].Value.ToString();
                nomePessoaBox.Text = gridPessoas.CurrentRow.Cells[1].Value.ToString(); ;

                painelProp.Visible = false;
                groupQuemEmpresta.Enabled = true;
                groupDadosEmp.Enabled = true;
                groupDadosCliente.Enabled = true;
                groupBox4.Enabled = true;
                btnConfirmar.Enabled = true;
                btnAdicionarPessoa.Visible = false;
                labelProp.Visible = true;
                labelCod.Visible = true;
                codPessoaBox.Visible = true;
                nomePessoaBox.Visible = true;
                excluiProp.Enabled = true;
                excluiProp.Visible = true;

                string tipo = groupQuemEmpresta.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();

                DataTable dados = new DataTable();

                if (tipo == "PROPRIETARIO")
                {
                    dados = database.select(string.Format("SELECT contato, email, nome" +
                                                          " FROM proprietario" +
                                                          " WHERE cod_proprietario = '{0}'", codPessoaBox.Text));

                    foreach (DataRow row in dados.Rows)
                    {
                        labelTel1.Text = row[0].ToString(); ;
                        email.Text = row[1].ToString();
                        nome.Text = row[2].ToString();
                    }
                }
                else if (tipo == "CLIENTE")
                {
                    dados = database.select(string.Format("SELECT cpf, contato_principal, contato_secundario, email, nome_cliente" +
                                            " FROM cliente" +
                                            " WHERE cod_cliente = '{0}'", codPessoaBox.Text));

                    foreach (DataRow row in dados.Rows)
                    {
                        labelCpf.Text = row[0].ToString();
                        labelTel1.Text = row[1].ToString();
                        labelTel2.Text = row[2].ToString();
                        email.Text = row[3].ToString();
                        nome.Text = row[4].ToString();
                    }
                }
                else
                {
                    nome.Text = database.selectScalar(string.Format("SELECT nome_usuario" +
                                                        " FROM usuario" +
                                                        " WHERE cod_usuario = '{0}'", codPessoaBox.Text));
                }

            }

        }

        private void BtnNovoProp_Click(object sender, EventArgs e)
        {
            string tipo = groupQuemEmpresta.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();

            if (tipo == "CLIENTE")
            {
                CadastroCliente cadastrarProp = new CadastroCliente();
                cadastrarProp.ShowDialog();

                atualizarGrid(tipo);
            }
        }

        private void BoxProcurarProp_TextChanged(object sender, EventArgs e)
        {
            atualizarGrid(groupQuemEmpresta.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper());
        }

        private void ExcluiProp_Click(object sender, EventArgs e)
        {
            nomePessoaBox.Text = "";
            codPessoaBox.Text = "";
            nomePessoaBox.Visible = false;
            codPessoaBox.Visible = false;
            excluiProp.Visible = false;
            labelCod.Visible = false;
            labelProp.Visible = false;
            btnAdicionarPessoa.Visible = true;

            nome.Text = "";
            labelCpf.Text = "";
            textoTel1.Text = "";
            textoTel2.Text = "";
            email.Text = "";

        }

        private void BtnAdicionarPessoa_Click_1(object sender, EventArgs e)
        {
            atualizarGrid(groupQuemEmpresta.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper());
            painelProp.Visible = true;
            groupQuemEmpresta.Enabled = false;
            groupDadosEmp.Enabled = false;
            groupDadosCliente.Enabled = false;
            groupBox4.Enabled = false;
            btnConfirmar.Enabled = false;
        }

        private void BtnConfirmarProp_Click_1(object sender, EventArgs e)
        {
            if (gridPessoas.CurrentRow.Index != -1)
            {
                codPessoaBox.Text = gridPessoas.CurrentRow.Cells[0].Value.ToString();
                nomePessoaBox.Text = gridPessoas.CurrentRow.Cells[1].Value.ToString(); ;

                painelProp.Visible = false;
                groupQuemEmpresta.Enabled = true;
                groupDadosEmp.Enabled = true;
                groupDadosCliente.Enabled = true;
                groupBox4.Enabled = true;
                btnConfirmar.Enabled = true;
                btnAdicionarPessoa.Visible = false;
                labelProp.Visible = true;
                labelCod.Visible = true;
                codPessoaBox.Visible = true;
                nomePessoaBox.Visible = true;
                excluiProp.Enabled = true;
                excluiProp.Visible = true;

                string tipo = groupQuemEmpresta.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();

                DataTable dados = new DataTable();

                if (tipo == "PROPRIETARIO")
                {
                    dados = database.select(string.Format("SELECT contato, email, nome" +
                                                          " FROM proprietario" +
                                                          " WHERE cod_proprietario = '{0}'", codPessoaBox.Text));

                    foreach (DataRow row in dados.Rows)
                    {
                        labelTel1.Text = row[0].ToString(); ;
                        email.Text = row[1].ToString();
                        nome.Text = row[2].ToString();
                    }
                }
                else if (tipo == "CLIENTE")
                {
                    dados = database.select(string.Format("SELECT cpf, contato_principal, contato_secundario, email, nome_cliente" +
                                            " FROM cliente" +
                                            " WHERE cod_cliente = '{0}'", codPessoaBox.Text));

                    foreach (DataRow row in dados.Rows)
                    {
                        labelCpf.Text = row[0].ToString();
                        labelTel1.Text = row[1].ToString();
                        labelTel2.Text = row[2].ToString();
                        email.Text = row[3].ToString();
                        nome.Text = row[4].ToString();
                    }
                }
                else
                {
                    nome.Text = database.selectScalar(string.Format("SELECT nome_usuario" +
                                                        " FROM usuario" +
                                                        " WHERE cod_usuario = '{0}'", codPessoaBox.Text));
                }

            }

        }

        private void ExcluiProp_Click_1(object sender, EventArgs e)
        {
            nomePessoaBox.Text = "";
            codPessoaBox.Text = "";
            nomePessoaBox.Visible = false;
            codPessoaBox.Visible = false;
            excluiProp.Visible = false;
            labelCod.Visible = false;
            labelProp.Visible = false;
            btnAdicionarPessoa.Visible = true;

            nome.Text = "";
            labelCpf.Text = "";
            textoTel1.Text = "";
            textoTel2.Text = "";
            email.Text = "";

        }

        private void BtnCancelarProp_Click_1(object sender, EventArgs e)
        {
            painelProp.Visible = false;
            groupQuemEmpresta.Enabled = true;
            groupDadosEmp.Enabled = true;
            groupDadosCliente.Enabled = true;
            groupBox4.Enabled = true;
            btnConfirmar.Enabled = true;
        }

        private void BtnNovoProp_Click_1(object sender, EventArgs e)
        {
            string tipo = groupQuemEmpresta.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();

            if (tipo == "CLIENTE")
            {
                CadastroCliente cadastrarProp = new CadastroCliente();
                cadastrarProp.ShowDialog();

                atualizarGrid(tipo);
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            int contErros = 0;
            string erros = "";

            string tipo = groupQuemEmpresta.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToLower();
            string descricao = descBox.Text;
            string codigo = codPessoaBox.Text;
            DateTime dataHojeUs = new DateTime();



            //Quem está emprestando
            if (tipo.Length == 0)
            {
                contErros++;
                erros += "\n-Quem está reservando (Seleção obrigatória)";
            }

            if (codPessoaBox.Text.Length <= 0)
            {
                contErros++;
                erros += "\n-Dados do cliente/funcionário (Inserção obrigatória)";
            }

            if (contErros == 0)
            {
                try
                {
                    if (tipo == "proprietario")
                    {
                        database.insertInto(string.Format("INSERT INTO reserva (cod_chave, data_reserva, cod_proprietario, cod_usuario)" +
                                                            " VALUES ('{0}', '{1}', '{2}', '{3}')", codigoChave, dataHoje,
                                                            codPessoaBox.Text, user));
                    }
                    else if (tipo == "cliente")
                    {
                        database.insertInto(string.Format("INSERT INTO reserva (cod_chave, data_reserva, cod_cliente, cod_usuario)" +
                                                            " VALUES ('{0}', '{1}', '{2}', '{3}')", codigoChave, dataHoje,
                                                            codPessoaBox.Text, user));
                    }
                    else
                    {
                        database.insertInto(string.Format("INSERT INTO reserva (cod_chave, data_reserva, cod_usuario)" +
                                                           " VALUES ('{0}', '{1}', '{2}')", codigoChave, dataHoje, user));
                    }

                    Message popup = new Message("Reserva efetuada com sucesso!", "", "sucesso", "confirma");
                    popup.ShowDialog();

                    this.Close();
                }
                catch (Exception erro)
                {
                    Message popup = new Message("Não foi possível reservar a chave pelo seguinte erro: \n\n- " + erro.Message,
                        "", "erro", "confirma");
                    popup.ShowDialog();

                }

            }
        }
    }
}
