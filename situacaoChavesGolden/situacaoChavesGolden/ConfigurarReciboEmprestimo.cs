using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace situacaoChavesGolden
{
    public partial class ConfigurarReciboEmprestimo : MetroFramework.Forms.MetroForm
    {
        string cod = "";
        public ConfigurarReciboEmprestimo(string codigo)
        {
            InitializeComponent();
            cod = codigo;
        }

        private void ConfigurarReciboEmpréstimo_Load(object sender, EventArgs e)
        {

        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                GerarRecibos recibos = new GerarRecibos();
                string radioButon = groupBox1.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToLower();
                int vias = 0;

                if (radioButon == "1 via")
                {
                    vias = 1;
                }
                else
                {
                    vias = 2;
                }

                recibos.reciboEmprestimo(imagem, cod, vias);
                PrintImages();

                this.Close();
            }
            catch (Exception erro)
            {
                Message msg = new Message("Não foi possível imprimir o recibo!\nErro: " + erro.Message, "", "erro", "confirma");
            }
            
        }

        void PrintImages()
        {


            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += printDocument1_PrintPage;

            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(imagem.BackgroundImage, e.PageBounds.X, e.PageBounds.Y);


        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
