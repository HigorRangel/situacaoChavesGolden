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
    public partial class ImprimirEtiquetas : MetroFramework.Forms.MetroForm
    {

        List<string> tipo = new List<string>();
        List<string> endereco = new List<string>();
        List<string> codChave = new List<string>();
        List<string> quantChave = new List<string>();

        PostgreSQL database = new PostgreSQL();
        public ImprimirEtiquetas()
        {
            InitializeComponent();
        }

        void atualizarGridFrom()
        {
            gridFrom.DataSource = database.select("SELECT c.cod_chave, c.rua || ', ' || c.numero || ' - ' || c.bairro as endereco, c.indice_chave, c.situacao_imovel" +
                                                  " FROM chave c" +
                                                  " ORDER BY c.situacao_imovel, c.cod_chave").DefaultView;

            gridFrom.Columns[0].HeaderText = "Cód";
            gridFrom.Columns[1].HeaderText = "Endereço";
            gridFrom.Columns[2].Visible = false;
            gridFrom.Columns[3].Visible = false;

            gridFrom.Columns[0].Width = 30;
            gridFrom.Columns[1].Width = 228;

        }

        private void ImprimirEtiquetas_Load(object sender, EventArgs e)
        {
            atualizarGridFrom();

            gridTo.Columns.Add("codigo", "Cód.");
            gridTo.Columns.Add("endereco", "Endereço");
            gridTo.Columns.Add("indice", "indice");

            gridTo.Columns[0].Width = 30;
            gridTo.Columns[1].Width = 228;
            gridTo.Columns[2].Visible = false;

        }


        private List<Image> _pages = new List<Image>();
        private int pageIndex = 0;

     

        public int cmToPixel(double centimetro)
        {
            double pixel = 0;
            Graphics convert = this.CreateGraphics();

            pixel = centimetro * convert.DpiY / 2.54d;

            return (int)pixel;
        }

        //gerarEtiquetas(List<string> tipo, List<string> endereco, List<string> codigoChave, List<string> codigoImob)
        private void gerarEtiquetas(List<string> tipo, List<string> endereco, List<string> codChave, List<string> quantChaves)
        {

            int contador = tipo.Count;

            if (contador % 20 != 0)
            {
                contador += 20;
            }

            List<Bitmap> imagesBack = new List<Bitmap>();
            imagesBack.Add(new Bitmap(cmToPixel(21), cmToPixel(29.7)));
            imagesBack.Add(new Bitmap(cmToPixel(21), cmToPixel(29.7)));
            imagesBack.Add(new Bitmap(cmToPixel(21), cmToPixel(29.7)));
            imagesBack.Add(new Bitmap(cmToPixel(21), cmToPixel(29.7)));
            imagesBack.Add(new Bitmap(cmToPixel(21), cmToPixel(29.7)));
            imagesBack.Add(new Bitmap(cmToPixel(21), cmToPixel(29.7)));
            imagesBack.Add(new Bitmap(cmToPixel(21), cmToPixel(29.7)));

            List<Graphics> drawer = new List<Graphics>();
            drawer.Add(Graphics.FromImage(imagesBack[0]));
            drawer.Add(Graphics.FromImage(imagesBack[1]));
            drawer.Add(Graphics.FromImage(imagesBack[2]));
            drawer.Add(Graphics.FromImage(imagesBack[3]));
            drawer.Add(Graphics.FromImage(imagesBack[4]));
            drawer.Add(Graphics.FromImage(imagesBack[5]));
            drawer.Add(Graphics.FromImage(imagesBack[6]));
            ///
            //Bitmap imgBack = new Bitmap(imagem.Width, imagem.Height);
            //Graphics desenhador = Graphics.FromImage(imgBack);

            drawer[0].Clear(Color.White);
            drawer[1].Clear(Color.White);
            drawer[2].Clear(Color.White);
            drawer[3].Clear(Color.White);
            drawer[4].Clear(Color.White);
            drawer[5].Clear(Color.White);
            drawer[6].Clear(Color.White);



            Pen caneta = new Pen(Color.Black, 1);



            //Define medidas dos retângulos base
            Point pRectBase = new Point();
            Size sRectBase = new Size(cmToPixel(3.5), cmToPixel(4.2));
            pRectBase.X = 30;
            pRectBase.Y = 50;

            //Define medidas dos retângulos de imagem
            Point pRectImg = new Point(pRectBase.X + 7, pRectBase.Y + 3);
            Size sRectImg = new Size(cmToPixel(3.0), cmToPixel(1));

            //Define medidas dos retangulos dos textos de tipo do imóvel
            Point pRectTxtTipo = new Point(pRectImg.X - 3, pRectImg.Y + sRectImg.Height + 3);
            Size sRectTxtTipo = new Size(cmToPixel(3.3), cmToPixel(0.4));




            //Define medidas dos retangulos dos textos de descrição do endereço
            Point pRectTxtImovel = new Point(pRectTxtTipo.X, pRectTxtTipo.Y + sRectTxtTipo.Height + 6);
            Size sRectTxtImovel = new Size(cmToPixel(3.3), cmToPixel(1.9));




            //Define medidas dos retangulso dos textos dos dados da chave
            Point pRectTxtCodigo = new Point(pRectTxtImovel.X, pRectTxtImovel.Y + sRectTxtImovel.Height + 2);
            Size sRectTxtCodigo = new Size(cmToPixel(3.3), cmToPixel(0.4));



            string texto = "";
            int cont = 0;
            Graphics desenhador = drawer[0];

            Bitmap imgback = imagesBack[0];

            imagem.BackgroundImage = imgback;

            for (int i = 0; i < contador; i++)
            {

                //MessageBox.Show(i.ToString());   
                if (pRectBase.X == 830)
                {
                    pRectBase.X = 30;
                    pRectImg.X = pRectBase.X + 6;
                    pRectTxtTipo.X = pRectImg.X - 3;
                    pRectTxtImovel.X = pRectTxtTipo.X;
                    pRectTxtCodigo.X = pRectTxtImovel.X;

                }
                if (i % 4 == 0 && i != 0)
                {
                    pRectBase.Y = pRectBase.Y + 200;
                    pRectImg.Y = pRectBase.Y + 3;
                    pRectTxtTipo.Y = pRectImg.Y + sRectImg.Height + 3;
                    pRectTxtImovel.Y = pRectTxtTipo.Y + sRectTxtTipo.Height + 6;
                    pRectTxtCodigo.Y = pRectTxtImovel.Y + sRectTxtImovel.Height + 2;
                }



                if (i % 20 == 0 && i != 0)
                {

                    _pages.Add(imagem.BackgroundImage);

                    imagem.BackgroundImage.Save(@"C:\Users\Usuario\Desktop\Etiquetas\imageeem" + i.ToString() + ".jpg");
                    imagem.BackgroundImage = null;


                    if (i == 20)
                    {
                        desenhador = drawer[1];
                        imgback = imagesBack[1];
                        imagem.BackgroundImage = imgback;
                    }
                    else if (i == 40)
                    {
                        desenhador = drawer[2];
                        imgback = imagesBack[2];
                        imagem.BackgroundImage = imgback;
                    }
                    else if (i == 60)
                    {
                        desenhador = drawer[3];
                        imgback = imagesBack[3];
                        imagem.BackgroundImage = imgback;
                    }
                    else if (i == 80)
                    {
                        desenhador = drawer[4];
                        imgback = imagesBack[4];
                        imagem.BackgroundImage = imgback;
                    }
                    else if (i == 100)
                    {
                        desenhador = drawer[5];
                        imgback = imagesBack[5];
                        imagem.BackgroundImage = imgback;
                    }
                    else if (i == 120)
                    {
                        desenhador = drawer[6];
                        imgback = imagesBack[6];
                        imagem.BackgroundImage = imgback;
                    }

                  


                    //imagem.BackgroundImage = imgBack;
                    //_pages.Add(imagem.BackgroundImage);


                    pRectBase.X = 30;
                    pRectBase.Y = 50;
                    pRectImg.X = pRectBase.X + 6;
                    pRectImg.Y = pRectBase.Y + 3;
                    pRectTxtTipo.X = pRectImg.X - 3;
                    pRectTxtTipo.Y = pRectImg.Y + sRectImg.Height + 3;
                    pRectTxtImovel.X = pRectTxtTipo.X;
                    pRectTxtImovel.Y = pRectTxtTipo.Y + sRectTxtTipo.Height + 6;
                    pRectTxtCodigo.X = pRectTxtImovel.X;
                    pRectTxtCodigo.Y = pRectTxtImovel.Y + sRectTxtImovel.Height + 2;
                    //imgBack.Save(@"C:\Users\Usuario\Desktop\Etiquetas\img" + i.ToString() + ".jpg");
                    //imgBack.Dispose();
                }



                try
                {
                    if (i >= tipo.Count)
                    {
                        throw new Exception();
                    }
                    //>>>>>>>>>>>>>>>>> DESENHA O RETANGULO DA IMAGEM <<<<<<<<<<<<<<<<<<<<<<
                    Rectangle rectImg = new Rectangle(pRectImg, sRectImg);
                    //desenhador.DrawRectangle(caneta, rectImg);
                    desenhador.DrawImage(Properties.Resources.logoSbernardo, rectImg);

                    //>>>>>>>>>>>>>>>>> DESENHA O RETANGULO DA BASE <<<<<<<<<<<<<<<<<<<<<<
                    Rectangle rectBase = new Rectangle(pRectBase, sRectBase);
                    desenhador.DrawRectangle(caneta, rectBase);


                    //>>>>>>>>>>>>>>>>> DESENHA O RETANGULO DO TEXTO DO TIPO <<<<<<<<<<<<<<<<<<<<<<
                    Rectangle rectTxtTipo = new Rectangle(pRectTxtTipo, sRectTxtTipo);

                    Font fonteTipo = new Font("Consolas", 14, FontStyle.Bold, GraphicsUnit.Pixel);
                    Brush brushTipo = new SolidBrush(Color.Black);
                    StringFormat sfTipo = new StringFormat();
                    sfTipo.Alignment = StringAlignment.Center;

                    //DESENHA LINHA PARA DIVIDIR O TIPO DA DESCRIÇÃO
                    desenhador.DrawString(tipo[i].ToUpper(), fonteTipo, brushTipo, rectTxtTipo, sfTipo);

                    //>>>>>>>>>>>>>>>>> DESENHA A LINHA DIVISÓRIA <<<<<<<<<<<<<<<<<<<<<<
                    desenhador.DrawLine(caneta, new Point(rectTxtTipo.X + 3, rectTxtTipo.Y + rectTxtTipo.Height + 3),
                        new Point(rectTxtTipo.Width + rectTxtTipo.X - 3, rectTxtTipo.Y + rectTxtTipo.Height + 3));

                    //>>>>>>>>>>>>>>>>> DESENHA O RETANGULO DA DESCRIÇÃO DO IMÓVEL <<<<<<<<<<<<<<<<<<<<<<
                    Rectangle rectTxt = new Rectangle(pRectTxtImovel, sRectTxtImovel);

                    Font fonteTxtImovel = new Font("Consolas", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                    Brush brushTxtImovel = new SolidBrush(Color.Black);
                    StringFormat sfTxtImovel = new StringFormat();
                    sfTxtImovel.Alignment = StringAlignment.Center;

                    desenhador.DrawString(endereco[i], fonteTxtImovel, brushTxtImovel, rectTxt, sfTxtImovel);
                    //Ed.Morada do Sol\nRua João Paulo Rodrigues -Jardim São Domingos(L0157)

                    //>>>>>>>>>>>>>>>>> DESENHA O RETANGULO DA DESCRIÇÃO DA CHAVE <<<<<<<<<<<<<<<<<<<<<<
                    Font fonteTxtCodigo = new Font("Consolas", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                    Brush brushTxtCodigo = new SolidBrush(Color.Black);
                    StringFormat sfTxtCodigo = new StringFormat();
                    sfTxtCodigo.Alignment = StringAlignment.Center;

                    Rectangle rectTxtCodigo = new Rectangle(pRectTxtCodigo, sRectTxtCodigo);
                    //desenhador.DrawRectangle(caneta, rectTxtCodigo);
                    desenhador.DrawString(string.Format("cód: {0}||Qtd: {1}", codChave[i], quantChaves[i]), fonteTxtCodigo, brushTxtCodigo, rectTxtCodigo, sfTxtCodigo);


                    pRectBase.X += 200;
                    pRectImg.X = pRectBase.X + 6;
                    pRectTxtTipo.X = pRectImg.X - 3;
                    pRectTxtImovel.X = pRectTxtTipo.X;
                    pRectTxtCodigo.X = pRectTxtImovel.X;

                }
                catch { }



            }
        }

        private void button4_Click(object sender, EventArgs e)
        {



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

        private void Button2_Click(object sender, EventArgs e)
        {


            PrintImages();
        }




        private void PrintDocument1_EndPrint(object sender, PrintEventArgs e)
        {
            pageIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            List<string> tipo = new List<string>();
            List<string> endereco = new List<string>();
            List<string> cod = new List<string>();
            List<string> quant = new List<string>();
            for (int i = 0; i < 19; i++)
            {
                tipo.Add("");
                endereco.Add("");
                cod.Add(i.ToString());
                quant.Add("");
            }



            //tipo.Add("Casa");
            //tipo.Add("Apartamento");
            //tipo.Add("Sala Comercial");
            //tipo.Add("Terreno Comercial");
            //tipo.Add("Casa");
            //tipo.Add("Sala");
            //tipo.Add("Casa");


            //endereco.Add("Ed. João Pessoa\nRua Santa Clara, 4564 - Jardim Brasil (L1234)");
            //endereco.Add("Rua Antônio Meneghel, 275 - Jardim São Luiz(L0123)");
            //endereco.Add("Rua Ari Meireles, 390 - Sala 05 - Jardim Santa Catarina (L4594)");
            //endereco.Add("Avenida Brasil, 450 - Jardim Frezzarin (L0154)");
            //endereco.Add("Avenida Melody Belo, 789 - Jardim Santa Bárbara D'oeste (L0789)");
            //endereco.Add("Edifício Office Home\n Rua José Roberto Lopes - Centro (L0459)");
            //endereco.Add("Rua Pernambuco, 65456, Jardim Thelja (L0963)");

            //cod.Add("1");
            //cod.Add("14");
            //cod.Add("120");
            //cod.Add("40");
            //cod.Add("12");
            //cod.Add("11");
            //cod.Add("12");

            //quant.Add("1");
            //quant.Add("2");
            //quant.Add("6");
            //quant.Add("4");
            //quant.Add("5");
            //quant.Add("14");
            //quant.Add("7");


            gerarEtiquetas(tipo, endereco, cod, quant);



            Pen caneta1 = new Pen(Color.Black, 1);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(_pages[pageIndex], e.PageBounds.X, e.PageBounds.Y);

            pageIndex++;



            e.HasMorePages = (pageIndex < _pages.Count);

            if (pageIndex > _pages.Count)
            {
                pageIndex = 0;
            }
            //Bitmap[] bm = new Bitmap[2];
            //e.Graphics.DrawImage(bm[PageCounter], 0, 0);
            //PageCounter++;
            //e.HasMorePages = (PageCounter != bm.Count);

            //if(e.PageSettings.)
            //Bitmap bm = new Bitmap(imgPrint.Width, imgPrint.Height);
            //imgPrint.DrawToBitmap(bm, new Rectangle(0, 0, imgPrint.Width, imgPrint.Height));
            //imagem.DrawToBitmap(bm2, new Rectangle(0, 0, imagem.Width, imagem.Height));
            //e.Graphics.DrawImage(bm, 0, 0);
            //bm.Dispose();
        }

        private void btnPassSelec_Click(object sender, EventArgs e)
        {
            

            foreach(DataGridViewRow row in gridFrom.SelectedRows)
            {
                //MessageBox.Show(row.Cells[0].Value.ToString());
                gridTo.Rows.Add(row.Cells[0].Value, (row.Cells[1].Value.ToString()));
                gridFrom.Rows.RemoveAt(row.Index);

                database.select(string.Format("SELECT categoria_imovel, (CASE WHEN cond is null THEN '' ELSE cond || ' - '  END) || rua || ', ' || numero || "+
                                              " (CASE WHEN complemento = '' THEN '' ELSE '[' || complemento || ']' END) || ' - ' || bairro || "+
                                              " ' (' || cod_imob || ')' as endereco, cod_chave, quant_chaves" +
                                              " FROM chave" +
                                              " WHERE indice_chave = '{0}'", ))
            }
        }
    }
}
