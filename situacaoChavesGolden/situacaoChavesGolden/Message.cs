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
    public partial class Message : MetroFramework.Forms.MetroForm
    {
        string diretorio = Environment.CurrentDirectory;

        Color erro = Color.FromArgb(200,0,0);
        Color info = Color.FromArgb(27, 144, 194);
        Color sucesso = Color.FromArgb(0, 175, 0);
        Color aviso = Color.FromArgb(255, 191, 0);
        Color cor = new Color();

        string textoMsg = "";
        string tituloMsg = "";
        string tipoMsg = "";
        string botoesMsg = "";


        private Color selecionarCor()
        {
            //Define o tipo da caixa de mensagem
            if (tipoMsg == "erro")
            {
                cor = erro;
            }
            else if (tipoMsg == "sucesso")
            {
                cor = sucesso;
            }
            else if (tipoMsg == "aviso")
            {
                cor = aviso;
            }
            else if (tipoMsg == "info")
            {
                cor = info;
            }

            return cor;
        }
        public Message(string message, string title,  string type, string buttons)
        {
            InitializeComponent();


            textoMsg = message;
            tituloMsg = title;
            tipoMsg = type;
            botoesMsg = buttons;
        }
        

        private void Message_Load(object sender, EventArgs e)
        {
            if(botoesMsg == "confirma")
            {
                btnOk.Visible = true;
                btnSim.Visible = false;
                btnNao.Visible = false;
            }
            else if(botoesMsg == "escolha")
            {
                btnOk.Visible = false;
                btnSim.Visible = true;
                btnNao.Visible = true;
            }


            //Define as configurações para quebra de linha
            texto.MaximumSize = new Size(400, 800);
            texto.AutoSize = true;
            
            //Define o texto da caixa de mensagem
            texto.Text = textoMsg;

            //Define o titulo da caixa de mensagem
            titulo.Text = tituloMsg;

            //Define o tipo da caixa de mensagem
            if(tipoMsg == "erro")
            {
                this.Style = MetroFramework.MetroColorStyle.Red;

                //Botão OK
                btnOk.FlatAppearance.BorderColor = erro;
                btnOk.ForeColor = erro;
                btnOk.FlatAppearance.MouseOverBackColor = Color.FromArgb(165, 0, 0);
                btnOk.FlatAppearance.MouseDownBackColor = Color.FromArgb(130, 0, 0);

                //Botão SIM
                btnSim.FlatAppearance.BorderColor = erro;
                btnSim.ForeColor = erro;
                btnSim.FlatAppearance.MouseOverBackColor = Color.FromArgb(165, 0, 0);
                btnSim.FlatAppearance.MouseDownBackColor = Color.FromArgb(130, 0, 0);

                //Botao NAO
                btnNao.FlatAppearance.BorderColor = erro;
                btnNao.ForeColor = erro;
                btnNao.FlatAppearance.MouseOverBackColor = Color.FromArgb(165, 0, 0);
                btnNao.FlatAppearance.MouseDownBackColor = Color.FromArgb(130, 0, 0);

                try
                {
                    icone.ImageLocation = diretorio + @"\Images\Erro.png";
                }
                catch { }

            }
            else if(tipoMsg == "sucesso")
            {
                this.Style = MetroFramework.MetroColorStyle.Green;

                //Botao OK
                btnOk.FlatAppearance.BorderColor = sucesso;
                btnOk.ForeColor = sucesso;
                btnOk.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 138, 0); 
                btnOk.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 112, 0);

                //Botao SIM
                btnSim.FlatAppearance.BorderColor = sucesso;
                btnSim.ForeColor = sucesso;
                btnSim.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 138, 0);
                btnSim.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 112, 0);

                //Botao NAO
                btnNao.FlatAppearance.BorderColor = sucesso;
                btnNao.ForeColor = sucesso;
                btnNao.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 138, 0);
                btnNao.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 112, 0);

                try
                {
                    icone.ImageLocation = diretorio + @"\Images\Sucesso.png";
                }
                catch { }
            }
            else if(tipoMsg == "aviso")
            {
                this.Style = MetroFramework.MetroColorStyle.Yellow;

                //Botao OK
                btnOk.FlatAppearance.BorderColor = aviso;
                btnOk.ForeColor = aviso;
                btnOk.FlatAppearance.MouseOverBackColor = Color.FromArgb(209, 157, 0);
                btnOk.FlatAppearance.MouseDownBackColor = Color.FromArgb(173, 130, 0);

                //Botao SIM
                btnSim.FlatAppearance.BorderColor = aviso;
                btnSim.ForeColor = aviso;
                btnSim.FlatAppearance.MouseOverBackColor = Color.FromArgb(209, 157, 0);
                btnSim.FlatAppearance.MouseDownBackColor = Color.FromArgb(173, 130, 0);

                //Botao NAO
                btnNao.FlatAppearance.BorderColor = aviso;
                btnNao.ForeColor = aviso;
                btnNao.FlatAppearance.MouseOverBackColor = Color.FromArgb(209, 157, 0);
                btnNao.FlatAppearance.MouseDownBackColor = Color.FromArgb(173, 130, 0);

                try
                {
                    icone.ImageLocation = diretorio + @"\Images\Aviso.png";
                }
                catch { }
            }

            else if(tipoMsg == "info")
            {
                this.Style = MetroFramework.MetroColorStyle.Blue;

                //Botao OK
                btnOk.FlatAppearance.BorderColor = info;
                btnOk.ForeColor = info;
                btnOk.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 108, 145);
                btnOk.FlatAppearance.MouseDownBackColor = Color.FromArgb(18, 89, 120);

                //Botao SIM
                btnSim.FlatAppearance.BorderColor = info;
                btnSim.ForeColor = info;
                btnSim.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 108, 145);
                btnSim.FlatAppearance.MouseDownBackColor = Color.FromArgb(18, 89, 120);

                //Botao NAO
                btnNao.FlatAppearance.BorderColor = info;
                btnNao.ForeColor = info;
                btnNao.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 108, 145);
                btnNao.FlatAppearance.MouseDownBackColor = Color.FromArgb(18, 89, 120);

                try
                {
                    icone.ImageLocation = diretorio + @"\Images\Info.png";
                }
                catch { }
            }


            //Define o tamanho da caixa de mensagem de acordo com o texto
            this.Height = texto.Height + 120;

            //Define a localização dos botões de acordo com o tamanho da caixa de mensagem
            Point botaoDireita = new Point(this.Width - 105, this.Height - 35);
            Point botaoEsquerda = new Point(this.Width - 200, this.Height - 35);

            btnOk.Location = botaoDireita;
            btnNao.Location = botaoDireita;
            btnSim.Location = botaoEsquerda;

        }

        private void BtnOk_MouseEnter(object sender, EventArgs e)
        {

            btnOk.ForeColor = Color.White;
        }

        private void BtnOk_MouseLeave(object sender, EventArgs e)
        {
            btnOk.ForeColor = selecionarCor();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            
        }

        private void btnSim_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Yes;
        }
        private void btnSim_MouseEnter(object sender, EventArgs e)
        {
            btnSim.ForeColor = Color.White;
        }

        private void btnSim_MouseLeave(object sender, EventArgs e)
        {
            btnSim.ForeColor = selecionarCor();
        }


        private void btnNao_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }    
        private void btnNao_MouseEnter(object sender, EventArgs e)
        {
            btnNao.ForeColor = Color.White;
        }

        private void btnNao_MouseLeave(object sender, EventArgs e)
        {
            btnNao.ForeColor = selecionarCor();
        }
    }
}
