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
    public partial class DevolverChave : MetroFramework.Forms.MetroForm
    {
        DateTime dataHoje = DateTime.Now;

        string codigoEmprestimo = "";
        int quantChaves = 0;
        int quantControles = 0;

        PostgreSQL database = new PostgreSQL();

        public DevolverChave(string codEmprestimo)
        {
            InitializeComponent();
            codigoEmprestimo = codEmprestimo;
        }

        private void DevolverChave_Load(object sender, EventArgs e)
        {
            DataTable dadosEmprestimo = new DataTable();

            dadosEmprestimo = database.select(string.Format("SELECT (CASE WHEN e.tipo_doc is null THEN 'NÃO'" +
                                                                " ELSE 'SIM' END) as deixou_doc," +
                                                                " e.quant_chaves, e.quant_controles, c.cod_chave, c.cod_imob," +
                                                                " cl.nome_cliente, e.data_retirada, e.cod_usuario" +
                                                                " FROM emprestimo e" +
                                                                " LEFT JOIN chave c ON c.cod_chave = e.cod_chave" +
                                                                " LEFT JOIN cliente cl ON cl.cod_cliente = e.cod_cliente" +
                                                                " WHERE e.cod_emprestimo = '{0}'", codigoEmprestimo));
        
            foreach(DataRow row in dadosEmprestimo.Rows)
            {
                labelDoc.Text = row[0].ToString();
                quantChaves = int.Parse(row[1].ToString());
                quantControles = int.Parse(row[2].ToString());
                labelCodChave.Text = row[3].ToString();
                labelCodImovel.Text = row[4].ToString();
                labelNome.Text = row[5].ToString();
                labelDataRetirada.Text = row[6].ToString();
                labelFuncionario.Text = row[7].ToString();
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                dataHoje = Convert.ToDateTime(dataHoje.ToString("yyyy-MM-dd HH:mm:ss"));

                DialogResult verificar = DialogResult.Yes;

                if (qtdChaves.Value != quantChaves || qtdControles.Value != quantControles)
                {
                    Message caixMensagem = new Message(string.Format("Há divergências na quantidade de chaves ou de controles." +
                        " Foram retirados:\n - {0} chaves\n - {1} controles\n\nDeseja registrar a devolução mesmo assim?", quantChaves, quantControles),
                        "", "aviso", "escolha");
                    caixMensagem.ShowDialog();
                    verificar = caixMensagem.DialogResult;
                }

                database.update(string.Format("UPDATE emprestimo" +
                                " SET data_entrega = '{0}'" +
                                " WHERE cod_emprestimo = '{1}'", dataHoje, codigoEmprestimo));

                string indiceChave = database.selectScalar(string.Format("SELECT cod_chave FROM emprestimo WHERE cod_emprestimo = '{0}'", codigoEmprestimo));

                database.update(string.Format("UPDATE chave" +
                                " SET situacao = 'DISPONIVEL'" +
                                " WHERE indice_chave = '{0}'", indiceChave));

                FormatarStrings format = new FormatarStrings();

                if (!(boxValor.Text == "" && boxCond.Text == "" && boxFormaLoc.Text == "" && boxOutros.Text == ""))
                {
                    database.insertInto(string.Format("INSERT INTO proposta (valor, condominio, forma_locacao, outros, emprestimo, data)" +
                                                      " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", format.inserirBD(boxValor.Text), format.inserirBD(boxCond.Text),
                                                      format.inserirBD(boxFormaLoc.Text), format.inserirBD(boxOutros.Text), codigoEmprestimo, dataHoje));
                }

                this.DialogResult = DialogResult.OK;

                Message popup = new Message("A chave foi devolvida com sucesso! Por favor, coloque-a no quadro.", "", "sucesso", "confirma");
                popup.ShowDialog();
                this.Close();
            }

            catch (Exception erro)
            {
                Message popup = new Message("Não foi possível realizar a solicitação pelo seguinte erro:\n\n" + erro.Message, "Erro", "erro", "confirma");
                popup.ShowDialog();
            }
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
