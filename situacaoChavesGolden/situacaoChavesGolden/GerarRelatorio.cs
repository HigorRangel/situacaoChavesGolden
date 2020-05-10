using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace situacaoChavesGolden
{
    class GerarRelatorio
    {
        PostgreSQL database = new PostgreSQL();

        public string funcionario { get; set; }
        public string dataRelatorio { get; set; }
        public string sitImovel { get; set; }
        public string finalidade { get; set; }
        public string tipo { get; set; }
        public string sitChave { get; set; }
        public string ordenar { get; set; }

        

        private DataTable buscarDadosChaves()
        {
            DataTable tabelaDados = new DataTable();

            tabelaDados.Clear();

            //string ordenacao = "";
            //if(ordenar == "Endereço") { ordenacao = "c.rua"; }
            //else if(ordenar == "Cod Chave") { ordenacao = "c.cod_chave"; }
            //else if(ordenar == "Cod Imob") { ordenacao = "c.cod_imob"; }

            tabelaDados = database.select(string.Format("" +
                                            "SELECT c.cod_chave, c.cod_imob, c.rua || ', ' || c.numero || " +
                                                " (CASE WHEN c.complemento is null OR  c.complemento = '' THEN '' ELSE ' - ' || c.complemento END) || ' - ' || c.bairro as endereco, " +
                                                " (CASE WHEN c.tipo_imovel = 'RESIDENCIAL' THEN 'RES' ELSE 'COM' END), " +
                                                " (CASE WHEN c.finalidade = 'LOCAÇÃO' THEN 'LOC' ELSE 'VENDA' END), " +
                                                " (CASE WHEN c.situacao = 'DISPONIVEL' THEN 'SIM' ELSE 'NÃO' END), " +
                                                " (SELECT MAX(cod_emprestimo) FROM emprestimo WHERE data_entrega is null AND cod_chave = c.indice_chave) " +
                                                " FROM chave c " +
                                                " LEFT JOIN emprestimo e ON e.cod_chave = c.indice_chave " +
                                                " WHERE c.situacao ILIKE '{0}%' AND c.tipo_imovel ILIKE '%{1}%' " +
                                                " AND c.finalidade ILIKE '%{2}%' AND c.situacao_imovel ILIKE '{3}%' " +
                                                " GROUP BY c.indice_chave " +
                                                " ORDER BY {4} " +
                                                " ", sitChave, tipo, finalidade, sitImovel, ordenar));

            return tabelaDados;
        }

        private void gerarTabela(DataTable tabelaDados, Document doc)
        {
            PdfPTable tabela = new PdfPTable(tabelaDados.Columns.Count);
            tabela.PaddingTop = 50;
            tabela.WidthPercentage = 100;
                       
            

            float[] widths = new float[tabelaDados.Columns.Count];


            int contadorCol = 0;
            //foreach(ColumnStyle column in tabelaDados.Columns)
            //{
            //    widths[contadorCol] = column.Width;
            //}

            tabela.SetWidths(new float[] { 1,2, 7,1,1,1,1 });


            PdfPCell header = new PdfPCell();
            header.BackgroundColor = BaseColor.GRAY;
            header.BorderColor = BaseColor.WHITE;
            header.Phrase = new Phrase("Cód", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, 0, BaseColor.WHITE)) ;
            header.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            tabela.AddCell(header);

            header.Phrase = new Phrase("Cód Imob", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, 0, BaseColor.WHITE));
            tabela.AddCell(header);

            header.Phrase = new Phrase("Endereço", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, 0, BaseColor.WHITE));
            tabela.AddCell(header);

            header.Phrase = new Phrase("Tipo", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, 0, BaseColor.WHITE));
            tabela.AddCell(header);

            header.Phrase = new Phrase("Fin", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, 0, BaseColor.WHITE));
            tabela.AddCell(header);

            header.Phrase = new Phrase("Disp?", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, 0, BaseColor.WHITE));
            tabela.AddCell(header);

            header.Phrase = new Phrase("Emp", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, 0, BaseColor.WHITE));
            tabela.AddCell(header);



            int contador = 1;
            
            foreach (DataRow row in tabelaDados.Rows)
            {
                
                for (int i = 0; i < tabelaDados.Columns.Count; i++)
                {
                             
                    PdfPCell dado = new PdfPCell(new Phrase(row[i].ToString() + "\n\n", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10)));
                    dado.BackgroundColor = BaseColor.WHITE;
                    dado.BorderColor = BaseColor.GRAY;
                    dado.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    

                    tabela.AddCell(dado); 
                }

                if (contador % 30 == 0 && contador != 0)
                {
                    //MessageBox.Show(contador.ToString());
                    doc.NewPage();
                    doc.Add(tabela);
                    tabela.DeleteBodyRows();
                }

                contador++;
            }
            




        }
        public void chaves()
        {
            Document doc = new Document(PageSize.A4, 5, 5, 5, 0);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(Environment.CurrentDirectory + @"\arquivo.pdf", FileMode.Create));

            
            HeaderChaves pdf = new HeaderChaves();
            pdf.funcionario = funcionario;
            pdf.dataRelatorio = DateTime.Now.ToString();
            pdf.sitImovel = (sitImovel == "") ? "TODOS" : sitImovel;
            pdf.finalidade = (finalidade == "") ? "TODOS" : finalidade;
            pdf.tipo = (tipo == "") ? "TODOS" : tipo;
            pdf.sitChave = (sitChave == "") ? "TODOS" : sitChave;

            writer.PageEvent = pdf;

            doc.Open();

          
            iTextSharp.text.Font fontTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 12,
               iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            iTextSharp.text.Paragraph pgTitulo = new iTextSharp.text.Paragraph("RELATÓRIO DE CHAVES\n", fontTitulo);
            pgTitulo.Alignment = 1;
            doc.Add(pgTitulo);

            gerarTabela(buscarDadosChaves(), doc);



          

            doc.Close();


            doc.Dispose();  
            

            //pgFuncionarios.SetLeading(0, 0);

            // doc.Add(pgFuncionarios);
            //doc.Add(img);
            //doc.Add(phFuncionarios);
            ////doc.Add(rect);
            //doc.Close();
        }
    }
}
