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

        DataTable tabelaDados = new DataTable();

        private void buscarDados()
        {
            tabelaDados.Clear();

            string ordenacao = "";
            if(ordenar == "Endereço") { ordenacao = "c.rua"; }
            else if(ordenar == "Cod Chave") { ordenacao = "c.cod_chave"; }
            else if(ordenar == "Cod Imob") { ordenacao = "c.cod_imob"; }

            tabelaDados = database.select(string.Format("" +
                                            "SELECT c.cod_chave, c.cod_imob, c.rua || ', ' || c.numero || (CASE WHEN c.complemento is null OR " +
                                            " c.complemento = '' THEN '' ELSE ' - ' || c.complemento END) || ' - ' || c.bairro as endereco, " +
                                            " (CASE WHEN c.tipo_imovel = 'RESIDENCIAL' THEN 'RES' ELSE 'COM' END), " +
                                            " (CASE WHEN c.finalidade = 'LOCAÇÃO' THEN 'LOC' ELSE 'VENDA' END), " +
                                            " (CASE WHEN c.situacao = 'DISPONIVEL' THEN 'SIM' ELSE 'NÃO' END), " +
                                            " e.cod_emprestimo " +
                                    " FROM chave c " +
                                    " LEFT JOIN emprestimo e ON e.cod_chave = c.indice_chave " +
                                    " WHERE e.data_entrega is null AND c.situacao ILIKE '{0}%' AND c.tipo_imovel ILIKE '%{1}%' " +
                                    " AND c.finalidade ILIKE '%{2}%' AND c.situacao_imovel ILIKE '{3}%' " +
                                    " ORDER BY {4}", sitChave, tipo, finalidade, sitImovel, ordenacao));
        }
        public void chaves()
        {
            Document doc = new Document(PageSize.A4, 5, 5, 5, 0);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(Environment.CurrentDirectory + @"\arquivo.pdf", FileMode.Create));

            
            HeaderChaves pdf = new HeaderChaves();
            pdf.funcionario = funcionario;
            pdf.dataRelatorio = dataRelatorio;
            pdf.sitImovel = sitImovel;
            pdf.finalidade = finalidade;
            pdf.tipo = tipo;
            pdf.sitChave = sitChave;

            doc.Open();


            iTextSharp.text.Font fontTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 12,
               iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            iTextSharp.text.Paragraph pgTitulo = new iTextSharp.text.Paragraph("\nRELATÓRIO DE CHAVES", fontTitulo);
            pgTitulo.Alignment = 1;
            doc.Add(pgTitulo);



            pdf.OnEndPage(writer, doc);




            doc.Close();


            //pgFuncionarios.SetLeading(0, 0);

            // doc.Add(pgFuncionarios);
            //doc.Add(img);
            //doc.Add(phFuncionarios);
            ////doc.Add(rect);
            //doc.Close();
        }
    }
}
