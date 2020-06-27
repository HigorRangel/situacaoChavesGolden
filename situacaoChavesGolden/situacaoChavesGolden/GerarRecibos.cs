using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
//using iTextSharp.text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Data;


namespace situacaoChavesGolden
{
    class GerarRecibos
    {
        PostgreSQL database = new PostgreSQL();
        private void showDocument(string caminho)
        {
            try
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        CreateNoWindow = true,
                        Verb = "open",
                        FileName = caminho,
                    },
                };
                process.Start();
            }
            catch (Exception erro)
            {
                Message msg = new Message("Não foi possível abrir o relatório gerado!\nMotivo: " + erro.Message, "", "erro", "confirma");
                msg.ShowDialog();
            }

        }

        private DataTable buscarDadosEmprestimo(string codigo)
        {
            DataTable tabelaDados = new DataTable();

            tabelaDados = database.select(string.Format("SELECT e.data_retirada, u.cod_usuario || ' - ' || u.nome_usuario," +
                                                        "  c.cod_cliente || ' - ' || c.nome_cliente, " +
                                                        " c.contato_principal || (CASE WHEN c.contato_secundario is null OR c.contato_secundario = '' THEN "+
                                                        " '' ELSE ' / ' || c.contato_secundario END)," +
                                                        " e.documento, c.endereco, (CASE WHEN e.tipo_doc = '' OR e.tipo_doc is null" +
                                                        " THEN '' ELSE '(' || e.tipo_doc || ')' END)" +
                                                        " FROM emprestimo e " +
                                                        " INNER JOIN usuario u ON u.cod_usuario = e.cod_usuario " +
                                                        " LEFT JOIN cliente c ON c.cod_cliente = e.cod_cliente " +
                                                        " WHERE cod_emprestimo = '{0}'", codigo));

            return tabelaDados;
        }

        private DataTable buscarDadosChaves(string codigo)
        {
            DataTable tabelaDados = new DataTable();

            tabelaDados = database.select(string.Format("SELECT c.cod_chave," +
                                                        " c.rua || ', ' || c.numero ||" +
                                                        " CASE WHEN c.complemento IS NULL OR c.complemento = '' THEN '' ELSE ' - ' || c.complemento END, " +
                                                        " ce.quant_chaves, ce.quant_controles " +
                                                        " FROM chaves_emprestimo ce " +
                                                        " INNER JOIN emprestimo e ON e.cod_emprestimo = ce.cod_emprestimo " +
                                                        " INNER JOIN chave c ON c.indice_chave = ce.cod_chave" +
                                                        " WHERE ce.cod_emprestimo = '{0}'", codigo));

            return tabelaDados;
        }

        public void reciboEmprestimo(PictureBox picBox, string codigo, int vias)
        {
            //string caminho = Environment.CurrentDirectory + @"\temp\recibo-" +
            //    DateTime.Now.ToString("yyyy-MM-dd hh.mm.ss") + ".pdf";


            //Document doc = new Document(PageSize.A4, 5, 5, 5, 0);
            //PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            //doc.Open();

            ////Rectangle rectBase = new Rectangle(10, 785, 585, 830);
            ////rectBase.Border = Rectangle.BOX;
            ////rectBase.BorderWidth = 2;
            ////rectBase.BorderColor = BaseColor.DARK_GRAY;

            ////doc.Add(rectBase);

            //PdfPTable tableBaseHeader = new PdfPTable(2);
            //tableBaseHeader.WidthPercentage = 100;
            //tableBaseHeader.SetWidths(new float[] { 1, 3.6f });
            //tableBaseHeader.DefaultCell.BorderColorBottom = BaseColor.BLACK;

            //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.LogoRelatorio, BaseColor.WHITE, false);


            //PdfPCell logo = new PdfPCell(img);
            //logo.BackgroundColor = BaseColor.WHITE;
            //logo.BorderColor = BaseColor.WHITE;

            //tableBaseHeader.AddCell(logo);

            //doc.Add(tableBaseHeader);
            //doc.Add(new Paragraph("oi"));
            //doc.Close();

            //showDocument(caminho);

            DataTable tabelaEmprestimo = new DataTable();
            tabelaEmprestimo = buscarDadosEmprestimo(codigo);

            DateTime dateRet = new DateTime();
            string dataRetirada = "";
            string funcionario = "";
            string cliente = "";
            string contatoCliente = "";
            string docCliente = "";
            string enderecoCliente = "";

            foreach(DataRow row in tabelaEmprestimo.Rows)
            {
                dateRet = (DateTime)row[0];
                dataRetirada = dateRet.ToString("dd/MM/yyyy HH:mm:ss");
                funcionario = row[1].ToString();
                cliente = row[2].ToString();
                contatoCliente = row[3].ToString();
                docCliente = row[4].ToString() + " " + row[6].ToString();
                enderecoCliente = row[5].ToString();
            }

            DataTable tabelaChaves = new DataTable();
            tabelaChaves = buscarDadosChaves(codigo);

            string codigos = "\n";
            string enderecos = "\n";
            string qtdChaves = "\n";
            string qtdControles = "\n";

            foreach(DataRow row in tabelaChaves.Rows)
            {
                codigos += row[0].ToString() + "\n\n";
                enderecos += row[1].ToString() + "\n\n";
                qtdChaves += row[2].ToString() + "\n\n";
                qtdControles += row[3].ToString() + "\n\n";
            }
            
            if(tabelaChaves.Rows.Count < 5)
            {
                codigos += "\n\n\n\n\n";
            }

            ImprimirEtiquetas usarMetodo = new ImprimirEtiquetas();
            

            
            Bitmap img = new Bitmap(usarMetodo.cmToPixel(21), usarMetodo.cmToPixel(29.7));
            Graphics drawer = Graphics.FromImage(img);


            drawer.Clear(Color.White);


            Pen pen = new Pen(Color.Black, 1);


            //>>>>>>>>>>>>>>> RETANGULO BASE <<<<<<<<<<<<<<<<<<<<<<<<
            Point pBase = new Point(5, 5);
            Size sBase = new Size(usarMetodo.cmToPixel(20), usarMetodo.cmToPixel(15));

            for (int i = 0; i < vias; i++)
            {
                //if (i == 1)
                //{
                //    pBase = new Point(pBase.X, pBase.Y + sBase.Height + 50);
                //    sBase = new Size(sBase.Width, sBase.Height - 120);
                //}

                Rectangle rectBase = new Rectangle(pBase, sBase);



                drawer.DrawRectangle(new Pen(Color.White, 1), rectBase);

                //>>>>>>>>>>>>>> RETANGULO HEADER <<<<<<<<<<<<<<<<<<<<<<
                Point pHeader = new Point(pBase.X, pBase.Y);
                Size sHeader = new Size(sBase.Width, usarMetodo.cmToPixel(1.5));
                Rectangle rectHeader = new Rectangle(pHeader, sHeader);

                drawer.DrawRectangle(pen, rectHeader);

                //>>>>>>>>>>>>>>>>>>>> RETANGULO LOGO <<<<<<<<<<<<<<<<<<<<<<<<
                Point pLogo = new Point(pHeader.X + 6, pHeader.Y + 5);
                Size sLogo = new Size(usarMetodo.cmToPixel(3), sHeader.Height - 20);
                Rectangle rectLogo = new Rectangle(pLogo, sLogo);

                //drawer.DrawRectangle(pen, rectLogo);
                drawer.DrawImage(Properties.Resources.logoSbernardo, rectLogo);

                //>>>>>>>>>>>>>>> RETANGULO TEXTO HEADER  1 <<<<<<<<<<<<<<<<
                Point pTextHeader1 = new Point(pLogo.X + sLogo.Width + 9, pLogo.Y);
                Size sTextHeader1 = new Size(sHeader.Width - sLogo.Width - 250, sLogo.Height + 10);
                Rectangle rectTextHeader1 = new Rectangle(pTextHeader1, sTextHeader1);

                // drawer.DrawRectangle(pen, rectTextHeader1);

                //>>>>>>>>>>>>>> Texto Header <<<<<<<<<<<<<<
                Font fonteHeader1 = new Font("Consolas", 9, FontStyle.Bold);
                string textoHeader1 = "IMOBILIÁRIA SÃO BERNARDO LTDA\n" +
                                      "Rua Fernando Camargo, 587 - Centro - Americana/SP\n" +
                                      "(19) 3406-2423 / (19) 9 9110-8041";
                StringFormat formatTxtHeader = new StringFormat();
                formatTxtHeader.LineAlignment = StringAlignment.Center;

                drawer.DrawString(textoHeader1, fonteHeader1, new SolidBrush(Color.Black), rectTextHeader1, formatTxtHeader);

                //drawer.DrawRectangle(pen, rectTextHeader1);

                //>>>>>>>>>>>>>>> RETANGULO TEXTO HEADER 2 <<<<<<<<<<<<<<<<
                Point pTextHeader2 = new Point(pTextHeader1.X + sTextHeader1.Width + 5, pTextHeader1.Y);
                Size sTextHeader2 = new Size(sHeader.Width - (sLogo.Width + sTextHeader1.Width) - 25, sTextHeader1.Height);
                Rectangle rectTextHeader2 = new Rectangle(pTextHeader2, sTextHeader2);

                //drawer.DrawRectangle(pen, rectTextHeader2);

                //>>>>>>>>>>>>>>>>> Divisória <<<<<<<<<<<<<<<<<<<<


                drawer.DrawLine(pen, pTextHeader1.X + sTextHeader1.Width + 5, pTextHeader1.Y + 8, pTextHeader1.X + sTextHeader1.Width + 5,
                                     pTextHeader1.Y + sTextHeader1.Height - 8);

                //>>>>>>>>>>>>>> Texto Header 2<<<<<<<<<<<<<<
                Font fonteHeader2 = new Font("Consolas", 8, FontStyle.Bold);
                string textoHeader2 = string.Format("Funcionário(a): {0}\n\n" +
                                      "Gerado em: {1}", funcionario, dataRetirada);
                StringFormat formatTxtHeader2 = new StringFormat();
                formatTxtHeader2.LineAlignment = StringAlignment.Center;
                formatTxtHeader2.Alignment = StringAlignment.Far;

                drawer.DrawString(textoHeader2, fonteHeader2, new SolidBrush(Color.Black), rectTextHeader2, formatTxtHeader2);

                //drawer.DrawRectangle(pen, rectTextHeader2);

                //>>>>>>>>>>>>>>>>>>> Título <<<<<<<<<<<<<<<<<<
                Point pTitulo = new Point(pHeader.X, pHeader.Y + sHeader.Height + 5);
                Size sTitulo = new Size(sHeader.Width, usarMetodo.cmToPixel(0.6));
                Rectangle rectTitulo = new Rectangle(pTitulo, sTitulo);

                //drawer.DrawRectangle(pen, rectTitulo);

                Font fonteTitulo = new Font("Consolas", 11, FontStyle.Bold);
                string titulo = string.Format("RECIBO DE EMPRÉSTIMO DE CHAVES ({0})", codigo);
                StringFormat formatTitulo = new StringFormat();
                formatTitulo.LineAlignment = StringAlignment.Center;
                formatTitulo.Alignment = StringAlignment.Center;
                
                drawer.DrawString(titulo, fonteTitulo, new SolidBrush(Color.Black), rectTitulo, formatTitulo);



                //>>>>>>>>>>>>>>>>>>>>> Header Coluna códigos <<<<<<<<<<<<<<<<<<<<<<<<<<
                Point pColHeaderCodigos = new Point(pHeader.X + 13, pTitulo.Y + sTitulo.Height + 5);
                Size sColHeaderCodigos = new Size(48, usarMetodo.cmToPixel(0.5));
                Rectangle rectColHeaderCodigos = new Rectangle(pColHeaderCodigos, sColHeaderCodigos);

                //drawer.DrawRectangle(pen, rectColHeaderCodigos);

                //>>>>>>>>>>>>>>>>>>>>> Coluna códigos <<<<<<<<<<<<<<<<<<<<<<<<<<

                Font fontColChaves = new Font("Consolas", 10, FontStyle.Regular);
                Point pColCodigos = new Point(pColHeaderCodigos.X, pColHeaderCodigos.Y + sColHeaderCodigos.Height + 10);
                Image fakeImage = new Bitmap(1, 1);
                Graphics graphics = Graphics.FromImage(fakeImage);
                SizeF size = graphics.MeasureString(codigos, fontColChaves);

                //Size sTeste = new Size(sColHeaderQtdChaves.Width, sColEndereco.Height);

                Size sColCodigos = new Size(sColHeaderCodigos.Width, (int)size.Height);
                Rectangle rectColCodigos = new Rectangle(pColCodigos, sColCodigos);

                //drawer.DrawRectangle(pen, rectColCodigos);

                Font fontColHeaderChaves = new Font("Consolas", 11, FontStyle.Bold);
                StringFormat formatColChaves = new StringFormat();
                //formatColChaves.LineAlignment = StringAlignment.Center;
                formatColChaves.Alignment = StringAlignment.Center;

                drawer.DrawString("Chave", fontColHeaderChaves, new SolidBrush(Color.DarkSlateGray), rectColHeaderCodigos, formatColChaves);
                drawer.DrawString(codigos, fontColChaves, new SolidBrush(Color.DarkSlateGray), rectColCodigos, formatColChaves);
                // + "1\n\n1\n\n2\n\n3\n\n4"

                //>>>>>>>>>>>>>>>>>>>> Header Coluna Endereço <<<<<<<<<<<<<<<<
                Point pColHeaderEndereco = new Point(pColHeaderCodigos.X + sColHeaderCodigos.Width + 15, pColHeaderCodigos.Y);
                Size sColHeaderEndereco = new Size(535, sColHeaderCodigos.Height);
                Rectangle rectColHeaderEndereco = new Rectangle(pColHeaderEndereco, sColHeaderEndereco);

                Font fontColHeaderEndereco = new Font("Consolas", 11, FontStyle.Bold);
                StringFormat formatColHeaderEndereco = new StringFormat();
                //formatColHeaderEndereco.LineAlignment = StringAlignment.Center;
                formatColHeaderEndereco.Alignment = StringAlignment.Center;

                drawer.DrawString("Endereço", fontColHeaderChaves, new SolidBrush(Color.DarkSlateGray), rectColHeaderEndereco, formatColHeaderEndereco);
                //drawer.DrawRectangle(pen, rectColHeaderEndereco);

                //>>>>>>>>>>>>>>>>>>>> Coluna endereço <<<<<<<<<<<<<<<<<<
                Point pColEndereco = new Point(pColCodigos.X + sColCodigos.Width + 15, pColCodigos.Y);
                Size sColEndereco = new Size(535, sColCodigos.Height);
                Rectangle rectColEndereco = new Rectangle(pColEndereco, sColEndereco);

                StringFormat formatColEndereco = new StringFormat();
                //formatColEndereco.LineAlignment = StringAlignment.Center;
                formatColEndereco.Alignment = StringAlignment.Near;

                drawer.DrawString(enderecos, fontColChaves, new SolidBrush(Color.DarkSlateGray), rectColEndereco, formatColEndereco);

                //drawer.DrawRectangle(pen, rectColEndereco);

                //>>>>>>>>>>>>>> Header Coluna Quant Chaves <<<<<<<<<<<<<<<<<
                Point pColHeaderQtdChaves = new Point(pColHeaderEndereco.X + sColHeaderEndereco.Width + 15, pColHeaderEndereco.Y - 15);
                Size sColHeaderQtdChaves = new Size(50, sColHeaderEndereco.Height * 2);
                Rectangle rectHeaderQtdChaves = new Rectangle(pColHeaderQtdChaves, sColHeaderQtdChaves);
                Font fontColHeaderQtdChaves = new Font("Consolas", 9, FontStyle.Bold);
                StringFormat formatHeaderQtds = new StringFormat();
                formatHeaderQtds.LineAlignment = StringAlignment.Far;
                formatHeaderQtds.Alignment = StringAlignment.Center;

                drawer.DrawString("Qtd Chaves", fontColHeaderQtdChaves, new SolidBrush(Color.DarkSlateGray), rectHeaderQtdChaves, formatHeaderQtds);
                //drawer.DrawRectangle(pen, rectHeaderQtdChaves);

                //>>>>>>>>>>>>>>> Coluna Quant Chaves <<<<<<<<<<<<<<<<
                Point pColQtdChaves = new Point(pColHeaderQtdChaves.X, pColEndereco.Y);
                Size sColQtdChaves = new Size(sColHeaderQtdChaves.Width, sColEndereco.Height);
                Rectangle rectQtdChaves = new Rectangle(pColQtdChaves, sColQtdChaves);

                drawer.DrawString(qtdChaves, fontColChaves, new SolidBrush(Color.DarkSlateGray), rectQtdChaves, formatColChaves);

                //drawer.DrawRectangle(pen, rectQtdChaves);

                //>>>>>>>>>>>> Header Coluna Quant Controles <<<<<<<<<<<<<
                Point pColHeaderQtdCtrl = new Point(pColHeaderQtdChaves.X + sColHeaderQtdChaves.Width + 15, pColHeaderQtdChaves.Y);
                Size sColHeaderQtdCtrl = new Size(50, sColHeaderQtdChaves.Height);
                Rectangle rectQtdHeaderCtrl = new Rectangle(pColHeaderQtdCtrl, sColHeaderQtdCtrl);

                drawer.DrawString("Qtd Ctrls", fontColHeaderQtdChaves, new SolidBrush(Color.DarkSlateGray), rectQtdHeaderCtrl, formatHeaderQtds);

                //drawer.DrawRectangle(pen, rectQtdHeaderCtrl);


                //>>>>>>>>>>>>>>> Coluna Quant Controles <<<<<<<<<<<<<<<<
                Point pColQtdCtrl = new Point(pColHeaderQtdCtrl.X, pColQtdChaves.Y);
                Size sColQtdCtrl = new Size(sColHeaderQtdCtrl.Width, sColQtdChaves.Height);
                Rectangle rectQtdCtrl = new Rectangle(pColQtdCtrl, sColQtdCtrl);

                drawer.DrawString(qtdControles, fontColChaves, new SolidBrush(Color.DarkSlateGray), rectQtdCtrl, formatColChaves);

                //drawer.DrawRectangle(pen, rectQtdCtrl);


                //>>>>>>>>>>>>>>>>>>>>. Base desenhada <<<<<<<<<<<<<<<<<<

                Point pFooter = new Point(pBase.X, pColCodigos.Y + sColCodigos.Height);
                Size sFooter = new Size(sBase.Width, 135);

                if (i == 0)
                {
                    
                  
                    Rectangle rectFooter = new Rectangle(pFooter, sFooter);

                    drawer.DrawRectangle(pen, rectFooter);

                    //>>>>>>>>>>>>>>>>>>> DIV 1 <<<<<<<<<<<<<<<<<<
                    Point pDiv1 = new Point(pFooter.X, pFooter.Y);
                    Size sDiv1 = new Size(sFooter.Width / 2, sFooter.Height);
                    Rectangle rectDiv1 = new Rectangle(pDiv1, sDiv1);

                    drawer.DrawRectangle(pen, rectDiv1);


                    //>>>>>>>>>>>>>> DIV 1 texto <<<<<<<<<<<<<<<<<<

                    Point pDiv1Txt = new Point(pDiv1.X + 10, pDiv1.Y);
                    Size sDiv1Txt = new Size(sDiv1.Width - 10, sDiv1.Height);
                    Rectangle rectDiv1Txt = new Rectangle(pDiv1Txt, sDiv1Txt);



                    string dadosCliente = string.Format("Nome: {0}\n\n" +
                                                        "Documento: {1}\n\n" +
                                                        "Contato: {2}\n\n" +
                                                        "Endereço: {3}", cliente.ToUpper(), docCliente, contatoCliente, enderecoCliente.ToUpper());
                    Font fontDiv1 = new Font("Consolas", 10, FontStyle.Bold);
                    StringFormat formatDiv1 = new StringFormat();
                    formatDiv1.Alignment = StringAlignment.Near;
                    formatDiv1.LineAlignment = StringAlignment.Near;

                    drawer.DrawRectangle(pen, rectDiv1);
                    drawer.DrawString(dadosCliente, fontDiv1, new SolidBrush(Color.Black), rectDiv1Txt);


                    //>>>>>>>>>>>>>>>>>>>>>> DIV 2 <<<<<<<<<<<<<<<<<<<<
                    Point pDiv2 = new Point(pDiv1.X + sDiv1.Width, pDiv1.Y);
                    Size sDiv2 = new Size(sDiv1.Width / 2, sDiv1.Height);
                    Rectangle rectDiv2 = new Rectangle(pDiv2, sDiv2);

                    drawer.DrawRectangle(pen, rectDiv2);

                    Pen penAssinatura = new Pen(new SolidBrush(Color.Black), 2);

                    Point pLineAss1 = new Point(pDiv2.X + 15, pDiv2.Y + sDiv2.Height - 35);
                    Point pLineAss2 = new Point(pDiv2.X + sDiv2.Width - 15, pDiv2.Y + sDiv2.Height - 35);

                    drawer.DrawLine(penAssinatura, pLineAss1, pLineAss2);
                    Font fontTxtAss = new Font("Consolas", 8);

                    drawer.DrawString("ASSINATURA DO CLIENTE", fontTxtAss, new SolidBrush(Color.Black), pLineAss1.X + 15, pLineAss1.Y + 2);


                    //>>>>>>>>>>>>>>>>>>>> DIV 3 <<<<<<<<<<<<<<<<<<<
                    Point pDiv3 = new Point(pDiv2.X + sDiv2.Width, pDiv2.Y);
                    Size sDiv3 = new Size(sDiv2.Width + 2, sDiv2.Height);
                    Rectangle rectDiv3 = new Rectangle(pDiv3, sDiv3);

                    drawer.DrawRectangle(pen, rectDiv3);
                    drawer.DrawString("\n Entrega: ___/___/_____\n\n\n\n" +
                                      " Funcionário: _________", fontDiv1, new SolidBrush(Color.Black), rectDiv3);

                }

                Point pBaseDraw = new Point();
                Size sBaseDraw = new Size();

                if (i == 0)
                {
                     pBaseDraw = new Point(pBase.X, pBase.Y);
                    //Size sBaseDraw = new Size(sBase.Width, sBase.Height - (pFooter.Y + sFooter.Height));
                    sBaseDraw = new Size(sBase.Width, sHeader.Height + sTitulo.Height + sColHeaderCodigos.Height +
                                               sColCodigos.Height + sFooter.Height + 20);
                }
                else
                {
                    pBaseDraw = new Point(pBase.X, pBase.Y);
                    //Size sBaseDraw = new Size(sBase.Width, sBase.Height - (pFooter.Y + sFooter.Height));
                    sBaseDraw = new Size(sBase.Width, sHeader.Height + sTitulo.Height + sColHeaderCodigos.Height +
                                               sColCodigos.Height + 20);
                }
                
                Rectangle rectBaseDraw = new Rectangle(pBaseDraw, sBaseDraw);

                drawer.DrawRectangle(pen, rectBaseDraw);

                pBase = new Point(pBaseDraw.X, pBaseDraw.Y + sBaseDraw.Height + 50);
                sBase = new Size(sBaseDraw.Width, sBaseDraw.Height - sFooter.Height);

                ////>>>>>>>>>>>>>>> Coluna Quant Chaves <<<<<<<<<<<<<<<<
                //Point pTeste = new Point(pBase.X, pBase.Y + sBase.Height + 50);

                //Image fakeImage = new Bitmap(1, 1);
                //Graphics graphics = Graphics.FromImage(fakeImage);
                //SizeF size = graphics.MeasureString(qtdChaves + "1\n\n3\n\n4\n\n5\n\n5\n\n1\n\n", fontColChaves);

                ////Size sTeste = new Size(sColHeaderQtdChaves.Width, sColEndereco.Height);
                //Size sTeste = new Size(sColHeaderQtdChaves.Width, (int)size.Height);


                //Rectangle rectTest = new Rectangle(pTeste, sTeste);

                //drawer.DrawString(qtdChaves + "1\n\n3\n\n4\n\n5\n\n5\n\n1\n\n", fontColChaves, new SolidBrush(Color.DarkSlateGray), rectTest, formatColChaves);

                //drawer.DrawRectangle(pen, rectTest);

            }





            picBox.BackgroundImage = img;




        }

        private DataTable buscarDadosReserva(string codigo)
        {
            DataTable tabela = new DataTable();

            database.select(string.Format("SELECT r.cod_reserva, " +
                            " (CASE WHEN r.cod_proprietario is null AND r.cod_cliente is null THEN '[' || u.cod_usuario || '] - ' || u.nome_usuario || ' (' || 'FUNCIONARIO' || ')'" +
                            " WHEN r.cod_proprietario is null AND r.cod_cliente is not null THEN '[' || cl.cod_cliente || '] - ' || cl.nome_cliente || ' (' || 'CLIENTE' || ')'" +
                            " WHEN r.cod_proprietario is not null AND r.cod_cliente is null THEN '[' || p.cod_proprietario || '] - ' || p.nome || ' (' || 'PROPRIETÁRIO' || ')' END) as tipo," +

                            " (CASE WHEN r.cod_proprietario is null AND r.cod_cliente is null THEN ''" +
                            "  WHEN r.cod_proprietario is null AND r.cod_cliente is not null THEN(CASE WHEN cl.contato_secundario is null OR cl.contato_secundario = '' THEN cl.contato_principal ELSE cl.contato_principal || '/' || cl.contato_secundario END)" +
                            " WHEN r.cod_proprietario is not null AND r.cod_cliente is null THEN p.contato::text END) as contato," +
                            " r.data_reserva, u.nome_usuario" +
                            " FROM reserva r" +
                            " LEFT JOIN usuario u ON r.cod_usuario = u.cod_usuario" +
                            " LEFT JOIN proprietario p ON r.cod_proprietario = p.cod_proprietario" +
                            " LEFT JOIN cliente cl ON r.cod_cliente = cl.cod_cliente" +
                            " WHERE r.cod_reserva = '{0}'", codigo));


            return tabela;
        }

        private DataTable buscarDadosChavesReserva(string codigo)
        {
            DataTable tabela = new DataTable();

            database.select(string.Format("SELECT c.cod_chave,  c.cod_imob " +
                                            " FROM reserva r  " +
                                            " INNER JOIN chaves_reserva cr ON cr.cod_reserva = r.cod_reserva " +
                                            " INNER JOIN chave c ON c.indice_chave = cr.cod_chave " +
                                            " WHERE r.cod_reserva = '{0}'", codigo));

            return tabela;
        }
        public void reciboReserva(PictureBox picbox, string codigo)
        {

            ImprimirEtiquetas usarMetodo = new ImprimirEtiquetas();

            Bitmap img = new Bitmap(usarMetodo.cmToPixel(21), usarMetodo.cmToPixel(29.7));
            Graphics drawer = Graphics.FromImage(img);


            drawer.Clear(Color.White);

            DataTable tabelaDadosChaves = new DataTable();

            tabelaDadosChaves = buscarDadosChavesReserva(codigo);

            Pen pen = new Pen(new SolidBrush(Color.Black), 1);

            //============== RETÂNGULO DA BASE ===============

            Point pBase = new Point(10, 10);
            Size sBase = new Size(usarMetodo.cmToPixel(5.8), usarMetodo.cmToPixel(7));
            Rectangle rectBase = new Rectangle(pBase, sBase);

            MessageBox.Show(tabelaDadosChaves.Rows.Count.ToString());
            int cont = 0;

            foreach (DataRow row in tabelaDadosChaves.Rows)
            {

                if(cont ==0)
                {
                    drawer.DrawRectangle(pen, rectBase);

                }
                else
                {
                    pBase = new Point(pBase.X + sBase.Width + 40, pBase.Y);

                    drawer.DrawRectangle(pen, rectBase);

                    //============= HEADER ================

                    Point pHeader = new Point(pBase.X, pBase.Y);
                    Size sHeader = new Size(sBase.Width, usarMetodo.cmToPixel(2.8));
                    Rectangle rectHeader = new Rectangle(pHeader, sHeader);


                    drawer.DrawRectangle(pen, rectHeader);

                    //================ IMAGEM ==================

                    Point pImagem = new Point(pHeader.X + 40, pHeader.Y + 4);
                    Size sImagem = new Size(sHeader.Width - 80, 60);
                    Rectangle rectImagem = new Rectangle(pImagem, sImagem);


                    //drawer.DrawRectangle(pen, rectImagem);

                    Image imagem = Properties.Resources.LogoRelatorio;

                    drawer.DrawImage(imagem, rectImagem);


                    //============== TEXT ================
                    Point pTexto = new Point(pHeader.X + 10, pImagem.Y + sImagem.Height);
                    Size sTexto = new Size(sHeader.Width - 20, 35);

                    Rectangle rectText = new Rectangle(pTexto, sTexto);

                    //drawer.DrawRectangle(pen, rectText);

                    StringFormat sfTextoHeader = new StringFormat();
                    sfTextoHeader.Alignment = StringAlignment.Center;
                    sfTextoHeader.LineAlignment = StringAlignment.Center;

                    drawer.DrawString("Rua Fernando Camargo, 587\n  Centro - Americana/SP - 13477-650\n(19) 3406-2423 / (19) 9 9140-8110", new Font("Arial", 8), new SolidBrush(Color.Gray), rectText, sfTextoHeader);

                    Font fontTitulo = new Font("Arial", 10, FontStyle.Bold);
                    StringFormat sfTitulo1 = new StringFormat();
                    StringFormat sfTitulo2 = new StringFormat();
                    sfTitulo2.LineAlignment = StringAlignment.Center;


                    //============= BASE DO CONTEUDO =======================
                    Point pBaseConteudo = new Point(pHeader.X, pHeader.Y + sHeader.Height);
                    Size sBaseConteudo = new Size(sHeader.Width, sBase.Height - sHeader.Height);
                    Rectangle rectBaseConteudo = new Rectangle(pBaseConteudo, sBaseConteudo);

                    drawer.DrawRectangle(pen, rectBaseConteudo);

                    //=============== NOME DA PESSOA ================
                    Point pNomePessoa = new Point(pBaseConteudo.X + 10, pBaseConteudo.Y + 10);
                    Size sNomePessoa = new Size(sBaseConteudo.Width - 20, 40);
                    Rectangle rectNomePessoa = new Rectangle(pNomePessoa, sNomePessoa);

                    drawer.DrawRectangle(pen, rectNomePessoa);
                    drawer.DrawString("Nome:", fontTitulo, new SolidBrush(Color.Black), rectNomePessoa, sfTitulo1);
                    //=============== CONTATO DA PESSOA ================
                    Point pContato = new Point(pNomePessoa.X, pNomePessoa.Y + sNomePessoa.Height);
                    Size sContato = new Size(sNomePessoa.Width, 25);
                    Rectangle rectContato = new Rectangle(pContato, sContato);

                    drawer.DrawRectangle(pen, rectContato);
                    drawer.DrawString("Contato:", fontTitulo, new SolidBrush(Color.Black), rectContato, sfTitulo2);
                    //=============== CÓDIGO DO IMÓVEL ================
                    Point pCodImob = new Point(pContato.X, pContato.Y + sContato.Height);
                    Size sCodImob = new Size(sContato.Width, sContato.Height);
                    Rectangle rectCodImob = new Rectangle(pCodImob, sCodImob);

                    drawer.DrawRectangle(pen, rectCodImob);
                    drawer.DrawString("Cód. Imob:", fontTitulo, new SolidBrush(Color.Black), rectCodImob, sfTitulo2);
                    //=============== CÓDIGO DA CHAVE ================
                    Point pCodChave = new Point(pCodImob.X, pCodImob.Y + sCodImob.Height);
                    Size sCodChave = new Size(sCodImob.Width, sCodImob.Height);
                    Rectangle rectCodChave = new Rectangle(pCodChave, sCodChave);

                    drawer.DrawRectangle(pen, rectCodChave);
                    drawer.DrawString("Cód. Chave:", fontTitulo, new SolidBrush(Color.Black), rectCodChave, sfTitulo2);
                    //=============== ATENDENTE ================
                    Point pAtendente = new Point(pCodChave.X, pCodChave.Y + sCodChave.Height);
                    Size sAtendente = new Size(sCodChave.Width, sCodChave.Height);
                    Rectangle rectAtendente = new Rectangle(pAtendente, sAtendente);

                    drawer.DrawRectangle(pen, rectAtendente);
                    drawer.DrawString("Atendente:", fontTitulo, new SolidBrush(Color.Black), rectAtendente, sfTitulo2);
                }


                cont++;
            }

            picbox.BackgroundImage = img;



        }
    }
}
