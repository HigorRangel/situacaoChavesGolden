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
    public partial class CadastroReserva : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();

        DateTime dataHoje = DateTime.Now;
        bool seletorTela = false;
        string codigoChave = "";
        string user = "";

        public CadastroReserva(string codChave, string usuario)
        {
            InitializeComponent();

            codigoChave = codChave;
            user = usuario;

        }

        private void buscarDadosChave()
        {
            DataTable dadosChaveEscolhida = new DataTable();

          
            dadosChaveEscolhida = database.select(string.Format("SELECT c.cod_chave, c.cod_imob,  c.rua || ', ' || c.numero || ' - ' || c.bairro as endereco, c.indice_chave " +
                                                                " FROM CHAVE c " +
                                                                " WHERE indice_chave = '{0}'", codigoChave));

            foreach (DataRow linha in dadosChaveEscolhida.Rows)
            {
                gridChaves.Rows.Add(linha[0].ToString(), linha[1].ToString(), linha[2].ToString(), linha[3].ToString(), 0, 0);
            }

        }

        private void btnAdicionarPessoa_Click(object sender, EventArgs e)
        {
            atualizarGrid(groupQuemEmpresta.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper());
            painelProp.Visible = true;
            groupQuemEmpresta.Enabled = false;
            groupDadosEmp.Enabled = false;
            groupDadosCliente.Enabled = false;
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

       
        private void ReservarChave_Load(object sender, EventArgs e)
        {
            dateRetirada.MinDate = dataHoje;

            //endereco.MaximumSize = new Size(160, 49);
            //endereco.AutoSize = true;

            //email.MaximumSize = new Size(160, 25);
            //email.AutoSize = true;


            gridChaves.Columns.Add("codigo", "Cód.");
            gridChaves.Columns.Add("codimob", "Cód Imob");
            gridChaves.Columns.Add("endereco", "Endereço");
            gridChaves.Columns.Add("indice", "");
            gridChaves.Columns.Add("quantChave", "");
            gridChaves.Columns.Add("quantCtrl", "");

            DataGridViewImageColumn cellImage = new DataGridViewImageColumn();
            cellImage.Image = new Bitmap(Properties.Resources.Delete);

            gridChaves.Columns.Insert(6, cellImage);




            gridChaves.Columns[0].Width = 30;
            gridChaves.Columns[1].Width = 75;
            gridChaves.Columns[2].Width = 265;
            gridChaves.Columns[6].Width = 20;
            gridChaves.Columns[3].Visible = false;
            gridChaves.Columns[4].Visible = false;
            gridChaves.Columns[5].Visible = false;


            radioCliente.Checked = true;
            radioProprietario.Checked = false;

            buscarDadosChave();

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

                //if (tipo == "PROPRIETARIO")
                //{
                //    dados = database.select(string.Format("SELECT contato, email, nome" +
                //                                          " FROM proprietario" +
                //                                          " WHERE cod_proprietario = '{0}'", codPessoaBox.Text));

                //    foreach (DataRow row in dados.Rows)
                //    {
                //        labelTel1.Text = row[0].ToString(); ;
                //        email.Text = row[1].ToString();
                //        nome.Text = row[2].ToString();
                //    }
                //}
                //else if (tipo == "CLIENTE")
                //{
                //    dados = database.select(string.Format("SELECT cpf, contato_principal, contato_secundario, email, nome_cliente" +
                //                            " FROM cliente" +
                //                            " WHERE cod_cliente = '{0}'", codPessoaBox.Text));

                //    foreach (DataRow row in dados.Rows)
                //    {
                //        labelCpf.Text = row[0].ToString();
                //        labelTel1.Text = row[1].ToString();
                //        labelTel2.Text = row[2].ToString();
                //        email.Text = row[3].ToString();
                //        nome.Text = row[4].ToString();
                //    }
                //}
                //else
                //{
                //    nome.Text = database.selectScalar(string.Format("SELECT nome_usuario" +
                //                                        " FROM usuario" +
                //                                        " WHERE cod_usuario = '{0}'", codPessoaBox.Text));
                //}

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

        }

        private void BtnAdicionarPessoa_Click_1(object sender, EventArgs e)
        {
            atualizarGrid(groupQuemEmpresta.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper());
            painelProp.Visible = true;
            groupQuemEmpresta.Enabled = false;
            groupDadosEmp.Enabled = false;
            groupDadosCliente.Enabled = false;
            btnConfirmar.Enabled = false;
        }

        private void BtnConfirmarProp_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (gridPessoas.CurrentRow.Index != -1)
                {
                    codPessoaBox.Text = gridPessoas.CurrentRow.Cells[0].Value.ToString();
                    nomePessoaBox.Text = gridPessoas.CurrentRow.Cells[1].Value.ToString(); ;

                    painelProp.Visible = false;
                    groupQuemEmpresta.Enabled = true;
                    groupDadosEmp.Enabled = true;
                    groupDadosCliente.Enabled = true;
                    btnConfirmar.Enabled = true;
                    btnAdicionarPessoa.Visible = false;
                    labelProp.Visible = true;
                    labelCod.Visible = true;
                    codPessoaBox.Visible = true;
                    nomePessoaBox.Visible = true;
                    excluiProp.Enabled = true;
                    excluiProp.Visible = true;

                    string tipo = groupQuemEmpresta.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();

                    //DataTable dados = new DataTable();

                    //if (tipo == "PROPRIETARIO")
                    //{
                    //    dados = database.select(string.Format("SELECT contato, email, nome" +
                    //                                          " FROM proprietario" +
                    //                                          " WHERE cod_proprietario = '{0}'", codPessoaBox.Text));

                    //    foreach (DataRow row in dados.Rows)
                    //    {
                    //        labelTel1.Text = row[0].ToString(); ;
                    //        email.Text = row[1].ToString();
                    //        nome.Text = row[2].ToString();
                    //    }
                    //}
                    //else if (tipo == "CLIENTE")
                    //{
                    //    dados = database.select(string.Format("SELECT cpf, contato_principal, contato_secundario, email, nome_cliente" +
                    //                            " FROM cliente" +
                    //                            " WHERE cod_cliente = '{0}'", codPessoaBox.Text));

                    //    foreach (DataRow row in dados.Rows)
                    //    {
                    //        labelCpf.Text = row[0].ToString();
                    //        labelTel1.Text = row[1].ToString();
                    //        labelTel2.Text = row[2].ToString();
                    //        email.Text = row[3].ToString();
                    //        nome.Text = row[4].ToString();
                    //    }
                    //}
                    //else
                    //{
                    //    nome.Text = database.selectScalar(string.Format("SELECT nome_usuario" +
                    //                                        " FROM usuario" +
                    //                                        " WHERE cod_usuario = '{0}'", codPessoaBox.Text));
                    //}

                }
            }
            catch (NullReferenceException)
            {
                Message msg = new Message("Você não selecionou nenhum cliente/proprietário!", "", "erro", "confirma");
                msg.ShowDialog();
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


        }

        private void BtnCancelarProp_Click_1(object sender, EventArgs e)
        {
            painelProp.Visible = false;
            groupQuemEmpresta.Enabled = true;
            groupDadosEmp.Enabled = true;
            groupDadosCliente.Enabled = true;
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

            FormatarStrings format = new FormatarStrings();

            string tipo = groupQuemEmpresta.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToLower();
            string descricao = format.inserirBD(descBox.Text);
            string codigo = codPessoaBox.Text;
            string codCliente = "";
            DateTime dataHojeUs = new DateTime();
            DateTime dataRetirada = new DateTime();


            //Data de previsão
            try
            {
                dataRetirada = dateRetirada.Value;

                dataRetirada = Convert.ToDateTime(dataRetirada.ToString("yyyy-MM-dd HH:mm:ss"));
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
            if (dataRetirada.Date == null)
            {
                contErros++;
                erros += "\n-Previsão de entrega (Seleção obrigatória)";
            }

            if (codPessoaBox.Text.Length <= 0)
            {
                contErros++;
                erros += "\n-Dados do cliente/funcionário (Inserção obrigatória)";
            }
            if(gridChaves.Rows.Count == 0)
            {
                contErros++;
                erros += "\n-Nenhuma chave selecionada!";
            }

            int contErrosProp = 0;
            foreach (DataGridViewRow row in gridChaves.Rows)
            {
             
                string proprietario = database.selectScalar(string.Format("SELECT proprietario" +
                                                            " FROM chave" +
                                                            " WHERE indice_chave = '{0}'", row.Cells[3].Value.ToString()));

                if (proprietario != codPessoaBox.Text && radioProprietario.Checked)
                {
                    contErrosProp++;
                    contErros++;
                }

            }


            if (contErrosProp > 0)
            {
                erros += "\n-Nem todas as chaves pertencem ao mesmo proprietário!";
            }
            if (contErros == 0)
            {
                try
                {
                    if (tipo == "proprietario")
                    {
                   


                        database.insertInto(string.Format("" +
                          "INSERT INTO reserva (data_reserva, descricao, cod_usuario, cod_proprietario)" +
                          " VALUES ('{0}', '{1}', '{2}', '{3}')",
                          dataHoje, descricao, user, codPessoaBox.Text));
                    }
                    else if (tipo == "cliente")
                    {
                        database.insertInto(string.Format("" +
                           "INSERT INTO reserva (data_reserva, descricao, cod_usuario, cod_cliente)" +
                           " VALUES ('{0}', '{1}', '{2}', '{3}')",
                           dataHoje, descricao, user, codPessoaBox.Text));
                    }
                    else
                    {
                        database.insertInto(string.Format("" +
                          "INSERT INTO reserva (data_reserva, descricao, cod_usuario)" +
                          " VALUES ('{0}', '{1}', '{2}')",
                          dataHoje, descricao,  codPessoaBox.Text));
                    }

                    foreach (DataGridViewRow row in gridChaves.Rows)
                    {

                        database.insertInto(string.Format("INSERT INTO chaves_reserva" +
                                                            " VALUES ((SELECT MAX(cod_reserva) FROM reserva), '{0}')", row.Cells[3].Value.ToString()));

                   
                    }


                    Message caixaMensagem = new Message("Reserva cadastrada com sucesso!", "", "sucesso", "confirma");
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

            //}
            else
            {
                Message caixaMensagem = new Message("Corrija os erros abaixo antes de continuar!\n-" + erros, "Erro de preenchimento",
                    "erro", "confirma");
                caixaMensagem.ShowDialog();
            }
        





        //    int contErros = 0;
        //    string erros = "";

        //    FormatarStrings format = new FormatarStrings();

        //    string tipo = groupQuemEmpresta.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToLower();
        //    string descricao = format.inserirBD(descBox.Text);
        //    string codigo = codPessoaBox.Text;
        //    DateTime dataHojeUs = new DateTime();



        //    //Quem está emprestando
        //    if (tipo.Length == 0)
        //    {
        //        contErros++;
        //        erros += "\n-Quem está reservando (Seleção obrigatória)";
        //    }

        //    if (codPessoaBox.Text.Length <= 0)
        //    {
        //        contErros++;
        //        erros += "\n-Dados do cliente/funcionário (Inserção obrigatória)";
        //    }

        //    if (contErros == 0)
        //    {
        //        //try
        //        //{
        //            if (tipo == "proprietario")
        //            {
        //                database.insertInto(string.Format("INSERT INTO reserva (cod_chave, data_reserva, cod_proprietario, cod_usuario, descricao)" +
        //                                                    " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", codigoChave, dateRetirada.Value,
        //                                                    codPessoaBox.Text, user, format.inserirBD(descBox.Text)));
        //            }
        //            else if (tipo == "cliente")
        //            {
        //                database.insertInto(string.Format("INSERT INTO reserva (cod_chave, data_reserva, cod_cliente, cod_usuario, descricao)" +
        //                                                    " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", codigoChave, dateRetirada.Value,
        //                                                    codPessoaBox.Text, user, format.inserirBD(descBox.Text)));
        //            }
        //            else
        //            {
        //                database.insertInto(string.Format("INSERT INTO reserva (cod_chave, data_reserva, cod_usuario, descricao)" +
        //                                                   " VALUES ('{0}', '{1}', '{2}', '{3}')", codigoChave, dateRetirada.Value, user, format.inserirBD(descBox.Text)));
        //            }

        //            Message popup = new Message("Reserva efetuada com sucesso!", "", "sucesso", "confirma");
        //            popup.ShowDialog();

        //            this.Close();
        //        //}
        //        //catch (Exception erro)
        //        //{
        //        //    Message popup = new Message("Não foi possível reservar a chave pelo seguinte erro: \n\n- " + erro.Message,
        //        //        "", "erro", "confirma");
        //        //    popup.ShowDialog();

        //        //}

        //    }
    }

    private void radioChanged(object sender, EventArgs e)
        {
           
            if (radioProprietario.Checked)
            {
                nomePessoaBox.Visible = true;
                codPessoaBox.Visible = true;
                excluiProp.Enabled = false;
                excluiProp.Visible = true;
                labelCod.Visible = true;
                labelProp.Visible = true;
                btnAdicionarPessoa.Visible = false;
                try
                {
                    DataTable dadosProp = new DataTable();

                    dadosProp = database.select(string.Format("SELECT p.cod_proprietario, p.nome " +
                                                               " FROM proprietario p " +
                                                               " INNER JOIN chave c ON c.proprietario = p.cod_proprietario" +
                                                               " WHERE c.indice_chave = '{0}'", gridChaves.Rows[0].Cells[3].Value.ToString()));

                   

                    foreach (DataRow row in dadosProp.Rows)
                    {
                        codPessoaBox.Text = row[0].ToString();
                        nomePessoaBox.Text = row[1].ToString();
                    }
                }
                catch { }
                

            }
            else if (radioFuncionario.Checked)
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

            }
            else if (radioCliente.Checked)
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
                
            }

        }

        private void PainelProp_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DatePrevisao_ValueChanged(object sender, EventArgs e)
        {

        }

        private void MetroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.ForeColor = Color.White;
        }

        private void BtnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.ForeColor = Color.FromArgb(0, 109, 156);

        }

        private void BtnAddChave_Click(object sender, EventArgs e)
        {
            panelChaves.Visible = true;
            atualizarGridChaves(gridChaves);

            groupQuemEmpresta.Enabled = false;
            groupDadosEmp.Enabled = false;
            groupDadosCliente.Enabled = false;
            //groupBox4.Enabled = false;
            btnConfirmar.Enabled = false;
        }

        private void atualizarGridChaves(DataGridView tabela)
        {

            //List<string> codigos = new List<string>();
            string codigos = "";
            string proprietario = "";

            if (radioProprietario.Checked == true)
            {
                string codProp = codPessoaBox.Text;

                if (codPessoaBox.Text == "")
                {
                    codProp = "%%";
                }
                proprietario = string.Format("AND proprietario::text ILIKE '{0}'", codProp);
            }

            int cont = 0;


            foreach (DataGridViewRow row in tabela.Rows)
            {
                if (cont != tabela.Rows.Count)
                {
                    codigos += " AND ";
                }

                codigos += string.Format(" c.indice_chave != {0} ", row.Cells[3].Value.ToString());



                cont++;

            }

            DataTable tabelaChaves = new DataTable();



            tabelaChaves = database.select(string.Format("" +
                "SELECT c.cod_chave, c.cod_imob,  c.rua || ', ' || c.numero || ' - ' || c.bairro as endereco, c.indice_chave, 0, 0 " +
                " FROM CHAVE c " +
                " INNER JOIN proprietario p ON p.cod_proprietario = c.proprietario" +
                " WHERE c.situacao = 'DISPONIVEL' AND (c.rua ILIKE '%{0}%' OR c.cod_imob ILIKE '%{0}%' OR (unaccent(lower(c.rua))) ILIKE '%{0}%' OR" +
                " (unaccent(lower(c.bairro))) ILIKE '%{0}%' OR c.cod_chave::text ILIKE '%{0}%') {1} {2}", boxBusca.Text, codigos, proprietario));

            gridChavesTotal.DataSource = tabelaChaves;

            gridChavesTotal.Columns[0].HeaderText = "Cód";
            gridChavesTotal.Columns[1].HeaderText = "Cód Imob";
            gridChavesTotal.Columns[2].HeaderText = "Endereço";

            gridChavesTotal.Columns[0].Width = 35;
            gridChavesTotal.Columns[1].Width = 75;
            gridChavesTotal.Columns[2].Width = 290;
            gridChavesTotal.Columns[3].Visible = false;
            gridChavesTotal.Columns[4].Visible = false;
            gridChavesTotal.Columns[5].Visible = false;

        }

        private void BtnCancelarChave_Click(object sender, EventArgs e)
        {
            panelChaves.Visible = false;
            groupQuemEmpresta.Enabled = true;
            groupDadosEmp.Enabled = true;
            groupDadosCliente.Enabled = true;
            btnConfirmar.Enabled = true;

        }

        private void BtnConfirmChave_Click(object sender, EventArgs e)
        {
            panelChaves.Visible = false;
            groupQuemEmpresta.Enabled = true;
            groupDadosEmp.Enabled = true;
            groupDadosCliente.Enabled = true;
            btnConfirmar.Enabled = true;


            if (gridChaves.Rows.Count + gridChavesTotal.SelectedRows.Count > 10)
            {
                Message txtMsg = new Message("Limite de reserva atingido (10)!", "Erro", "erro", "confirma");
                txtMsg.ShowDialog();
            }
            else
            {
                foreach (DataGridViewRow row in gridChavesTotal.SelectedRows)
                {

                    gridChaves.Rows.Add(row.Cells[0].Value.ToString(),
                                   row.Cells[1].Value.ToString(),
                                   row.Cells[2].Value.ToString(),
                                   row.Cells[3].Value.ToString(),
                                   row.Cells[4].Value,
                                   row.Cells[5].Value);

                    gridChavesTotal.Rows.RemoveAt(row.Index);




                    panelChaves.Visible = false;
                }
            }
        }

        private void GridChaves_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (radioProprietario.Checked)
            {
                try
                {
                    DataTable dadosProp = new DataTable();

                    dadosProp = database.select(string.Format("SELECT p.cod_proprietario, p.nome " +
                                                               " FROM proprietario p " +
                                                               " INNER JOIN chave c ON c.proprietario = p.cod_proprietario" +
                                                               " WHERE c.indice_chave = '{0}'", gridChaves.Rows[0].Cells[3].Value.ToString()));



                    foreach (DataRow row in dadosProp.Rows)
                    {
                        codPessoaBox.Text = row[0].ToString();
                        nomePessoaBox.Text = row[1].ToString();
                    }
                }
                catch
                {
                    codPessoaBox.Text = "";
                    nomePessoaBox.Text = "";
                }
            }
           
           


            if (gridChaves.Rows.Count == 0)
            {
                btnConfirmar.Enabled = false;
            }
            else
            {
                btnConfirmar.Enabled = true;
            }

            if (radioProprietario.Checked)
            {
                radioProprietario.Checked = true;
            }

            if (gridChaves.Rows.Count >= 10)
            {
                btnAddChave.Enabled = false;
            }
            else
            {
                btnAddChave.Enabled = true;

            }
        }

        private void GridChaves_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (radioProprietario.Checked)
            {
                try
                {
                    DataTable dadosProp = new DataTable();

                    dadosProp = database.select(string.Format("SELECT p.cod_proprietario, p.nome " +
                                                               " FROM proprietario p " +
                                                               " INNER JOIN chave c ON c.proprietario = p.cod_proprietario" +
                                                               " WHERE c.indice_chave = '{0}'", gridChaves.Rows[0].Cells[3].Value.ToString()));



                    foreach (DataRow row in dadosProp.Rows)
                    {
                        codPessoaBox.Text = row[0].ToString();
                        nomePessoaBox.Text = row[1].ToString();
                    }
                }
                catch
                {
                    codPessoaBox.Text = "";
                    nomePessoaBox.Text = "";
                }
            }
            

            if (gridChaves.Rows.Count == 0)
            {
                btnConfirmar.Enabled = false;
            }
            else
            {
                btnConfirmar.Enabled = true;
            }

            if (radioProprietario.Checked && gridChaves.Rows.Count == 0)
            {
                nomePessoaBox.Text = "";
                codPessoaBox.Text = "";
                nomePessoaBox.Visible = false;
                codPessoaBox.Visible = false;
                excluiProp.Visible = false;
                labelCod.Visible = false;
                labelProp.Visible = false;
                btnAdicionarPessoa.Visible = true;
                radioCliente.Checked = true;
            }

            if (gridChaves.Rows.Count >= 10)
            {
                btnAddChave.Enabled = false;
            }
            else
            {
                btnAddChave.Enabled = true;

            }
        }

        private void GridChaves_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                gridChaves.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void GridChaves_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {

                gridChaves.Cursor = Cursors.Hand;
            }
            if (e.ColumnIndex != 6)
            {
                gridChaves.Cursor = Cursors.Arrow;
            }
        }

        private void BoxProcurarProp_TextChanged_1(object sender, EventArgs e)
        {
            atualizarGrid(groupQuemEmpresta.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper());
        }
    }

}
