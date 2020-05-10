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
    public partial class ConfigurarRelatorioChaves : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();
        string funcionario = "";
        public ConfigurarRelatorioChaves(string user)
        {
            InitializeComponent();
            funcionario = user;
        }

        private void ConfigurarRelatorioChaves_Load(object sender, EventArgs e)
        {
            funcionario = database.selectScalar(string.Format("SELECT nome_usuario FROM usuario WHERE cod_usuario = '{0}'", funcionario));
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string sitImovel = groupBoxSituacaoIm.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string sitChave = groupBoxSituacaoCh.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string tipoImovel = groupBoxTipoImovel.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string finalidade = groupBoxFinalidade.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string ordenar = groupBoxOrdenar.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string funcionario = this.funcionario;

            if (sitImovel == "TODOS") { sitImovel = ""; }
            if (sitChave == "TODOS") { sitChave = ""; }
            if (tipoImovel == "TODOS") { tipoImovel = ""; }
            if (finalidade == "TODOS") { finalidade = ""; }
            if (ordenar == "COD CHAVE")
            { 
                ordenar = "c.cod_chave"; 
            }
            else if (ordenar == "ENDEREÇO")
            {
                ordenar = "c.rua";
            }
            else if(ordenar == "COD IMOB")
            {
                ordenar = "c.cod_imob";
            }

            GerarRelatorio relatorio = new GerarRelatorio();


            relatorio.sitImovel = sitImovel;
            relatorio.sitChave = sitChave;
            relatorio.tipo = tipoImovel;
            relatorio.finalidade = finalidade;
            relatorio.ordenar = ordenar;
            relatorio.funcionario = funcionario;

            relatorio.chaves();
        }
    }
}
