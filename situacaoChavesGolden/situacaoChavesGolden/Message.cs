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
                btnOk.FlatAppearance.BorderColor = erro;
                btnOk.ForeColor = erro;
                btnOk.FlatAppearance.MouseOverBackColor = Color.FromArgb(165, 0, 0);
                btnOk.FlatAppearance.MouseDownBackColor = Color.FromArgb(130, 0, 0);

            }
            else if(tipoMsg == "sucesso")
            {
                this.Style = MetroFramework.MetroColorStyle.Green;
                btnOk.FlatAppearance.BorderColor = sucesso;
                btnOk.ForeColor = sucesso;
                btnOk.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 138, 0); 
                btnOk.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 112, 0);

                try
                {
                    icone.ImageLocation = @"C:\Users\Higor Rangel\Desktop\sucesso.png";
                }
                catch { }
            }
            else if(tipoMsg == "aviso")
            {
                this.Style = MetroFramework.MetroColorStyle.Yellow;
                btnOk.FlatAppearance.BorderColor = aviso;
                btnOk.ForeColor = aviso;
                btnOk.FlatAppearance.MouseOverBackColor = Color.FromArgb(209, 157, 0);
                btnOk.FlatAppearance.MouseDownBackColor = Color.FromArgb(173, 130, 0);
            }

            else if(tipoMsg == "info")
            {
                this.Style = MetroFramework.MetroColorStyle.Blue;
                btnOk.FlatAppearance.BorderColor = info;
                btnOk.ForeColor = info;
                btnOk.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 108, 145);
                btnOk.FlatAppearance.MouseDownBackColor = Color.FromArgb(18, 89, 120);
            }


            //Define o tamanho da caixa de mensagem de acordo com o texto
            this.Height = texto.Height + 120;

            //Define a localização dos botões de acordo com o tamanho da caixa de mensagem
            Point botao = new Point(this.Width - 105, this.Height - 35);
            btnOk.Location = botao;
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

            
        }
    }
}
