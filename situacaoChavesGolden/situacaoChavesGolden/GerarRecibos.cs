using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Diagnostics;

namespace situacaoChavesGolden
{
    class GerarRecibos
    {
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

        public void reciboEmprestimo()
        {
            string caminho = Environment.CurrentDirectory + @"\temp\recibo-" +
                DateTime.Now.ToString("yyyy-MM-dd hh.mm.ss") + ".pdf";


            Document doc = new Document(PageSize.A4, 5, 5, 5, 0);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            //Rectangle rectBase = new Rectangle(10, 785, 585, 830);
            //rectBase.Border = Rectangle.BOX;
            //rectBase.BorderWidth = 2;
            //rectBase.BorderColor = BaseColor.DARK_GRAY;

            //doc.Add(rectBase);

            PdfPTable tableBaseHeader = new PdfPTable(2);
            tableBaseHeader.WidthPercentage = 100;
            tableBaseHeader.SetWidths(new float[] { 1, 3.6f });
            tableBaseHeader.DefaultCell.BorderColorBottom = BaseColor.BLACK;

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.LogoRelatorio, BaseColor.WHITE, false);


            PdfPCell logo = new PdfPCell(img);
            logo.BackgroundColor = BaseColor.WHITE;
            logo.BorderColor = BaseColor.WHITE;

            tableBaseHeader.AddCell(logo);

            doc.Add(tableBaseHeader);
            doc.Add(new Paragraph("oi"));
            doc.Close();

            showDocument(caminho);
        }
    }
}
