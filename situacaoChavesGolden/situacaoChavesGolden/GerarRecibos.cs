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

            tabelaDados = database.select(string.Format("SELECT e.data_retirada, u.cod_usuario || ' - ' || u.nome_usuario, c.cod_cliente || ' - ' ||c.nome_cliente, c.cpf," +
                                                        " c.documento, c.endereco  " +
                                                        "FROM emprestimo e " +
                                                        "INNER JOIN usuario u ON u.cod_usuario = e.cod_usuario " +
                                                        "LEFT JOIN cliente c ON c.cod_cliente = e.cod_cliente " +
                                                        "WHERE cod_emprestimo = '{0}'", codigo));

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

        public void reciboEmprestimo(PictureBox picBox, string codigo)
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
            string cpfCliente = "";
            string docCliente = "";
            string enderecoCliente = "";

            foreach(DataRow row in tabelaEmprestimo.Rows)
            {
                dateRet = (DateTime)row[0];
                dataRetirada = dateRet.ToString("dd/MM/yyyy hh:mm:ss");
                funcionario = row[1].ToString();
                cliente = row[2].ToString();
                cpfCliente = row[3].ToString();
                docCliente = row[4].ToString();
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
            
            ImprimirEtiquetas usarMetodo = new ImprimirEtiquetas();
            


            Bitmap img = new Bitmap(usarMetodo.cmToPixel(21), usarMetodo.cmToPixel(29.7));
            Graphics drawer = Graphics.FromImage(img);


            drawer.Clear(Color.White);


            Pen pen = new Pen(Color.Black, 1);

            //>>>>>>>>>>>>>>> RETANGULO BASE <<<<<<<<<<<<<<<<<<<<<<<<
            Point pBase = new Point(15, 15);
            Size sBase = new Size(usarMetodo.cmToPixel(20), usarMetodo.cmToPixel(15));
            Rectangle rectBase = new Rectangle(pBase, sBase);

            drawer.DrawRectangle(pen, rectBase);

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
            Point pColCodigos = new Point(pColHeaderCodigos.X, pColHeaderCodigos.Y + sColHeaderCodigos.Height + 10);
            Size sColCodigos = new Size(sColHeaderCodigos.Width, 340) ;
            Rectangle rectColCodigos = new Rectangle(pColCodigos, sColCodigos);

            //drawer.DrawRectangle(pen, rectColCodigos);

            Font fontColChaves = new Font("Consolas", 10, FontStyle.Regular);
            Font fontColHeaderChaves = new Font("Consolas", 11, FontStyle.Bold);
            StringFormat formatColChaves = new StringFormat();
            //formatColChaves.LineAlignment = StringAlignment.Center;
            formatColChaves.Alignment = StringAlignment.Center;

            drawer.DrawString("Chave", fontColHeaderChaves, new SolidBrush(Color.Gray), rectColHeaderCodigos, formatColChaves);
            drawer.DrawString(codigos + "1\n\n1\n\n2\n\n3\n\n4", fontColChaves, new SolidBrush(Color.Gray), rectColCodigos, formatColChaves);


            //>>>>>>>>>>>>>>>>>>>> Header Coluna Endereço <<<<<<<<<<<<<<<<
            Point pColHeaderEndereco = new Point(pColHeaderCodigos.X + sColHeaderCodigos.Width + 15, pColHeaderCodigos.Y);
            Size sColHeaderEndereco = new Size(535, sColHeaderCodigos.Height);
            Rectangle rectColHeaderEndereco = new Rectangle(pColHeaderEndereco, sColHeaderEndereco);

            Font fontColHeaderEndereco = new Font("Consolas", 11, FontStyle.Bold);
            StringFormat formatColHeaderEndereco = new StringFormat();
            //formatColHeaderEndereco.LineAlignment = StringAlignment.Center;
            formatColHeaderEndereco.Alignment = StringAlignment.Center;

            drawer.DrawString("Endereço", fontColHeaderChaves, new SolidBrush(Color.Gray), rectColHeaderEndereco, formatColHeaderEndereco);
            //drawer.DrawRectangle(pen, rectColHeaderEndereco);

            //>>>>>>>>>>>>>>>>>>>> Coluna endereço <<<<<<<<<<<<<<<<<<
            Point pColEndereco = new Point(pColCodigos.X + sColCodigos.Width + 15, pColCodigos.Y);
            Size sColEndereco = new Size(535, sColCodigos.Height);
            Rectangle rectColEndereco = new Rectangle(pColEndereco, sColEndereco);

            StringFormat formatColEndereco = new StringFormat();
            //formatColEndereco.LineAlignment = StringAlignment.Center;
            formatColEndereco.Alignment = StringAlignment.Near;

            drawer.DrawString(enderecos, fontColChaves, new SolidBrush(Color.Gray), rectColEndereco, formatColEndereco);

            //drawer.DrawRectangle(pen, rectColEndereco);

            //>>>>>>>>>>>>>> Header Coluna Quant Chaves <<<<<<<<<<<<<<<<<
            Point pColHeaderQtdChaves = new Point(pColHeaderEndereco.X + sColHeaderEndereco.Width + 15, pColHeaderEndereco.Y - 15);
            Size sColHeaderQtdChaves = new Size(50, sColHeaderEndereco.Height * 2);
            Rectangle rectHeaderQtdChaves = new Rectangle(pColHeaderQtdChaves, sColHeaderQtdChaves);
            Font fontColHeaderQtdChaves = new Font("Consolas", 9, FontStyle.Bold);
            StringFormat formatHeaderQtds = new StringFormat();
            formatHeaderQtds.LineAlignment = StringAlignment.Far;
            formatHeaderQtds.Alignment = StringAlignment.Center;
            
            drawer.DrawString("Qtd Chaves", fontColHeaderQtdChaves, new SolidBrush(Color.Gray), rectHeaderQtdChaves, formatHeaderQtds);
            //drawer.DrawRectangle(pen, rectHeaderQtdChaves);

            //>>>>>>>>>>>>>>> Coluna Quant Chaves <<<<<<<<<<<<<<<<
            Point pColQtdChaves = new Point(pColHeaderQtdChaves.X, pColEndereco.Y);
            Size sColQtdChaves = new Size(sColHeaderQtdChaves.Width, sColEndereco.Height);
            Rectangle rectQtdChaves = new Rectangle(pColQtdChaves, sColQtdChaves);

            drawer.DrawString(qtdChaves, fontColChaves, new SolidBrush(Color.Gray), rectQtdChaves, formatColChaves);

            //drawer.DrawRectangle(pen, rectQtdChaves);

            //>>>>>>>>>>>> Header Coluna Quant Controles <<<<<<<<<<<<<
            Point pColHeaderQtdCtrl = new Point(pColHeaderQtdChaves.X + sColHeaderQtdChaves.Width + 15, pColHeaderQtdChaves.Y);
            Size sColHeaderQtdCtrl = new Size(50, sColHeaderQtdChaves.Height);
            Rectangle rectQtdHeaderCtrl = new Rectangle(pColHeaderQtdCtrl, sColHeaderQtdCtrl);

            drawer.DrawString("Qtd Ctrls", fontColHeaderQtdChaves, new SolidBrush(Color.Gray), rectQtdHeaderCtrl, formatHeaderQtds);

            //drawer.DrawRectangle(pen, rectQtdHeaderCtrl);


            //>>>>>>>>>>>>>>> Coluna Quant Controles <<<<<<<<<<<<<<<<
            Point pColQtdCtrl = new Point(pColHeaderQtdCtrl.X, pColQtdChaves.Y);
            Size sColQtdCtrl = new Size(sColHeaderQtdCtrl.Width, sColQtdChaves.Height);
            Rectangle rectQtdCtrl = new Rectangle(pColQtdCtrl, sColQtdCtrl);

            drawer.DrawString(qtdControles, fontColChaves, new SolidBrush(Color.Gray), rectQtdCtrl, formatColChaves);

            //drawer.DrawRectangle(pen, rectQtdCtrl);

            //>>>>>>>>>>>>>>>>>>>> FOOTER <<<<<<<<<<<<<<<<<<<
            Point pFooter = new Point(pBase.X, pBase.Y + sBase.Height - 120);
            Size sFooter = new Size(sBase.Width, 120);
            Rectangle rectFooter = new Rectangle(pFooter, sFooter);

            drawer.DrawRectangle(pen, rectFooter);

            //>>>>>>>>>>>>>>>>>>> DIV 1 <<<<<<<<<<<<<<<<<<
            Point pDiv1 = new Point(pFooter.X, pFooter.Y);
            Size sDiv1 = new Size(sFooter.Width / 2, sFooter.Height);
            Rectangle rectDiv1 = new Rectangle(pDiv1, sDiv1);

            drawer.DrawRectangle(pen, rectDiv1);

            picBox.BackgroundImage = img;




        }
    }
}
