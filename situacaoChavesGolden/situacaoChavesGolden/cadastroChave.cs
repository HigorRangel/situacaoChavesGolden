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
        List<string> codigosProprietarios = new List<string>();
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

        private void CadastroChave_Load(object sender, EventArgs e)
        {
            if(seletorTela == true)
            {
                DataTable dadosChave = new DataTable();

                dadosChave = database.select(string.Format("SELECT * FROM chave WHERE cod_chave = '{0}'", codChave));


                foreach(DataRow row in dadosChave.Rows)
                {
                    boxLogradouro.Text = row[1].ToString();
                    boxNumero.Text = row[2].ToString();
                    boxComplemento.Text = row[3].ToString();
                    boxBairro.Text = row[4].ToString();
                    boxCidade.Text = row[5].ToString();
                    boxEstado.Text = row[6].ToString();
                    comboLocalizacao.SelectedItem = row[8].ToString();
                    codImovel.Text = row[10].ToString();
                    
                    if(row[7].ToString() == "DISPONIVEL")
                    {
                        radioChaveDisponivel.Checked = true;
                    }
                    else
                    {
                        radioChaveIndisponivel.Checked = true;
                    }
                    if(row[11].ToString() == "RESIDENCIAL")
                    {
                        radioTipoRes.Checked = true;
                    }
                    else
                    {
                        radioTipoCom.Checked = true;
                    }
                    if(row[12].ToString() == "LOCAÇÃO")
                    {
                        radioFinalidadeLoc.Checked = true;
                    }
                    else
                    {
                        radioFinalidadeVenda.Checked = true;
                    }
                    if(row[13].ToString() == "ATIVO")
                    {
                        radioImovAtivo.Checked = true;
                    }
                    else
                    {
                        radioImovInativo.Checked = true;
                    }


                    MessageBox.Show(database.selectScalar(string.Format("" +
                        "SELECT nome FROM proprietario WHERE cod_proprietario = '{0}'", row[9].ToString())));

                    comboProprietario.SelectedValue = database.selectScalar(string.Format("" +
                        "SELECT nome FROM proprietario WHERE cod_proprietario = '{0}'", row[9].ToString()));

                }


            }

            //PREENCHE A COMBOBOX DE PROPRIETÁRIO

            codigosProprietarios.Clear();
            comboProprietario.Items.Clear();
            comboProprietario.Items.Add("--NOVO--");

            DataTable proprietarios = new DataTable();

            proprietarios = database.select("SELECT cod_proprietario, nome FROM proprietario ORDER BY nome");

            foreach (DataRow row in proprietarios.Rows)
            {
                codigosProprietarios.Add(row[0].ToString());
                comboProprietario.Items.Add(row[1].ToString());


            }

        }

        private void BtnCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.ForeColor = Color.White;
        }

        private void ComboProprietario_SelectedValueChanged(object sender, EventArgs e)
        {
            if(comboProprietario.SelectedItem.ToString() == "--NOVO--")
            {
                cadastroProprietario proprietario = new cadastroProprietario();
                proprietario.ShowDialog();
            }
        }

     

        private void ComboProprietario_Click(object sender, EventArgs e)
        {
            codigosProprietarios.Clear();
            comboProprietario.Items.Clear();
            comboProprietario.Items.Add("--NOVO--");

            DataTable proprietarios = new DataTable();

            proprietarios = database.select("SELECT cod_proprietario, nome FROM proprietario ORDER BY nome");

            foreach(DataRow row in proprietarios.Rows)
            {
                codigosProprietarios.Add(row[0].ToString());
                comboProprietario.Items.Add(row[1].ToString());


            }
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            int contErro = 0;


            if(codImovel.Text.Length == 0)
            {
                contErro++;
            }
            if(comboLocalizacao.SelectedIndex == -1)
            {
                contErro++;
            }
            if (boxOutraLocalizacao.Text.Length < 0 && comboLocalizacao.SelectedItem.ToString() == "Outro")
            {
                contErro++;
            }
            if(boxLogradouro.Text.Length == 0)
            {
                contErro++;
            }
            if(boxCidade.Text.Length == 0)
            {
                contErro++;
            }
            if(boxBairro.Text.Length == 0)
            {
                contErro++;
            }
            if(boxEstado.Text.Length == 0)
            {
                contErro++;
            }
            if(boxNumero.Text.Length == 0)
            {
                contErro++;
            }
            if (radioChaveDisponivel.Checked == false && radioChaveIndisponivel.Checked == false)
            {
                contErro++;
            }
            if (radioImovAtivo.Checked == false && radioImovInativo.Checked == false)
            {
                contErro++;
            }
            if(radioTipoCom.Checked == false && radioTipoRes.Checked == false)
            {
                contErro++;
            }
            if(radioFinalidadeLoc.Checked == false && radioFinalidadeVenda.Checked == false)
            {
                contErro++;
            }
            if(radioFinalidadeVenda.Checked == false && radioFinalidadeLoc.Checked == false)
            {
                contErro++;
            }
            if(comboProprietario.SelectedIndex == -1)
            {
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
                string codProprietario = codigosProprietarios[comboProprietario.SelectedIndex - 1];
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
                        " localizacao, proprietario, cod_imob, tipo_imovel, finalidade, situacao_imovel)" +
                        " VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'," +
                        " '{11}','{12}')", logradouro, numero, complemento, bairro, cidade, estado, situacaoChave,
                         localizacao, codProprietario, codigoImovel, tipoImovel, finalidadeImovel, situacaoImovel));

                        this.Close();

                        this.DialogResult = DialogResult.Yes;

                    }
                    else
                    {
                        database.update(string.Format("" +
                            "UPDATE chave " +
                            " SET rua = '{0}', numero = '{1}', complemento = '{2}', bairro = '{3}', " +
                            " cidade = '{4}', estado = '{5}', situacao = '{6}', localizacao = '{7}', proprietario = '{8}', " +
                            " cod_imob = '{9}', tipo_imovel = '{10}', finalidade = '{11}', situacao_imovel = '{12}' " +
                            " WHERE cod_chave = {13}", logradouro, numero, complemento, bairro, cidade, estado, situacaoChave,
                            localizacao, codProprietario, codigoImovel, tipoImovel, finalidadeImovel, situacaoImovel, codChave));

                        this.Close();

                        this.DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }

                


                
            }
            else
            {
                MessageBox.Show("Há campso preenchidos incorretamente! Verifique e tente novamente");
            }
        }
    }
}
