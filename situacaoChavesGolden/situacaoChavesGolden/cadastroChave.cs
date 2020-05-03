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

        public cadastroChave(string codigoChave)
        {
            InitializeComponent();
            seletorTela = true;
            codChave = codigoChave;
        }

        public cadastroChave()
        {
            InitializeComponent();
        }

        private string proximoCodigo()
        {
            string proxCodigo = "";
            DataTable codigos = new DataTable();

            codigos = database.select("SELECT cod_chave FROM chave ORDER BY cod_chave");
            List<int> arrayCodigos = new List<int>();
            // int[] arrayCodigos = new int[codigos.Rows.Count];

            if(codigos.Rows.Count != 0)
            {
                foreach (DataRow row in codigos.Rows)
                {
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
                    comboLocalizacao.SelectedItem = row[8].ToString();
                    codImovel.Text = row[10].ToString();
                    boxQtdChaves.Value = int.Parse(row[14].ToString());
                    boxCond.Text = row[15].ToString();
                    boxCategImov.Text = row[16].ToString();
                    
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
                        radioFinalidadeLoc.Checked = true;
                    }
                    else
                    {
                        radioFinalidadeVenda.Checked = true;
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
            if (boxOutraLocalizacao.Text.Length < 0 && comboLocalizacao.SelectedItem.ToString() == "Outro")
            {
                erro += "\n- Outra localização (Não pode ficar vazio)";
                contErro++;
            }
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
            if(radioFinalidadeLoc.Checked == false && radioFinalidadeVenda.Checked == false)
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



            if (contErro == 0)
            {
                string codigoImovel = codImovel.Text.Trim();
                string logradouro = boxLogradouro.Text.Trim();
                string cidade = boxCidade.Text.Trim();
                string bairro = boxBairro.Text.Trim();
                string estado = boxEstado.Text.Trim();
                string numero = boxNumero.Text.Trim();
                string complemento = boxComplemento.Text.Trim();
                string codProprietario = boxCodProp.Text.Trim();
                string situacaoChave = groupSitChave.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text;
                string situacaoImovel = groupSitImovel.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text;
                string tipoImovel = groupTipoImovel.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text; ;
                string finalidadeImovel = groupFinalImovel.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text; ;
                string localizacao = "";

                if(comboLocalizacao.SelectedItem.ToString() == "Outro")
                {
                    localizacao = boxOutraLocalizacao.Text.Trim();
                }
                else
                {
                    localizacao = comboLocalizacao.SelectedItem.ToString();
                }

                try
                {
                    if (seletorTela == false)
                    {
                        database.insertInto(string.Format("" +
                        "INSERT INTO chave (rua, numero, complemento, bairro, cidade, estado, situacao," +
                        " localizacao, proprietario, cod_imob, tipo_imovel, finalidade, situacao_imovel, cod_chave, quant_chaves, cond, categoria_imovel)" +
                        " VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'," +
                        " '{11}','{12}', '{13}', '{14}', '{15}', '{16}')", logradouro, numero, complemento, bairro, cidade, estado, situacaoChave,
                         localizacao, codProprietario, codigoImovel, tipoImovel, finalidadeImovel, situacaoImovel, proximoCodigo(), boxQtdChaves.Value, boxCond.Text, boxCategImov.Text));

                        this.Close();

                        this.DialogResult = DialogResult.Yes;

                    }
                    else
                    {
                        database.update(string.Format("" +
                            "UPDATE chave " +
                            " SET rua = '{0}', numero = '{1}', complemento = '{2}', bairro = '{3}', " +
                            " cidade = '{4}', estado = '{5}', situacao = '{6}', localizacao = '{7}', proprietario = '{8}', " +
                            " cod_imob = '{9}', tipo_imovel = '{10}', finalidade = '{11}', situacao_imovel = '{12}', quant_chaves = '{13}', cond = '{14}', categoria_imovel = '{15}' " +
                            " WHERE indice_chave = '{16}'", logradouro, numero, complemento, bairro, cidade, estado, situacaoChave,
                            localizacao, codProprietario, codigoImovel, tipoImovel, finalidadeImovel, situacaoImovel, boxQtdChaves.Value, boxCond.Text, boxCategImov.Text, codChave));

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
    }
}
