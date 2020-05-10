using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace situacaoChavesGolden
{
    public class HeaderChaves : PdfPageEventHelper
    {
        Font FONT = new Font(Font.FontFamily.COURIER, 10, Font.NORMAL);

        public string funcionario { get; set; }
        public string dataRelatorio { get; set; }
        public string sitImovel { get; set; }
        public string finalidade { get; set; }
        public string tipo { get; set; }
        public string sitChave { get; set; }


        public override void OnStartPage(PdfWriter writer, Document document)
        {
            //base.OnStartPage(writer, document);


            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(new Uri(@"C:\Users\Usuario\Dropbox\LOGO.PNG"));



            //Dados Funcionário
            Phrase phFuncionarios = new Phrase("Funcionário: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9,
                iTextSharp.text.Font.BOLD, BaseColor.BLACK));
            Phrase textFuncionarios = new Phrase(funcionario + "     ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9,
                iTextSharp.text.Font.NORMAL, BaseColor.BLACK));

            //Dados da data do relatório
            Phrase phData = new Phrase("Data: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9,
                iTextSharp.text.Font.BOLD, BaseColor.BLACK));
            Phrase textData = new Phrase(dataRelatorio + "     ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9,
               iTextSharp.text.Font.NORMAL, BaseColor.BLACK));

            //Dados da situação da chave
            Phrase phSitChave = new Phrase("Situação do Imóvel: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9,
               iTextSharp.text.Font.BOLD, BaseColor.BLACK));
            Phrase textSitChave = new Phrase(sitImovel + "\n\n\n", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9,
               iTextSharp.text.Font.NORMAL, BaseColor.BLACK));

            //Dados da finalidade do imóvel
            Phrase phFinalidade = new Phrase("Finalidade: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9,
               iTextSharp.text.Font.BOLD, BaseColor.BLACK));
            Phrase textFinalidade = new Phrase(finalidade + "     ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9,
               iTextSharp.text.Font.NORMAL, BaseColor.BLACK));

            //Dados do tipo do imóvel
            Phrase phTipoImovel = new Phrase("Tipo: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9,
               iTextSharp.text.Font.BOLD, BaseColor.BLACK));
            Phrase textTipoImovel = new Phrase(tipo + "     ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9,
               iTextSharp.text.Font.NORMAL, BaseColor.BLACK));

            //Dados da situação do imóvel
            Phrase phSitImovel = new Phrase("Situação da Chave: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9,
               iTextSharp.text.Font.BOLD, BaseColor.BLACK));
            Phrase textSitImovel = new Phrase(sitChave + "     ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9,
               iTextSharp.text.Font.NORMAL, BaseColor.BLACK));

            //ADICIONA FRASES NO PARÁGRAFO
            iTextSharp.text.Paragraph pgFuncionarios = new iTextSharp.text.Paragraph() { phFuncionarios, textFuncionarios, phData, textData, phSitChave, textSitChave,
            phFinalidade, textFinalidade, phTipoImovel, textTipoImovel, phSitImovel, textSitImovel};




            //CRIA TABELA E SETA COLUNAS
            PdfPTable table = new PdfPTable(2);
            table.DefaultCell.BorderColor = new BaseColor(System.Drawing.Color.White);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 1, 3.6f });

            PdfPCell logo = new PdfPCell(img);
            logo.BackgroundColor = BaseColor.WHITE;
            logo.BorderColor = BaseColor.WHITE;

            table.AddCell(logo);

            PdfPCell dados = new PdfPCell(pgFuncionarios);
            dados.BackgroundColor = BaseColor.WHITE;
            dados.BorderColor = BaseColor.WHITE;
            dados.PaddingTop = 5f;
            table.AddCell(dados);


            document.Add(table);

            iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(4, 785, 585, 786);

            rect.BackgroundColor = BaseColor.DARK_GRAY;

            document.Add(rect);

            document.Add(new Paragraph("\n\n"));
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            PdfContentByte canvas = writer.DirectContent;

            iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(4, 20, 585, 21);

            rect.BackgroundColor = BaseColor.DARK_GRAY;

            document.Add(rect);


            ColumnText.ShowTextAligned(
              canvas, Element.ALIGN_CENTER,
              new Phrase(string.Format("Página {0}", document.PageNumber), FONT), PageSize.A4.Width / 2, 10, 0);
        }
    }
}
