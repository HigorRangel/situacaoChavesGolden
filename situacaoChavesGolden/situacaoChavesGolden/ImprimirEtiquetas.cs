﻿using System;
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
        List<string> codQuantChave = new List<string>();
        List<float> tamanhoFonte = new List<float>();
        DataTable tabelaChave = new DataTable();
        int qtdChaves = 0;
        bool seletorTela = false;
        string codigoChave = "";

        PostgreSQL database = new PostgreSQL();
        public ImprimirEtiquetas()
        {
            InitializeComponent();
        }

       

        public ImprimirEtiquetas(string codChave)
        {
            InitializeComponent();

            codigoChave = codChave;
            //seletorTela = true;
            //gridFrom.Enabled = false;
            //btnSelecTudo.Enabled = false;
            //btnSelecTudoTo.Enabled = false;
            //btnPassSelec.Enabled = false;
            //btnPassSelec.Cursor = Cursors.Arrow;

            DataGridViewColumn clmn = new DataGridViewColumn();

            clmn.HeaderText = "Cód.";
            clmn.ValueType = typeof(int);

            gridTo.Columns.Add("codigo", "Cód.");
            gridTo.Columns.Add("endereco", "Endereço");
            gridTo.Columns.Add("indice", "indice");
            gridTo.Columns.Add("situacao", "situacao");



            gridTo.Columns[0].Width = 30;
            gridTo.Columns[1].Width = 228;
            gridTo.Columns[2].Visible = false;
            gridTo.Columns[3].Visible = false;



            DataTable tabela = new DataTable();

             tabela = database.select(string.Format("SELECT c.cod_chave, c.rua || ', ' || c.numero || ' - ' || c.bairro as endereco, c.indice_chave, c.situacao_imovel" +
                                                  " FROM chave c" +
                                                  "  WHERE indice_chave = '{0}'" +
                                                  " ORDER BY c.situacao_imovel, c.cod_chave " +
                                                  "", codChave));

            //gridTo.DataSource = tabela.DefaultView;

            foreach(DataRow row in tabela.Rows)
            {
                gridTo.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
            }



            gridTo.Columns[0].HeaderText = "Cód";
            gridTo.Columns[1].HeaderText = "Endereço";
            gridTo.Columns[2].Visible = false;
            gridTo.Columns[3].Visible = false;

            gridTo.Columns[0].Width = 30;
            gridTo.Columns[1].Width = 228;



            DataTable tabelaPlaca = new DataTable();

            tabelaPlaca =  database.select(string.Format("SELECT categoria_imovel, (CASE WHEN cond is null OR cond = '' THEN '' ELSE cond || ' - '  END) || rua || ', ' || ' Nº ' || numero || " +
                                                      " (CASE WHEN complemento = '' THEN '' ELSE '[' || complemento || ']' END) || ' - ' || bairro || " +
                                                      " ' (' || cod_imob || ')' as endereco, cod_chave, quant_chaves" +
                                                      " FROM chave" +
                                                      " WHERE indice_chave = '{0}'", codChave));

            foreach (DataRow linha in tabelaPlaca.Rows)
            {
                tipo.Add(linha[0].ToString());
                endereco.Add(linha[1].ToString());
                codQuantChave.Add(string.Format("Cód: {0}||Qtd: {1}", linha[2].ToString(), linha[3].ToString()));
                tamanhoFonte.Add(12);

                descImovel.Text = linha[1].ToString();
                descTipo.Text = linha[0].ToString().ToUpper();
                descCod.Text = string.Format("Cód: {0}||Qtd: {1}", linha[2].ToString(), linha[3].ToString());
                tamFonte.Value = 12;
            }
           
        }

        void atualizarGridFrom()
        {
            string codigosEscolhidos = "";

            int cont = 0;
            foreach(DataGridViewRow row in gridTo.Rows)
            {
                if (cont != gridTo.Rows.Count)
                {
                    //MessageBox.Show(row.Cells[0].Value.ToString());
                    codigosEscolhidos += " AND c.indice_chave != " + row.Cells[2].Value.ToString();
                }

                //codigosEscolhidos += row.Cells[2].Value.ToString() ;

                
            }

            //MessageBox.Show(codigosEscolhidos);

            tabelaChave.Rows.Clear();

            tabelaChave = database.select(string.Format("SELECT c.cod_chave, c.rua || ', ' || c.numero || ' - ' || c.bairro as endereco, c.indice_chave, c.situacao_imovel" +
                                                  " FROM chave c" +
                                                  "  WHERE (c.indice_chave != '{0}' {1}) AND " +
                                                  "  (cod_chave::text || 'c' ILIKE '{2}' OR ((unaccent(lower(c.rua))) ILIKE '%{2}%' OR (unaccent(lower(c.bairro))) ILIKE '%{2}%' OR (unaccent(lower(c.cidade))) ILIKE '%{2}%' OR (unaccent(lower(c.estado))) ILIKE '%{2}%' OR" +
                                                     " (unaccent(lower(c.numero)))  ILIKE '%{2}%' OR (unaccent(lower(c.complemento))) ILIKE '%{2}%' OR (unaccent(lower(c.cod_imob))) ILIKE '%{2}%' " +
                                                     " OR c.rua  ILIKE '%{2}%' OR c.bairro ILIKE '%{2}%' OR c.cidade ILIKE '%{2}%' OR c.estado ILIKE '%{2}%' OR c.numero ILIKE '%{2}%' OR " +
                                                     " c.complemento  ILIKE '%{2}%' OR c.cod_imob ILIKE '%{2}%'))" +
                                                  " ORDER BY c.situacao_imovel, c.cod_chave" +
                                                  "", codigoChave, codigosEscolhidos, boxBusca.Text));

            gridFrom.DataSource = tabelaChave.DefaultView;

           gridFrom.Columns[0].HeaderText = "Cód";
            gridFrom.Columns[1].HeaderText = "Endereço";
            gridFrom.Columns[2].Visible = false;
            gridFrom.Columns[3].Visible = false;

            gridFrom.Columns[0].Width = 30;
            gridFrom.Columns[1].Width = 228;

            qtdChaves = tabelaChave.Rows.Count;
            contPlacas.Text = string.Format("{0}/{1}", gridTo.Rows.Count, qtdChaves);

        }

        void atualizarRectTexto(string texto)
        {
            Bitmap bm = new Bitmap(imgTexto.Width, imgTexto.Height);
            Graphics drawer = Graphics.FromImage(bm);

            drawer.Clear(Color.White);

            //imgTexto.Size = new Size(cmToPixel(3.3), cmToPixel(1.9));
            Rectangle rect = new Rectangle(0, 0, cmToPixel(3.3), cmToPixel(1.9));

            Pen caneta = new Pen(new SolidBrush(Color.Black));
            drawer.DrawRectangle(caneta, rect);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            drawer.DrawString(texto,
                new Font("Consolas", (float)tamFonte.Value, FontStyle.Regular, GraphicsUnit.Pixel),
                new SolidBrush(Color.Black), rect, sf);

            imgTexto.BackgroundImage = bm;

        }
        void atualizarRectTipo (string texto)
        {
            //>>>>>>>>>Gerar previsão de tipo do imóvel <<<<<<<<<<<<
            Bitmap bmTipo = new Bitmap(imgTipo.Width, imgTipo.Height);
            Graphics drawerTipo = Graphics.FromImage(bmTipo);

            drawerTipo.Clear(Color.White);

            //imgTexto.Size = new Size(cmToPixel(3.3), cmToPixel(1.9));
            Rectangle rectTipo = new Rectangle(0, 0, cmToPixel(3.3), cmToPixel(0.4));

            Pen caneta = new Pen(new SolidBrush(Color.Black));

            drawerTipo.DrawRectangle(caneta, rectTipo);

            StringFormat sfTipo = new StringFormat();
            sfTipo.Alignment = StringAlignment.Center;
            sfTipo.LineAlignment = StringAlignment.Center;

            drawerTipo.DrawString(texto.ToUpper(),
                new Font("Consolas", (float)tamFonte.Value + 2, FontStyle.Bold, GraphicsUnit.Pixel),
                new SolidBrush(Color.Black), rectTipo, sfTipo);

            imgTipo.BackgroundImage = bmTipo;
        }

        void atualizarRectCodigo(string texto)
        {
            //>>>>>>>>>Gerar previsão de Cod do imóvel <<<<<<<<<<<<
            Bitmap bmCod = new Bitmap(imgCod.Width, imgCod.Height);
            Graphics drawerCod = Graphics.FromImage(bmCod);

            drawerCod.Clear(Color.White);

            //imgTexto.Size = new Size(cmToPixel(3.3), cmToPixel(1.9));
            Rectangle rectCod = new Rectangle(0, 0, cmToPixel(3.3), cmToPixel(0.4));

            Pen caneta = new Pen(new SolidBrush(Color.Black));

            drawerCod.DrawRectangle(caneta, rectCod);

            StringFormat sfCod = new StringFormat();
            sfCod.Alignment = StringAlignment.Center;
            sfCod.LineAlignment = StringAlignment.Center;

            drawerCod.DrawString(texto,
                new Font("Consolas", (float)tamFonte.Value, FontStyle.Bold, GraphicsUnit.Pixel),
                new SolidBrush(Color.Black), rectCod, sfCod);

            imgCod.BackgroundImage = bmCod;
        }

        private void ImprimirEtiquetas_Load(object sender, EventArgs e)
        {
            atualizarGridFrom();

            //gridTo.Rows.Clear();

            //DataGridViewColumn clmn = new DataGridViewColumn();

            //clmn.HeaderText = "Cód.";
            //clmn.ValueType = typeof(int);

            //gridTo.Columns.Add("codigo", "Cód.");
            //gridTo.Columns.Add("endereco", "Endereço");
            //gridTo.Columns.Add("indice", "indice");
            //gridTo.Columns.Add("situacao", "situacao");

            

            //gridTo.Columns[0].Width = 30;
            //gridTo.Columns[1].Width = 228;
            //gridTo.Columns[2].Visible = false;
            //gridTo.Columns[3].Visible = false;


            
            //descImovel.Size = new Size(cmToPixel(3.3), cmToPixel(1.9));

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
        private void gerarEtiquetas(List<string> tipo, List<string> endereco, List<string> codChave, List<float> tamanho)
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
                    //imagem.BackgroundImage.Save(@"C:\Users\Usuario\Desktop\Etiquetas\imageeem" + i.ToString() + ".jpg");
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

                    Font fonteTipo = new Font("Consolas", tamanho[i] + 2, FontStyle.Bold, GraphicsUnit.Pixel);
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

                    Font fonteTxtImovel = new Font("Consolas", tamanho[i], FontStyle.Regular, GraphicsUnit.Pixel);
                    Brush brushTxtImovel = new SolidBrush(Color.Black);
                    StringFormat sfTxtImovel = new StringFormat();
                    sfTxtImovel.Alignment = StringAlignment.Center;
                    sfTxtImovel.LineAlignment = StringAlignment.Center;

                    desenhador.DrawString(endereco[i], fonteTxtImovel, brushTxtImovel, rectTxt, sfTxtImovel);
                    //Ed.Morada do Sol\nRua João Paulo Rodrigues -Jardim São Domingos(L0157)

                    //>>>>>>>>>>>>>>>>> DESENHA O RETANGULO DA DESCRIÇÃO DA CHAVE <<<<<<<<<<<<<<<<<<<<<<
                    Font fonteTxtCodigo = new Font("Consolas", tamanho[i], FontStyle.Regular, GraphicsUnit.Pixel);
                    Brush brushTxtCodigo = new SolidBrush(Color.Black);
                    StringFormat sfTxtCodigo = new StringFormat();
                    sfTxtCodigo.Alignment = StringAlignment.Center;

                    Rectangle rectTxtCodigo = new Rectangle(pRectTxtCodigo, sRectTxtCodigo);
                    //desenhador.DrawRectangle(caneta, rectTxtCodigo);
                    desenhador.DrawString(codQuantChave[i], fonteTxtCodigo, brushTxtCodigo, rectTxtCodigo, sfTxtCodigo);


                    pRectBase.X += 200;
                    pRectImg.X = pRectBase.X + 6;
                    pRectTxtTipo.X = pRectImg.X - 3;
                    pRectTxtImovel.X = pRectTxtTipo.X;
                    pRectTxtCodigo.X = pRectTxtImovel.X;

                }
                catch { }



            }
            PrintImages();
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


        private void PrintDocument1_EndPrint(object sender, PrintEventArgs e)
        {
            pageIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            if(gridTo.Rows.Count + gridFrom.SelectedRows.Count > 120)
            {
                Message popup = new Message("O limite de plaquinhas foi atingido (Máx: 120)", "Erro", "erro", "confirma");
                popup.ShowDialog();
            }
            else
            {
                foreach (DataGridViewRow row in gridFrom.SelectedRows)
                {
                    try
                    {
                        string codigo = row.Cells[2].Value.ToString();

                        //MessageBox.Show(row.Cells[0].Value.ToString());
                        gridTo.Rows.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString());
                        //gridFrom.Rows.RemoveAt(row.Index);
                        

                        DataTable tabelaChaves = new DataTable();
                        tabelaChaves = database.select(string.Format("SELECT categoria_imovel, (CASE WHEN cond is null OR cond = '' THEN '' ELSE cond || ' - '  END) || rua || ', ' || ' Nº ' || numero || " +
                                                      " (CASE WHEN complemento = '' THEN '' ELSE ' [' || complemento || ']' END) || ' - ' || bairro || " +
                                                      " ' (' || cod_imob || ')' as endereco, cod_chave, quant_chaves" +
                                                      " FROM chave" +
                                                      " WHERE indice_chave = '{0}'", codigo));

                        foreach (DataRow linha in tabelaChaves.Rows)
                        {
                            tipo.Add(linha[0].ToString());
                            endereco.Add(linha[1].ToString());
                            codQuantChave.Add(string.Format("Cód: {0}||Qtd: {1}", linha[2].ToString(), linha[3].ToString()));
                            tamanhoFonte.Add(12);

                            descImovel.Text = linha[1].ToString();
                            descTipo.Text = linha[0].ToString().ToUpper();
                            descCod.Text = string.Format("Cód: {0}||Qtd: {1}", linha[2].ToString(), linha[3].ToString());
                            tamFonte.Value = 12;

                        }

                }
                    catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }

            }
                atualizarGridFrom();
            }


        }

        private void GridTo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
            try
            {

                DataGridViewRow row = gridTo.Rows[e.RowIndex];



                //DataTable tabelaPlaca = new DataTable();

                //tabelaPlaca = database.select(string.Format("SELECT categoria_imovel, (CASE WHEN cond is null OR cond = '' THEN '' ELSE cond || ' - '  END) || rua || ', ' || ' Nº ' || numero || " +
                //                                          " (CASE WHEN complemento = '' THEN '' ELSE '[' || complemento || ']' END) || ' - ' || bairro || " +
                //                                          " ' (' || cod_imob || ')' as endereco, cod_chave, quant_chaves" +
                //                                          " FROM chave" +
                //                                          " WHERE cod_chave = '{0}'", row.Cells[0].Value.ToString()));

                //string texto = "";
                //foreach (DataRow linha in tabelaPlaca.Rows)
                //{
                //    tipo.Add(linha[0].ToString());
                //    endereco.Add(linha[1].ToString());
                //    codQuantChave.Add(string.Format("Cód: {0}||Qtd: {1}", linha[2].ToString(), linha[3].ToString()));
                //    tamanhoFonte.Add(12);

                //    descImovel.Text = linha[1].ToString();
                //    descTipo.Text = linha[0].ToString().ToUpper();
                //    descCod.Text = string.Format("Cód: {0}||Qtd: {1}", linha[2].ToString(), linha[3].ToString());
                //    tamFonte.Value = 12;
                //}

                string texto = endereco[e.RowIndex];

                Font fonteTexto = new Font("Consolas", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                Image fakeImage = new Bitmap(1, 1);
                Graphics graphics = Graphics.FromImage(fakeImage);
                SizeF size = graphics.MeasureString(texto, fonteTexto);


                if (size.Height > imgTexto.Height)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 176, 176);
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(199, 76, 76);
                }

                //if (row.Cells[1].Value.ToString().Length > 50)
                //{
                //    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 176, 176);
                //    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(199, 76, 76);                }
            }
            catch { }
            
        }

       
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            descImovel.Enabled = true;
            descTipo.Enabled = true;
            descCod.Enabled = true;
            btnEditar.Enabled = false;
            btnSalvar.Enabled = true;
            tamFonte.Enabled = true;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            descImovel.Enabled = false;
            descTipo.Enabled = false;
            descCod.Enabled = false;
            btnEditar.Enabled = true;
            btnSalvar.Enabled = false;
            tamFonte.Enabled = false;

            endereco[gridTo.CurrentRow.Index] = descImovel.Text;
            tipo[gridTo.CurrentRow.Index] = descTipo.Text;
            codQuantChave[gridTo.CurrentRow.Index] = descCod.Text;
            tamanhoFonte[gridTo.CurrentRow.Index] = (float)tamFonte.Value;




        }

        private void GridTo_SelectionChanged(object sender, EventArgs e)
        {
           
         


            if (gridTo.CurrentRow.Selected)
            {
                descImovel.Text = "";
                descTipo.Text = "";
                descCod.Text = "";
            }

            descImovel.Enabled = false;
            descTipo.Enabled = false;
            descCod.Enabled = false;
            btnEditar.Enabled = true;
            btnSalvar.Enabled = false;
            try
            {
                descTipo.Text = tipo[gridTo.CurrentRow.Index];
                descCod.Text = codQuantChave[gridTo.CurrentRow.Index];
                descImovel.Text = endereco[gridTo.CurrentRow.Index];
                tamFonte.Value = (int)tamanhoFonte[gridTo.CurrentRow.Index];
               
            }
            catch { }


            try
            {
                Font fonteTexto = new Font("Consolas", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                Image fakeImage = new Bitmap(1, 1);
                Graphics graphics = Graphics.FromImage(fakeImage);
                SizeF size = graphics.MeasureString(descImovel.Text, fonteTexto, imgTexto.Width-5);

                //MessageBox.Show(string.Format("{0} - {1} (MAX: {2})", descImovel.Text, size.Height, imgTexto.Height));
            }
            catch { }
        }

        private void DescImovel_TextChanged(object sender, EventArgs e)
        {
            atualizarRectTexto(descImovel.Text);
        }

        private void BtnSelecTudo_Click(object sender, EventArgs e)
        {
            gridFrom.SelectAll();
        }

      


        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                gerarEtiquetas(tipo, endereco, codQuantChave, tamanhoFonte);
            }
            catch (Exception erro)
            {
                Message popup = new Message("Não foi possível gerar as etiquetas pelo seguinte erro: \n\n" + erro.Message,
                    "Erro", "erro", "confirma");
                popup.ShowDialog();
            }
            
        }

        private void BtnSelecTudoTo_Click(object sender, EventArgs e)
        {
            gridTo.Rows.Clear();
            tipo.Clear();
            endereco.Clear();
            codQuantChave.Clear();
            tamanhoFonte.Clear();

            atualizarGridFrom();

            descImovel.Text = "";
        }

        private void BtnPassSelectBack_Click(object sender, EventArgs e)
        {

        }

        private void gridTo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridTo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            contPlacas.Text = string.Format("{0}/{1}", gridTo.Rows.Count, qtdChaves);

            if (gridTo.Rows.Count == 0)
            {
                btnImprimir.Enabled = false;
            }
            else
            {
                btnImprimir.Enabled = true;
            }
        }

        private void gridTo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            contPlacas.Text = string.Format("{0}/{1}", gridTo.Rows.Count, qtdChaves);

            if (gridTo.Rows.Count == 0)
            {
                btnImprimir.Enabled = false;

            }
            else
            {
                btnImprimir.Enabled = true;
            }
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void ImgTexto_Click(object sender, EventArgs e)
        {

        }

        private void DescTipo_TextChanged(object sender, EventArgs e)
        {
            atualizarRectTipo(descTipo.Text);
        }

        private void DescCod_TextChanged(object sender, EventArgs e)
        {
            atualizarRectCodigo(descCod.Text);
        }

        private void TamFonte_ValueChanged(object sender, EventArgs e)
        {
            atualizarRectCodigo(descCod.Text);
            atualizarRectTipo(descTipo.Text);
            atualizarRectTexto(descImovel.Text);

            Font fonteTipo = new Font("Consolas", (float)tamFonte.Value, FontStyle.Bold, GraphicsUnit.Pixel);
            Font fonteTexto = new Font("Consolas", (float)tamFonte.Value, FontStyle.Regular, GraphicsUnit.Pixel);
            Font fonteCod = new Font("Consolas", (float)tamFonte.Value, FontStyle.Bold, GraphicsUnit.Pixel);

            descTipo.Font = fonteTipo;
            descImovel.Font = fonteTexto;
            descCod.Font = fonteCod;
        }

        private void DescTipo_Leave(object sender, EventArgs e)
        {
            descTipo.Text = descTipo.Text.ToUpper();
        }

        private void BoxBusca_TextChanged(object sender, EventArgs e)
        {
            atualizarGridFrom();
        }
    }
}

