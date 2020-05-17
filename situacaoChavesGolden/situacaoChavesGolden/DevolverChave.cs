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

        void atualizarGrid()
        {
            DataTable tabela = new DataTable();

            tabela = database.select(string.Format("SELECT c.cod_imob, ce.cod_chave, c.rua || ', ' || c.numero || ' - ' || c.bairro as endereco," +
                                                    " ce.quant_chaves, ce.quant_controles, c.indice_chave" +
                                                    " FROM chaves_emprestimo ce" +
                                                    " INNER JOIN chave c ON c.indice_chave = ce.cod_chave" +
                                                    " WHERE cod_emprestimo = '{0}'", codigoEmprestimo));

            gridChaves.DataSource = tabela;

            gridChaves.Columns[0].Width = 80;
            gridChaves.Columns[1].Width = 40;
            gridChaves.Columns[2].Width = 265;
            gridChaves.Columns[3].Visible = false;
            gridChaves.Columns[4].Visible = false;
            gridChaves.Columns[5].Visible = false;

            gridChaves.Columns[0].HeaderText = "Cód Imob";
            gridChaves.Columns[1].HeaderText = "Cód";
            gridChaves.Columns[2].HeaderText = "Endereço";



        }

        private void DevolverChave_Load(object sender, EventArgs e)
        {
            DataTable dadosEmprestimo = new DataTable();
            atualizarGrid();

            dadosEmprestimo = database.select(string.Format("SELECT (CASE WHEN e.tipo_doc is null OR e.tipo_doc = '' THEN 'NÃO' " +
                                                                " ELSE 'SIM' END) as deixou_doc, " +
                                                                " e.data_retirada, u.nome_usuario, " +
                                                                " CASE WHEN" +
                                                                    " (CASE WHEN e.cod_proprietario is null AND e.cod_cliente is null THEN 'FUNCIONARIO'" +
                                                                          "  WHEN e.cod_proprietario is null AND e.cod_cliente is not null THEN 'CLIENTE'" +
                                                                          "  WHEN e.cod_proprietario is not null AND e.cod_cliente is null THEN 'PROPRIETARIO' END) = 'FUNCIONARIO'" +
                                                                          "  THEN(SELECT nome_usuario FROM usuario WHERE cod_usuario = e.cod_usuario)" +
                                                                    " WHEN" +
                                                                    " (CASE WHEN e.cod_proprietario is null AND e.cod_cliente is null THEN 'FUNCIONARIO'" +
                                                                           " WHEN e.cod_proprietario is null AND e.cod_cliente is not null THEN 'CLIENTE'" +
                                                                           " WHEN e.cod_proprietario is not null AND e.cod_cliente is null THEN 'PROPRIETARIO' END) = 'CLIENTE'" +
                                                                               " THEN(select nome_cliente FROM cliente WHERE cod_cliente = e.cod_cliente)" +

                                                                    " ELSE(SELECT nome FROM proprietario WHERE cod_proprietario = e.cod_proprietario) END" +
                                                                    " FROM emprestimo e" +
                                                                    " LEFT JOIN usuario u ON e.cod_usuario = u.cod_usuario" +
                                                                    " LEFT JOIN cliente cl ON cl.cod_cliente = e.cod_cliente" +
                                                                    " WHERE e.cod_emprestimo = '{0}'", codigoEmprestimo));
        
            foreach(DataRow row in dadosEmprestimo.Rows)
            {
                labelDoc.Text = row[0].ToString();
                labelDataRetirada.Text = row[1].ToString();
                //labelCodChave.Text = row[3].ToString();
                //labelCodImovel.Text = row[4].ToString();
                labelNome.Text = row[3].ToString();
                labelFuncionario.Text = row[2].ToString();
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

        private void GridChaves_SelectionChanged(object sender, EventArgs e)
        {
            qtdChaves.Value = int.Parse(gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[3].Value.ToString());
            qtdControles.Value = int.Parse(gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[4].Value.ToString());

        }
    }
}
