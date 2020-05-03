using System;
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
        string codigoReserva = "";

        public CadastrarEmprestimo(string usuario, string codReserva, string codChave)
        {
            InitializeComponent();
            seletorTela = true;
            user = usuario;
            codigoReserva = codReserva;
            codigoChave = codChave;
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


        private string verificarReservaPessoa()
        {
            string quem = "";
            if (radioCliente.Checked) { quem = "r.cod_cliente"; }
            if (radioFuncionario.Checked) { quem = "r.cod_usuario"; }
            if (radioProprietario.Checked) { quem = "r.cod_proprietario"; }

            DataTable tabelaReserva = new DataTable();

            tabelaReserva = database.select(string.Format("SELECT r.cod_reserva, " +
                                                        " (CASE  " +

                                                                " WHEN " +
                                                                    " (CASE " +

                                                                        " WHEN r.cod_proprietario is null AND r.cod_cliente is null THEN 'FUNCIONARIO' " +
                                                                       "  WHEN r.cod_proprietario is null AND r.cod_cliente is not null THEN 'CLIENTE' " +
                                                                        " WHEN r.cod_proprietario is not null AND r.cod_cliente is null THEN 'PROPRIETARIO' END) " +
                                                                          " = 'CLIENTE' THEN r.cod_cliente " +
                                                                 "  WHEN " +
                                                                      " (CASE " +
                                                                          " WHEN r.cod_proprietario is null AND r.cod_cliente is null THEN 'FUNCIONARIO' " +
                                                                        " WHEN r.cod_proprietario is null AND r.cod_cliente is not null THEN 'CLIENTE' " +
                                                                        " WHEN r.cod_proprietario is not null AND r.cod_cliente is null THEN 'PROPRIETARIO' END) " +
                                                                          " = 'PROPRIETARIO' THEN r.cod_proprietario " +
                                                                 " WHEN " +
                                                                      " (CASE " +
                                                                          " WHEN r.cod_proprietario is null AND r.cod_cliente is null THEN 'FUNCIONARIO' " +
                                                                        " WHEN r.cod_proprietario is null AND r.cod_cliente is not null THEN 'CLIENTE' " +
                                                                        " WHEN r.cod_proprietario is not null AND r.cod_cliente is null THEN 'PROPRIETARIO' END) " +
                                                                          " = 'FUNCIONARIO' THEN r.cod_usuario END " +
                                                                               " ) " +
                                                        " FROM reserva r " +
                                                        " INNER JOIN chave c ON c.indice_chave = r.cod_chave " +
                                                        " WHERE indice_chave = '{0}' AND {1} = '{2}' AND r.situacao != 'FINALIZADO'", codigoChave, quem, codPessoaBox.Text));

            string codigoReserva = "";

            if (tabelaReserva.Rows.Count == 0)
            {
                codigoReserva = "";
            }
            else
            {
                codigoReserva = tabelaReserva.Rows[0][0].ToString();

            }

            return codigoReserva;
        }

       private DialogResult verificarReserva()
        {

            DataTable reservas = new DataTable();

            reservas = database.select(string.Format("SELECT cod_reserva, (CASE " +

                                                                 " WHEN " +
                                                                     " (CASE " +
                                                                         " WHEN r.cod_proprietario is null AND r.cod_cliente is null THEN 'FUNCIONARIO' " +
                                                                         " WHEN r.cod_proprietario is null AND r.cod_cliente is not null THEN 'CLIENTE' " +
                                                                         " WHEN r.cod_proprietario is not null AND r.cod_cliente is null THEN 'PROPRIETARIO' END) " +
                                                                           " = 'CLIENTE' THEN('(' || cl.cod_cliente || ') - ' || cl.nome_cliente || ' - ' || to_char(r.data_reserva, 'DD/MM/YYYY') || ' (CLIENTE)') " +
                                                                   " WHEN " +
                                                                       " (CASE " +
                                                                           " WHEN r.cod_proprietario is null AND r.cod_cliente is null THEN 'FUNCIONARIO' " +
                                                                         " WHEN r.cod_proprietario is null AND r.cod_cliente is not null THEN 'CLIENTE' " +
                                                                         " WHEN r.cod_proprietario is not null AND r.cod_cliente is null THEN 'PROPRIETARIO' END) " +
                                                                          "  = 'PROPRIETARIO' THEN('(' || p.cod_proprietario || ') - ' || p.nome || ' - ' || to_char(r.data_reserva, 'DD/MM/YYYY') || ' (PROPRIETÁRIO)') " +
                                                                  " WHEN " +
                                                                       " (CASE " +
                                                                          "  WHEN r.cod_proprietario is null AND r.cod_cliente is null THEN 'FUNCIONARIO' " +
                                                                        "  WHEN r.cod_proprietario is null AND r.cod_cliente is not null THEN 'CLIENTE' " +
                                                                        "  WHEN r.cod_proprietario is not null AND r.cod_cliente is null THEN 'PROPRIETARIO' END) " +
                                                                          "  = 'FUNCIONARIO' THEN('(' || u.cod_usuario || ') - ' || u.nome_usuario || ' - ' || to_char(r.data_reserva, 'DD/MM/YYYY') || ' (FUNCIONÁRIO)') END " +
                                                                                " ) " +
                                                                " FROM reserva r " +
                                                                " LEFT JOIN cliente cl ON cl.cod_cliente = r.cod_cliente " +
                                                                " LEFT JOIN proprietario p ON r.cod_proprietario = p.cod_proprietario " +
                                                                " LEFT JOIN usuario u ON r.cod_usuario = u.cod_usuario " +
                                                                " WHERE r.situacao != 'FINALIZADO' AND r.cod_chave = {0} " +
                                                                " ORDER BY r.data_reserva", codigoChave));

            string textoReserva = "ATENÇÃO! Há uma ou mais reservas para esta chave descritas abaixo." +
                " Deseja realmente emprestar esta chave?\n";
            DialogResult resultado = new DialogResult();

            if(reservas.Rows.Count != 0 && (verificarReservaPessoa() != "" && reservas.Rows.Count == 1) == false)
            {
                foreach(DataRow row in reservas.Rows)
                {
                    textoReserva += string.Format("\n - Reserva: {0} || {1}",row[0].ToString(), row[1].ToString());
                }

                Message telaAviso = new Message(textoReserva, "Aviso", "aviso", "escolha");
                telaAviso.ShowDialog();

                resultado = telaAviso.DialogResult;
            }
            else
            {
                resultado = DialogResult.Yes;
            }

            return resultado;            
        }

        private void buscarDadosChave()
        {

            DataTable dadosChave = new DataTable();
            if (seletorTela == true)
            {
                btnAdicionarPessoa.Visible = false;
                codPessoaBox.Visible = true;
                nomePessoaBox.Visible = true;
                excluiProp.Enabled = false;
                groupQuemEmpresta.Enabled = false;

                dadosChave = database.select(string.Format("" +
               "SELECT c.cod_imob, c.rua, c.numero, c.complemento, c.bairro, c.cidade, c.estado, " +
               " (CASE WHEN r.cod_proprietario is null AND r.cod_cliente is null THEN 'FUNCIONARIO' " +
                       " WHEN r.cod_proprietario is null AND r.cod_cliente is not null THEN 'CLIENTE' " +
                       " WHEN r.cod_proprietario is not null AND r.cod_cliente is null THEN 'PROPRIETARIO' END) as tipo, " +
                        " cl.cod_cliente, cl.nome_cliente, p.cod_proprietario, p.nome, u.cod_usuario, u.nome_usuario " +
               " FROM reserva r " +
               " LEFT JOIN cliente cl ON cl.cod_cliente = r.cod_cliente " +
               " LEFT JOIN proprietario p ON p.cod_proprietario = r.cod_proprietario " +
               " LEFT JOIN usuario u ON u.cod_usuario = r.cod_usuario " +
               " LEFT JOIN chave c ON r.cod_chave = c.indice_chave " +
               " WHERE r.cod_reserva = '{0}'", codigoReserva));

                foreach (DataRow row in dadosChave.Rows)
                {
                    codigoChaveBox.Text = row[0].ToString();
                    textoCodChave.Text = row[0].ToString();
                    endereco.Text = string.Format("{0}, {1} ({2}) - {3} - {4}/{5}", row[1], row[2], row[3], row[4], row[5], row[6]);
                    if(row[7].ToString() == "CLIENTE") {
                        codPessoaBox.Text = row[8].ToString();
                        nomePessoaBox.Text = row[9].ToString();
                        radioCliente.Checked = true;
                    }
                    else if (row[7].ToString() == "PROPRIETARIO")
                    {
                        codPessoaBox.Text = row[10].ToString();
                        nomePessoaBox.Text = row[11].ToString();
                        radioProprietario.Checked = true;
                    }
                    else
                    {
                        codPessoaBox.Text = row[12].ToString();
                        nomePessoaBox.Text = row[13].ToString();
                        radioFuncionario.Checked = true;
                    }
                }
            }
            else
            {
                dadosChave = database.select(string.Format("" +
                "SELECT cod_imob, rua, numero, complemento, bairro, cidade, estado" +
                " FROM chave" +
                " WHERE indice_chave = '{0}'", codigoChave));

                foreach (DataRow row in dadosChave.Rows)
                {
                    codigoChaveBox.Text = row[0].ToString();
                    textoCodChave.Text = row[0].ToString();
                    endereco.Text = string.Format("{0}, {1} ({2}) - {3} - {4}/{5}", row[1], row[2], row[3], row[4], row[5], row[6]);
                }
            }

            

           
        }


        private void CadastrarEmprestimo_Load(object sender, EventArgs e)
        {
            buscarDadosChave();

            endereco.MaximumSize = new Size(160, 49);
            endereco.AutoSize = true;

            email.MaximumSize = new Size(160, 25);
            email.AutoSize = true;


           

            datePrevisao.Value = dataHoje.AddDays(1);
            datePrevisao.MinDate = dataHoje.AddDays(1);
            datePrevisao.MaxDate = dataHoje.AddDays(30);

           
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
                comboDocs.Enabled = false;
                boxDescDoc.Enabled = false;

                DataTable dadosProp = new DataTable();

                dadosProp = database.select(string.Format("SELECT p.cod_proprietario, p.nome " +
                                                           " FROM proprietario p " +
                                                           " INNER JOIN chave c ON c.proprietario = p.cod_proprietario" +
                                                           " WHERE c.indice_chave = '{0}'", codigoChave));

                nomePessoaBox.Visible = true;
                codPessoaBox.Visible = true;
                excluiProp.Enabled = false;
                excluiProp.Visible = true;
                labelCod.Visible = true;
                labelProp.Visible = true;
                btnAdicionarPessoa.Visible = false;

                foreach (DataRow row in dadosProp.Rows)
                {
                    codPessoaBox.Text = row[0].ToString();
                    nomePessoaBox.Text = row[1].ToString();
                }

            }
            else if(radioFuncionario.Checked)
            {
                nomePessoaBox.Visible = false;
                codPessoaBox.Visible = false;
                excluiProp.Enabled = false;
                excluiProp.Visible = false;
                labelCod.Visible = false;
                labelProp.Visible = false;
                btnAdicionarPessoa.Visible = true;

                comboDocs.Enabled = false;
                boxDescDoc.Enabled = false;
            }
            else
            {

                nomePessoaBox.Visible = false;
                codPessoaBox.Visible = false;
                excluiProp.Enabled = false;
                excluiProp.Visible = false;
                labelCod.Visible = false;
                labelProp.Visible = false;
                btnAdicionarPessoa.Visible = true;

                codPessoaBox.Text = "";
                nomePessoaBox.Text = "";
                comboDocs.Enabled = true;
                boxDescDoc.Enabled = true;
            }
        }

      

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnEditarCliente_Click(object sender, EventArgs e)
        {
           // CadastroCliente editar = new CadastroCliente(codigosClientes[comboClientes.SelectedIndex]);
            //editar.ShowDialog();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if(verificarReserva() == DialogResult.Yes)
            {
                int contErros = 0;
                string erros = "";

                string tipo = groupQuemEmpresta.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToLower();
                decimal quantChaves = qtdChaves.Value;
                decimal quantControles = qtdControles.Value;
                string descricao = descBox.Text;
                string codigo = codPessoaBox.Text;
                string descricaoDocumento = boxDescDoc.Text;
                string documentoDeixado = "";
                string codCliente = "";
                DateTime dataHojeUs = new DateTime();
                DateTime dataPrevisao = new DateTime();


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



                //Quem está emprestando
                if (tipo.Length == 0)
                {
                    contErros++;
                    erros += "\n-Quem está emprestando (Seleção obrigatória)";
                }
                //Data previsão
                if (dataPrevisao.Date == null)
                {
                    contErros++;
                    erros += "\n-Previsão de entrega (Seleção obrigatória)";
                }
                //Quantidade de chaves
                if (quantChaves == 0 && quantControles == 0)
                {
                    contErros++;
                    erros += "\n-Quantidade de chaves (Inserção obrigatória)";
                }
                //Quantidade de controles
                if (quantControles == 0 && quantChaves == 0)
                {
                    contErros++;
                    erros += "\n-Quantidade de controles (Inserção obrigatória)";
                }

                if (comboDocs.SelectedIndex != -1 && descricaoDocumento.Length == 0)
                {
                    contErros++;
                    erros += "\n-Descrição do Documento (Inserção obrigatória)";
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
                            database.insertInto(string.Format("" +
                               "INSERT INTO emprestimo (quant_chaves, documento, data_retirada, entrega_prevista, descricao, cod_chave," +
                               " cod_usuario, quant_controles, tipo_doc, cod_proprietario)" +
                               " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                               quantChaves, descricaoDocumento, dataHoje, dataPrevisao, descricao, codigoChave,
                               user, quantControles, documentoDeixado, codPessoaBox.Text));
                        }
                        else if (tipo == "cliente")
                        {
                            database.insertInto(string.Format("" +
                               "INSERT INTO emprestimo (quant_chaves, documento, data_retirada, entrega_prevista, descricao, cod_chave," +
                               " cod_usuario, quant_controles, tipo_doc, cod_cliente)" +
                               " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                               quantChaves, descricaoDocumento, dataHoje, dataPrevisao, descricao, codigoChave,
                               user, quantControles, documentoDeixado, codPessoaBox.Text));
                        }
                        else
                        {
                            database.insertInto(string.Format("" +
                               "INSERT INTO emprestimo (quant_chaves, documento, data_retirada, entrega_prevista, descricao, cod_chave," +
                               " cod_usuario, quant_controles, tipo_doc)" +
                               " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')",
                               quantChaves, descricaoDocumento, dataHoje, dataPrevisao, descricao, codigoChave,
                               user, quantControles, documentoDeixado));
                        }

                        database.update(string.Format("UPDATE chave" +
                                                      " SET situacao = 'INDISPONIVEL', localizacao = '{0}'" +
                                                      " WHERE indice_chave = '{1}'", tipo.ToUpper(), codigoChave));

                        if (seletorTela == true)
                        {
                            database.update(string.Format("UPDATE reserva" +
                                                      " SET situacao = 'FINALIZADO'" +
                                                      " WHERE cod_reserva = '{0}'", codigoReserva));
                        }

                        string codReserva = verificarReservaPessoa();

                        if (codReserva != "")
                        {
                            database.update(string.Format("UPDATE reserva" +
                                            " SET situacao = 'FINALIZADO'" +
                                            " WHERE cod_reserva = '{0}'", codReserva));
                        }

                        Message caixaMensagem = new Message("Empréstimo cadastrado com sucesso!", "", "sucesso", "confirma");
                        caixaMensagem.ShowDialog();

                        this.Close();
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception erro)
                    {
                        Message caixaMensagem = new Message("Erro ao cadastrar! \n\nDescrição: " + erro.Message, "Erro no banco de dados", "erro", "confirma");
                        caixaMensagem.ShowDialog();
                    }

                }
                else
                {
                    Message caixaMensagem = new Message("Corrija os erros abaixo antes de continuar!\n-" + erros, "Erro de preenchimento",
                        "erro", "confirma");
                    caixaMensagem.ShowDialog();
                }
            }
            

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

        private void atualizarGrid (string tipo)
        {
            if(tipo == "CLIENTE")
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
            if(gridPessoas.CurrentRow.Index != -1)
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

                if(tipo == "PROPRIETARIO")
                {
                    dados = database.select(string.Format("SELECT contato, email, nome" +
                                                          " FROM proprietario" +
                                                          " WHERE cod_proprietario = '{0}'", codPessoaBox.Text));

                    foreach (DataRow row in dados.Rows)
                    {
                        labelTel1.Text = row[0].ToString();;
                        email.Text = row[1].ToString();
                        nome.Text = row[2].ToString();
                    }
                }
                else if(tipo == "CLIENTE")
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

        private void GroupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
