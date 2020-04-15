using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace situacaoChavesGolden
{
    public partial class RetirarChave : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();
        DateTime dataHora = DateTime.Now;

        string codigoChave = "";

        public RetirarChave(string codChave)
        {
            InitializeComponent();

            codigoChave = codChave;
        }

        private void RetirarChave_Load(object sender, EventArgs e)
        {

        }

        private void MetroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            int contErros = 0;
            string texto = "Não foi possível cadastrar a retirada. Verifique os campos abaixo e tente novamente.\n\n";
            string tipoRetirada = groupTipo.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text;

            if(tipoRetirada == "Proprietário (a)")
            {
                tipoRetirada = "PROPRIETARIO";
            }

            else if (tipoRetirada == "Funcionário (a)")
            {
                tipoRetirada = "FUNCIONARIO";
            }
            else
            {
                tipoRetirada = "OUTRO";
            }


            if (quemRetirouBox.Text.Length == 0)
            {
                contErros++;
                texto += "- Quem retirou (Preenchimento obrigatório)";
            }

            if(descricaoBox.Text.Length == 0)
            {
                contErros++;
                texto += "- Descrição/motivo (Preenchimento obrigatório)";
            }

            string dataAgora = dataHora.ToString("yyyy-MM-dd H:mm:ss");

            if(contErros == 0)
            {
                database.insertInto(string.Format("INSERT INTO retirado (cod_chave, tipo_retirada, quem_retirou, descricao, data_retirada)" +
                                                    " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", codigoChave, tipoRetirada, quemRetirouBox.Text, 
                                                    descricaoBox, dataAgora));
            }
            else
            {
                Message boxMsg = new Message(texto, "Erro ao cadastrar", "erro", "confirma");
                boxMsg.ShowDialog();
            }
        }
    }
}
