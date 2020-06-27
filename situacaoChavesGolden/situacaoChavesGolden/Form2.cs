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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GerarRecibos gr = new GerarRecibos();
            gr.reciboReserva(imagem, "15");

            //ImprimirEtiquetas usarMetodo = new ImprimirEtiquetas();



            //Bitmap img = new Bitmap(usarMetodo.cmToPixel(21), usarMetodo.cmToPixel(29.7));
            //Graphics drawer = Graphics.FromImage(img);


            //drawer.Clear(Color.White);
            //imagem.BackgroundImage = img;


            //Pen pen = new Pen(Color.Black, 1);

            //Point pBase = new Point(5, 5);
            //Size sBase = new Size(usarMetodo.cmToPixel(18), usarMetodo.cmToPixel(15));

            //Rectangle rectBase = new Rectangle(pBase, sBase);

            //drawer.DrawRectangle(pen, rectBase);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintImages();
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
    }
}
