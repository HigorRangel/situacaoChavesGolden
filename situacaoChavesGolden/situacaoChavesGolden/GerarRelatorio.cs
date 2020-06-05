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
using System.Diagnostics;

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
        public List<string> listProp  { get; set; }

        
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

        private DataTable buscarDadosChaves()
        {
            DataTable tabelaDados = new DataTable();

            tabelaDados.Clear();


            string proprietarios = "";

            int cont = 0;
            foreach(string str in listProp)
            {
                if(cont == 0)
                {
                    proprietarios += " AND (";
                }

                proprietarios += string.Format("p.cod_proprietario = '{0}'", str);

                if(cont != str.Length + 1)
                {
                    proprietarios += " OR ";
                }
                if(cont == str.Length + 1)
                {
                    proprietarios += ")";

                }

                cont++;
            }


            //string ordenacao = "";
            //if(ordenar == "Endereço") { ordenacao = "c.rua"; }
            //else if(ordenar == "Cod Chave") { ordenacao = "c.cod_chave"; }
            //else if(ordenar == "Cod Imob") { ordenacao = "c.cod_imob"; }

            tabelaDados = database.select(string.Format("" +
                                            "SELECT c.cod_chave, c.cod_imob, c.rua || ', ' || c.numero || " +
                                                " (CASE WHEN c.complemento is null OR  c.complemento = '' THEN '' ELSE ' - ' || c.complemento END) ||" +
                                                " (CASE WHEN c.cond is null OR c.cond = '' THEN '' ELSE ' - ' || c.cond END) || ' - ' || c.bairro as endereco, " +
                                                " (CASE WHEN c.tipo_imovel = 'RESIDENCIAL' THEN 'RES' ELSE 'COM' END), " +
                                                " (CASE WHEN c.finalidade = 'LOCAÇÃO' THEN 'LOC' ELSE 'VENDA' END), " +
                                                " (CASE WHEN c.situacao = 'DISPONIVEL' THEN 'SIM' ELSE 'NÃO' END), " +
                                                " (SELECT MAX(e.cod_emprestimo) " +
                                                "       FROM emprestimo e" +
                                                "       INNER JOIN chaves_emprestimo ce ON ce.cod_emprestimo = e.cod_emprestimo" +
                                                "       WHERE data_entrega is null AND ce.cod_chave = c.indice_chave) " +
                                                " FROM chave c " +
                                                " LEFT JOIN chaves_emprestimo ce ON c.indice_chave = ce.cod_chave" +
                                                " LEFT JOIN emprestimo e ON e.cod_emprestimo = ce.cod_emprestimo " +
                                                " INNER JOIN proprietario p ON c.proprietario = p.cod_proprietario" +
                                                " WHERE c.situacao ILIKE '{0}%' AND c.tipo_imovel ILIKE '%{1}%' " +
                                                " AND c.finalidade ILIKE '%{2}%' AND c.situacao_imovel ILIKE '{3}%' {4}" +
                                                " GROUP BY c.indice_chave " +
                                                " ORDER BY {5} " +
                                                " ", sitChave, tipo, finalidade, sitImovel, proprietarios, ordenar));

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

            tabela.SetWidths(new float[] { 1,2, 8,1,1,1,1 });


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

           
            bool colorir = false;

            for (int i = 0; i < tabelaDados.Rows.Count + 30; i++)
            {
                try
                {
                    for (int j = 0; j < tabelaDados.Columns.Count; j++)
                    {
                        iTextSharp.text.Font fonte = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, 0, new BaseColor(Color.White));

                        if (tabelaDados.Rows[i][tabelaDados.Columns.Count - 1].ToString() != null &&
                            tabelaDados.Rows[i][tabelaDados.Columns.Count - 1].ToString() != "")
                        {
                            fonte.Color = new BaseColor(Color.White);
                        }
                        else
                        {
                            fonte.Color = new BaseColor(Color.Black);

                        }

                        Phrase frase = new Phrase(tabelaDados.Rows[i][j].ToString(), fonte);

                        PdfPCell dado = new PdfPCell(frase);
                        //if (colorir == true) { dado.BackgroundColor = new BaseColor(Color.FromArgb(237, 237, 237)); }
                        //else { dado.BackgroundColor = new BaseColor(Color.White); }
                        dado.BorderColor = BaseColor.GRAY;
                        dado.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                        if (i % 2 == 0)
                        {
                            dado.BackgroundColor = new BaseColor(Color.FromArgb(196, 196, 196));
                        }
                        else
                        {
                            dado.BackgroundColor = new BaseColor(Color.White);
                        }

                        if (tabelaDados.Rows[i][tabelaDados.Columns.Count-1].ToString() != null &&
                            tabelaDados.Rows[i][tabelaDados.Columns.Count-1].ToString() != "")
                        {
                            dado.BackgroundColor = new BaseColor(Color.FromArgb(87, 87, 87));
                            //dado.font
                        }




                        tabela.AddCell(dado);
                    }

                }
                catch
                {
                    doc.Add(tabela);
                    break;
                }
            }
            




            //int contador = 1;

            //for (int i = 0; i < tabelaDados.Rows.Count + 30; i++)
            //{

            //    try
            //    {
            //        bool colorir = false;

            //        for (int j = 0; j < tabelaDados.Columns.Count; j++)
            //        {
            //            if(i % 2  == 0)
            //            {
            //                colorir = true;
            //            }

            //            PdfPCell dado = new PdfPCell(new Phrase(tabelaDados.Rows[i][j].ToString() + "\n", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10)));
            //            if(colorir == true) { dado.BackgroundColor = new BaseColor(Color.FromArgb(237, 237, 237)); }
            //            else { dado.BackgroundColor = new BaseColor(Color.White); }
            //            dado.BorderColor = BaseColor.GRAY;
            //            dado.HorizontalAlignment = PdfPCell.ALIGN_CENTER;


            //            tabela.AddCell(dado);
            //        }
            //        //colorir = true;

            //        if (contador % 40 == 0 && contador != 0)
            //        {
            //            //MessageBox.Show(contador.ToString());
            //            doc.Add(tabela);
            //            doc.NewPage();
            //            tabela.DeleteBodyRows();
            //        }
            //        contador++;
            //    }
            //    catch
            //    {
            //        doc.Add(tabela);
            //        break;

            //    }



            //}

        }

        
        public void chaves()
        {
            string caminho = Environment.CurrentDirectory + @"\temp\relatorio-" +
                DateTime.Now.ToString("yyyy-MM-dd hh.mm.ss") + ".pdf";

            Document doc = new Document(PageSize.A4, 5, 5, 5, 40);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            
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

            iTextSharp.text.Paragraph pgTitulo = new iTextSharp.text.Paragraph("RELATÓRIO DE CHAVES\n\n", fontTitulo);
            pgTitulo.Alignment = 1;
            doc.Add(pgTitulo);

            gerarTabela(buscarDadosChaves(), doc);

            doc.Close();

            showDocument(caminho);

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
