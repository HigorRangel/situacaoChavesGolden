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
    public partial class cadastroChave : MetroFramework.Forms.MetroForm
    {


        PostgreSQL database = new PostgreSQL();
        bool seletorTela = false;
        string codChave = "";
        DateTime dataHoje = DateTime.Now;
        string usuario = "";

        public cadastroChave(string codigoChave, string user)
        {
            InitializeComponent();
            seletorTela = true;
            codChave = codigoChave;
            usuario = user;

        }

        public cadastroChave(string user)
        {
            InitializeComponent();
            usuario = user;
        }

        public string proximoCodigo()
        {
            string proxCodigo = "";
            DataTable codigos = new DataTable();

            codigos = database.select("SELECT cod_chave FROM chave  WHERE cod_chave is not null ORDER BY cod_chave");
            List<int> arrayCodigos = new List<int>();
            // int[] arrayCodigos = new int[codigos.Rows.Count];

            if(codigos.Rows.Count != 0)
            {
                foreach (DataRow row in codigos.Rows)
                {
                    //MessageBox.Show(row[0].ToString());
                    try
                    {
                        arrayCodigos.Add(int.Parse(row[0].ToString()));
                    }
                    catch (System.FormatException)
                    {

                    }
                    
                }
                for (int i = 0; i <= codigos.Rows.Count; i++)
                {
                    try
                    {
                        if (arrayCodigos[i] != i + 1)
                        {
                            proxCodigo = (i + 1).ToString();
                            break;
                        }
                    }
                    catch
                    {
                        proxCodigo = (i+1).ToString();
                    }
                    

                }
            }
            else
            {
                proxCodigo = "1";
            }

            

            return proxCodigo;
        }
        private void CadastroChave_Load(object sender, EventArgs e)
        {


            //MessageBox.Show(proximoCodigo());

            codImovel.Focus();

            if(seletorTela == true)
            {
                DataTable dadosChave = new DataTable();

                dadosChave = database.select(string.Format("SELECT * FROM chave WHERE indice_chave = '{0}'", codChave));


                foreach(DataRow row in dadosChave.Rows)
                {
                    boxLogradouro.Text = row[1].ToString();
                    boxNumero.Text = row[5].ToString();
                    boxComplemento.Text = row[6].ToString();
                    boxBairro.Text = row[2].ToString();
                    boxCidade.Text = row[3].ToString();
                    boxEstado.Text = row[4].ToString();

                    //MessageBox.Show(row[8].ToString());

                    if(row[8].ToString() != "IMOBILIARIA" && row[8].ToString() != "PORTARIA")
                    {
                        comboLocalizacao.SelectedItem = "Outro";
                        boxOutraLocalizacao.Text = row[8].ToString();
                    }
                    else
                    {
                        comboLocalizacao.SelectedItem = row[8].ToString();

                    }
                    codImovel.Text = row[10].ToString();
                    boxQtdChaves.Value = int.Parse(row[15].ToString());
                    boxCond.Text = row[16].ToString();
                    boxCategImov.Text = row[17].ToString();
                    boxAviso.Text = row[18].ToString();
                    
                    if(row[7].ToString() == "DISPONIVEL")
                    {
                        radioChaveDisponivel.Checked = true;
                    }
                    else
                    {
                        radioChaveIndisponivel.Checked = true;
                    }
                    if(row[12].ToString() == "RESIDENCIAL")
                    {
                        radioTipoRes.Checked = true;
                    }
                    else
                    {
                        radioTipoCom.Checked = true;
                    }
                    if(row[13].ToString() == "LOCAÇÃO")
                    {
                        checkLocacao.Checked = true;
                        checkVenda.Checked = false;
                    }
                    else if( row[13].ToString() == "VENDA")
                    {
                        checkLocacao.Checked = false;
                        checkVenda.Checked = true;
                    }
                    else
                    {
                        checkVenda.Checked = true;
                        checkLocacao.Checked = true;
                    }

                    if(row[11].ToString() == "ATIVO")
                    {
                        radioImovAtivo.Checked = true;
                    }
                    else
                    {
                        radioImovInativo.Checked = true;
                    }


                    nomePropBox.Text = database.selectScalar(string.Format("" +
                        "SELECT nome FROM proprietario WHERE cod_proprietario = '{0}'", row[9].ToString()));

                    boxCodProp.Text = row[9].ToString();

                    nomePropBox.Visible = true;
                    boxCodProp.Visible = true;
                    excluiProp.Visible = true;
                    labelCod.Visible = true;
                    labelProp.Visible = true;
                    btnAdicionarProp.Visible = false;
                }


            }

        }

        private void BtnCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.ForeColor = Color.White;
            btnCancelar.BackColor = Color.FromArgb(1, 66, 94);
        }


        bool verificarExistencia(string codImob)
        {
            string contRegistros = database.selectScalar(string.Format("SELECT COUNT(*) FROM chave WHERE (cod_imob ILIKE '{0}%' OR cod_imob ILIKE '/'||'{0}%')", codImob));
            bool verif = false;

            if(int.Parse(contRegistros) > 0)
            {
                verif = true;
            }

            return verif;
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            int contErro = 0;

            string erro = "Não foi possível cadastrar a chave. Por favor, verifique os campos abaixo:\n";

            if(codImovel.Text.Length == 0)
            {
                erro += "\n- Código do Imóvel (não pode ficar vazio)";
                contErro++;
            }
            if(comboLocalizacao.SelectedIndex == -1)
            {
                erro += "\n- Localização do imóvel (Não pode ficar vazio)";
                contErro++;
            }

            try
            {
                if (boxOutraLocalizacao.Text.Length <= 0 && comboLocalizacao.SelectedItem.ToString() == "Outro")
                {
                    erro += "\n- Outra localização (Não pode ficar vazio)";
                    contErro++;
                }
            }
            catch { }
           
            if(boxLogradouro.Text.Length == 0)
            {
                erro += "\n- Logradouro (Não pode ficar vazio)";
                contErro++;
            }
            if(boxCidade.Text.Length == 0)
            {
                erro += "\n- Cidade(Não pode ficar vazio)";
                contErro++;
            }
            if(boxBairro.Text.Length == 0)
            {
                erro += "\n- Bairro (Não pode ficar vazio)";
                contErro++;
            }
            if(boxEstado.Text.Length == 0)
            {
                erro += "\n- Estado (Não pode ficar vazio)";
                contErro++;
            }
            if(boxNumero.Text.Length == 0)
            {
                erro += "\n- Número (Não pode ficar vazio)";
                contErro++;
            }
            if (radioChaveDisponivel.Checked == false && radioChaveIndisponivel.Checked == false)
            {
                erro += "\n- Situação da Chave (Seleção Obrigatória)";
                contErro++;
            }
            if (radioImovAtivo.Checked == false && radioImovInativo.Checked == false)
            {
                erro += "\n- Situação do imóvel (Seleção Obrigatória)";
                contErro++;
            }
            if(radioTipoCom.Checked == false && radioTipoRes.Checked == false)
            {
                erro += "\n- Tipo do imóvel (Seleção Obrigatória)";
                contErro++;
            }
            if(checkLocacao.Checked == false && checkVenda.Checked == false)
            {
                erro += "\n- Finalidade (Seleção Obrigatória)";
                contErro++;
            }
           
            if(boxCodProp.Text.Length == 0)
            {
                erro += "\n- Código do proprietário (Não pode ficar vazio)";
                contErro++;
            }
            if (boxCategImov.Text.Length == 0)
            {
                erro += "\n- Categoria do imóvel (Não pode ficar vazio)";
                contErro++;
            }

            FormatarStrings format = new FormatarStrings();

            if (contErro == 0)
            {
                string codigoImovel = codImovel.Text.Trim() ;
                string logradouro = format.inserirBD(boxLogradouro.Text.Trim());
                string cidade = format.inserirBD(boxCidade.Text.Trim());
                string bairro = format.inserirBD(boxBairro.Text.Trim());
                string estado = format.inserirBD(boxEstado.Text.Trim());
                string numero = format.inserirBD(boxNumero.Text.Trim());
                string complemento = format.inserirBD(boxComplemento.Text.Trim());
                string codProprietario = boxCodProp.Text.Trim();
                string situacaoChave = groupSitChave.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text;
                string situacaoImovel = groupSitImovel.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text;
                string tipoImovel = groupTipoImovel.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text; ;
                string finalidadeImovel = "";
                string aviso = boxAviso.Text;

                if(checkLocacao.Checked && checkVenda.Checked)
                {
                    finalidadeImovel = "LOCAÇÃO/VENDA";
                }
                else if(checkLocacao.Checked && !checkVenda.Checked)
                {
                    finalidadeImovel = "LOCAÇÃO";
                }
                else if(!checkLocacao.Checked && checkVenda.Checked)
                {
                    finalidadeImovel = "VENDA";
                }
                
                
                string localizacao = "";

                if(comboLocalizacao.SelectedItem.ToString() == "Outro")
                {
                    localizacao = format.inserirBD(boxOutraLocalizacao.Text.Trim()) ;
                }
                else
                {
                    localizacao = comboLocalizacao.SelectedItem.ToString();
                }

                try
                {
                    string proxCod = proximoCodigo();
                    if (seletorTela == false)
                    {
                        if(verificarExistencia(codImovel.Text) == true)
                        {
                            Message msg = new Message(string.Format("Já existe um cadastro de chave do imóvel {0}", codImovel.Text), "", "erro", "confirma");
                            msg.ShowDialog();

                        }
                        else
                        {
                            //MessageBox.Show(usuario);
                            database.insertInto(string.Format("" +
                             "INSERT INTO chave (rua, numero, complemento, bairro, cidade, estado, situacao," +
                             " localizacao, proprietario, cod_imob, tipo_imovel, finalidade, situacao_imovel, cod_chave," +
                             " quant_chaves, cond, categoria_imovel, aviso, data_cadastro, funcionario)" +
                             " VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'," +
                             " '{11}','{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}')", logradouro, numero, complemento, bairro, cidade, estado, situacaoChave,
                              localizacao, codProprietario, codigoImovel, tipoImovel, finalidadeImovel, situacaoImovel, proxCod, boxQtdChaves.Value,
                              boxCond.Text, boxCategImov.Text, aviso, dataHoje, usuario));

                            Message popup = new Message("A chave foi cadastrada com o código " + proxCod + "!" +
                               "\n Deseja imprimir a etiqueta da chave?", "", "sucesso", "escolha");
                            popup.ShowDialog();

                            if (popup.DialogResult == DialogResult.Yes)
                            {
                                try
                                {
                                    ImprimirEtiquetas imprimir = new ImprimirEtiquetas(
                                        database.selectScalar(string.Format("SELECT indice_chave" +
                                                                " FROM chave" +
                                                                " WHERE cod_chave = '{0}'", proxCod)));
                                    imprimir.ShowDialog();
                                }
                                catch (Exception error)
                                {
                                    Message erroMsg = new Message("Não foi possível imprimir a etiqueta. \n\nERRO: " + error.Message
                                        , "", "erro", "confirma");
                                    erroMsg.ShowDialog();
                                }

                            }
                        }

                      

                      

                        this.Close();

                        this.DialogResult = DialogResult.Yes;

                    }
                    else
                    {
                        database.update(string.Format("" +
                            "UPDATE chave " +
                            " SET rua = '{0}', numero = '{1}', complemento = '{2}', bairro = '{3}', " +
                            " cidade = '{4}', estado = '{5}', situacao = '{6}', localizacao = '{7}', proprietario = '{8}', " +
                            " cod_imob = '{9}', tipo_imovel = '{10}', finalidade = '{11}', situacao_imovel = '{12}', quant_chaves = '{13}', cond = '{14}', categoria_imovel = '{15}', aviso = '{16}' " +
                            " WHERE indice_chave = '{17}'", logradouro, numero, complemento, bairro, cidade, estado, situacaoChave,
                            localizacao, codProprietario, codigoImovel, tipoImovel, finalidadeImovel, situacaoImovel, boxQtdChaves.Value,
                            boxCond.Text, boxCategImov.Text, aviso,  codChave));

                       

                        this.Close();

                        this.DialogResult = DialogResult.OK;
                    }

                    
                }
                catch (Exception error)
            {
                Message popup = new Message("Não foi possível cadastrar a chave pelo seguinte erro: \n\n" + error.Message, "Erro ao cadastrar", "erro", "confirma");
                    popup.ShowDialog();
            }


        }
            else
            {
                Message popup = new Message(erro, "Erro ao cadastrar", "erro", "confirma");
                popup.ShowDialog();
            }
        }

        private void ComboProprietario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void atualizarGridProprietarios()
        {
            try
            {
                DataTable tabelaProp = new DataTable();

                tabelaProp = database.select(string.Format("SELECT cod_proprietario, nome " +
                    " FROM proprietario" +
                    " WHERE nome ILIKE '%{0}%' OR cod_proprietario::text ILIKE '%{0}%'", boxProcurarProp.Text));

                gridProprietarios.DataSource = tabelaProp;

                gridProprietarios.Columns[0].HeaderText = "Código";
                gridProprietarios.Columns[1].HeaderText = "Nome";

                gridProprietarios.Columns[0].Width = 45;
                gridProprietarios.Columns[1].Width = 270;

                gridProprietarios.Columns[0].MinimumWidth = 45;
                gridProprietarios.Columns[1].MinimumWidth = 265;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void NomePropBox_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnConfirmarProp_Click(object sender, EventArgs e)
        {
            try
            {
                string codigoProprietario = gridProprietarios.CurrentRow.Cells[0].Value.ToString();
                string nomeProprietario = gridProprietarios.CurrentRow.Cells[1].Value.ToString();

                boxCodProp.Text = codigoProprietario;
                nomePropBox.Text = nomeProprietario;


                nomePropBox.Visible = true;
                boxCodProp.Visible = true;
                excluiProp.Visible = true;
                labelCod.Visible = true;
                labelProp.Visible = true;
                btnAdicionarProp.Visible = false;
            }
            catch { }

            painelProp.Visible = false;
            groupBox2.Enabled = true;
            groupBox5.Enabled = true;


        }

        private void BtnCancelarProp_Click(object sender, EventArgs e)
        {
            painelProp.Visible = false;
            groupBox2.Enabled = true;
            groupBox5.Enabled = true;
        }

        private void ExcluiProp_Click(object sender, EventArgs e)
        {
            nomePropBox.Text = "";
            boxCodProp.Text = "";
            nomePropBox.Visible = false;
            boxCodProp.Visible = false;
            excluiProp.Visible = false;
            labelCod.Visible = false;
            labelProp.Visible = false;
            btnAdicionarProp.Visible = true;
        }

        private void BtnAdicionarProp_Click(object sender, EventArgs e)
        {
            atualizarGridProprietarios();

            painelProp.Visible = true;

            groupBox2.Enabled = false;
            groupBox5.Enabled = false;

        }

        private void BoxProcurarProp_TextChanged(object sender, EventArgs e)
        {
            atualizarGridProprietarios();
        }

        private void btnNovoProp_Click(object sender, EventArgs e)
        {
            cadastroProprietario cadProp = new cadastroProprietario();

            cadProp.ShowDialog();

            if(cadProp.DialogResult == DialogResult.OK)
            {
                atualizarGridProprietarios();
            }
        }

        private void RadioChaveIndisponivel_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BoxLogradouro_Click(object sender, EventArgs e)
        {

        }

        private void RadioImovAtivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BoxCodProp_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void BoxOutraLocalizacao_Click(object sender, EventArgs e)
        {

        }

        private void MetroLabel8_Click(object sender, EventArgs e)
        {

        }

        private void CodImovel_Click(object sender, EventArgs e)
        {

        }

        private void RadioChaveDisponivel_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PainelProp_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CodImovel_Leave(object sender, EventArgs e)
        {
            codImovel.Text = codImovel.Text.ToUpper();
        }

        private void BoxEstado_Leave(object sender, EventArgs e)
        {
            boxEstado.Text = boxEstado.Text.ToUpper();
        }

        private void ComboLocalizacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboLocalizacao.SelectedItem.ToString() == "Outro")
            {
                boxOutraLocalizacao.Enabled = true;
            }
            else
            {
                boxOutraLocalizacao.Enabled = false;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.ForeColor = Color.FromArgb(0, 109, 156);
            btnCancelar.BackColor = Color.White;
        }

        private void BtnCadastrarAviso_Click(object sender, EventArgs e)
        {
            panelAviso.Visible = true;

            groupBox2.Enabled = false;
            groupBox5.Enabled = false;
            btnCadastrar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            panelAviso.Visible = false;

            groupBox2.Enabled = true;
            groupBox5.Enabled = true;
            btnCadastrar.Enabled = true;
            btnCancelar.Enabled = true;
        }

      
    }
}
