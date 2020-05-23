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

            DataTable tabela = new DataTable();
            tabela = buscarDadosEmprestimo(codigo);

            DateTime dateRet = new DateTime();
            string dataRetirada = "";
            string funcionario = "";
            string cliente = "";
            string cpfCliente = "";
            string docCliente = "";
            string enderecoCliente = "";

            foreach(DataRow row in tabela.Rows)
            {
                dateRet = (DateTime)row[0];
                dataRetirada = dateRet.ToString("dd/MM/yyyy hh:mm:ss");
                funcionario = row[1].ToString();
                cliente = row[2].ToString();
                cpfCliente = row[3].ToString();
                docCliente = row[4].ToString();
                enderecoCliente = row[5].ToString();
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
            Size sHeader = new Size(sBase.Width, usarMetodo.cmToPixel(2));
            Rectangle rectHeader = new Rectangle(pHeader, sHeader);

            drawer.DrawRectangle(pen, rectHeader);

            //>>>>>>>>>>>> RETANGULO LOGO <<<<<<<<<<<<<<<<<<<<<<<<
            Point pLogo = new Point(pHeader.X + 6, pHeader.Y + 5);
            Size sLogo = new Size(usarMetodo.cmToPixel(4), sHeader.Height - 11);
            Rectangle rectLogo = new Rectangle(pLogo, sLogo);

            //drawer.DrawRectangle(pen, rectLogo);
            drawer.DrawImage(Properties.Resources.logoSbernardo, rectLogo);

            //>>>>>>>>>>>>>>> RETANGULO TEXTO HEADER  1 <<<<<<<<<<<<<<<<
            Point pTextHeader1 = new Point(pLogo.X + sLogo.Width + 9, pLogo.Y);
            Size sTextHeader1 = new Size(sHeader.Width - sLogo.Width - 250, sLogo.Height);
            Rectangle rectTextHeader1 = new Rectangle(pTextHeader1, sTextHeader1);

            //>>>>>>>>>>>>>> Texto Header <<<<<<<<<<<<<<
            Font fonteHeader1 = new Font("Consolas", 8.5f, FontStyle.Bold);
            string textoHeader1 = "IMOBILIÁRIA SÃO BERNARDO LTDA\n\n" +
                                  "Rua Fernando Camargo, 587 - Centro - Americana/SP\n\n" +
                                  "(19) 3406-2423 / (19) 9 9110-8041";
            StringFormat formatTxtHeader = new StringFormat();
            formatTxtHeader.LineAlignment = StringAlignment.Center;

            drawer.DrawString(textoHeader1, fonteHeader1, new SolidBrush(Color.Black), rectTextHeader1, formatTxtHeader);

            //drawer.DrawRectangle(pen, rectTextHeader1);

            //>>>>>>>>>>>>>>> RETANGULO TEXTO HEADER 2 <<<<<<<<<<<<<<<<
            Point pTextHeader2 = new Point(pTextHeader1.X + sTextHeader1.Width + 5, pTextHeader1.Y);
            Size sTextHeader2 = new Size(sHeader.Width - (sLogo.Width + sTextHeader1.Width) - 25, sTextHeader1.Height);
            Rectangle rectTextHeader2 = new Rectangle(pTextHeader2, sTextHeader2);

            //>>>>>>>>>>>>>>>>> Divisória <<<<<<<<<<<<<<<<<<<<


            drawer.DrawLine(pen, pTextHeader1.X + sTextHeader1.Width + 5, pTextHeader1.Y + 8, pTextHeader1.X + sTextHeader1.Width + 5,
                                 pTextHeader1.Y + sTextHeader1.Height - 8);

            //>>>>>>>>>>>>>> Texto Header 2<<<<<<<<<<<<<<
            Font fonteHeader2 = new Font("Consolas", 8, FontStyle.Bold);
            string textoHeader2 = string.Format("Funcionário(a): {0}\n\n\n" +
                                  "Gerado em: {1}", funcionario, dataRetirada);
            StringFormat formatTxtHeader2 = new StringFormat();
            formatTxtHeader2.LineAlignment = StringAlignment.Center;
            formatTxtHeader2.Alignment = StringAlignment.Far;

            drawer.DrawString(textoHeader2, fonteHeader2, new SolidBrush(Color.Black), rectTextHeader2, formatTxtHeader2);

            //drawer.DrawRectangle(pen, rectTextHeader2);

            //>>>>>>>>>>>>>>>>>>> Título <<<<<<<<<<<<<<<<<<
            Point pTitulo = new Point(pHeader.X, pHeader.Y + sHeader.Height);
            Size sTitulo = new Size(sHeader.Width, usarMetodo.cmToPixel(0.8));
            Rectangle rectTitulo = new Rectangle(pTitulo, sTitulo);

            //drawer.DrawRectangle(pen, rectTitulo);

            Font fonteTitulo = new Font("Consolas", 11, FontStyle.Bold);
            string titulo = string.Format("RECIBO DE EMPRÉSTIMO DE CHAVES ({0})", codigo);
            StringFormat formatTitulo = new StringFormat();
            formatTitulo.LineAlignment = StringAlignment.Center;
            formatTitulo.Alignment = StringAlignment.Center;

            drawer.DrawString(titulo, fonteTitulo, new SolidBrush(Color.Black), rectTitulo, formatTitulo);



            //>>>>>>>>>>>>>>>>>>>>> Header Coluna Nome <<<<<<<<<<<<<<<<<<<<<<<<<<
            Point pColHeaderCodigos = new Point(pHeader.X + 13, pTitulo.Y + sTitulo.Height + 10);
            Size sColHeaderCodigos = new Size(48, usarMetodo.cmToPixel(0.5));
            Rectangle rectColHeaderCodigos = new Rectangle(pColHeaderCodigos, sColHeaderCodigos);

            drawer.DrawRectangle(pen, rectColHeaderCodigos);

            //>>>>>>>>>>>>>>>>>>>>> Coluna códigos <<<<<<<<<<<<<<<<<<<<<<<<<<
            Point pColCodigos = new Point(pColHeaderCodigos.X, pColHeaderCodigos.Y + sColHeaderCodigos.Height + 10);
            Size sColCodigos = new Size(42, 315);
            Rectangle rectColCodigos = new Rectangle(pColCodigos, sColCodigos);

            drawer.DrawRectangle(pen, rectColCodigos);

            Font fontColChaves = new Font("Consolas", 11, FontStyle.Regular);
            Font fontColHeaderChaves = new Font("Consolas", 11, FontStyle.Bold);
            StringFormat formatColChaves = new StringFormat();
            formatColChaves.LineAlignment = StringAlignment.Center;
            formatColChaves.Alignment = StringAlignment.Center;

            drawer.DrawString("Chave", fontColHeaderChaves, new SolidBrush(Color.Gray), rectColHeaderCodigos, formatColChaves);
            drawer.DrawString("\n10\n\n5\n\n6\n\n8\n\n26\n\n78\n\n" +
                                    "123\n\n21\n\n123\n\n1", fontColChaves, new SolidBrush(Color.Gray), rectColCodigos, formatColChaves);


            //>>>>>>>>>>>>>>>>>>>> Header Coluna Endereço <<<<<<<<<<<<<<<<
            //>>>>>>>>>>>>>>>>>>>> Coluna endereço <<<<<<<<<<<<<<<<<<
            Point pColEndereco = new Point(pColCodigos)

            picBox.BackgroundImage = img;



        }
    }
}
