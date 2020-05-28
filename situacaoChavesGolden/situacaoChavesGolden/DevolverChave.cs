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

        Dictionary<string, string> dictChaves = new Dictionary<string, string>();
        Dictionary<string, string> dictControles = new Dictionary<string, string>();


        string codigoEmprestimo = "";
        int quantChaves = 0;
        int quantControles = 0;
        string usuario = "";

        PostgreSQL database = new PostgreSQL();

        public DevolverChave(string codEmprestimo, string user)
        {
            InitializeComponent();
            codigoEmprestimo = codEmprestimo;

            usuario = user;
        }

        void atualizarGrid()
        {
            DataTable tabela = new DataTable();

            tabela = database.select(string.Format("SELECT c.cod_imob, c.cod_chave, c.rua || ', ' || c.numero || ' - ' || c.bairro as endereco," +
                                                    " ce.quant_chaves, ce.quant_controles, c.indice_chave, 0, 0, '', '', '', ''" +
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
            gridChaves.Columns[6].Visible = false;
            gridChaves.Columns[7].Visible = false;
            gridChaves.Columns[8].Visible = false;
            gridChaves.Columns[9].Visible = false;
            gridChaves.Columns[10].Visible = false;
            gridChaves.Columns[11].Visible = false;


            gridChaves.Columns[0].HeaderText = "Cód Imob";
            gridChaves.Columns[1].HeaderText = "Cód";
            gridChaves.Columns[2].HeaderText = "Endereço";

            dictChaves.Clear();
            dictControles.Clear();

            foreach(DataRow row in tabela.Rows)
            {
                dictChaves.Add(row[5].ToString(), row[3].ToString());
                dictControles.Add(row[5].ToString(), row[4].ToString());

            }



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
        
        void verificarReserva()
        {
            try
            {
                DataTable tabelaReserva = new DataTable();

                string textoMsg = "Há reserva(s) para a(s) seguinte(s) chaves:\n";

                int cont = 0;
                foreach (DataGridViewRow row in gridChaves.Rows)
                {
                    string reserva = database.selectScalar(string.Format("SELECT COUNT(cr.cod_chave) " +
                                                        " FROM chaves_reserva cr" +
                                                        " INNER JOIN reserva r ON r.cod_reserva = cr.cod_reserva" +
                                                        " WHERE r.situacao != 'FINALIZADO' AND cr.cod_chave = '{0}'" +
                                                        " GROUP BY cr.cod_chave", row.Cells[5].Value.ToString()));

                    textoMsg += string.Format("\n- Chave cód {0}: há {1} reserva(s)", row.Cells[1].Value.ToString(), reserva);
                    cont++;
                }

                if (cont != 0)
                {
                    Message msg = new Message(textoMsg, "Aviso", "aviso", "confirma");
                    msg.ShowDialog();
                }
            }
            catch { }
            
            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int contErros = 0;
            foreach(DataGridViewRow row in gridChaves.Rows)
            {
                
                if(row.Cells[6].Value.ToString() == "0" && row.Cells[7].Value.ToString() == "0")
                {
                    contErros++;
                }
            }

            if(contErros > 0)
            {
                Message msg = new Message("Nem todas as chaves possui quantidade de chaves/controle devolvidos! Preencha-os e tente novamente.",
                    "", "erro", "confirma");
                msg.ShowDialog();
            }

            else
            {
                try
                {

                    string aviso = "Há divergências na quantidade de chaves ou de controles. Verifique abaixo:";


                    int contDivergencia = 0;
                    foreach (DataGridViewRow row in gridChaves.Rows)
                    {
                        if(row.Cells[3].Value.ToString() != row.Cells[6].Value.ToString() || row.Cells[4].Value.ToString() != row.Cells[7].Value.ToString())
                        {
                            contDivergencia++;
                            aviso += string.Format("\n\nCódigo: {0} - Foram devolvidos {1} chave(s) e {2} controle(s). \nForam retirados: {3} chave(s) e {4} controle(s)",
                                row.Cells[1].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString());
                        }

                      
                    }

                    DialogResult verificar = DialogResult.Yes;

                    if (contDivergencia > 0)
                    {
                        Message caixMensagem = new Message(aviso,
                            "", "aviso", "escolha");
                        caixMensagem.ShowDialog();
                        verificar = caixMensagem.DialogResult;
                    }

                    if(verificar == DialogResult.Yes)
                    {
                        FormatarStrings format = new FormatarStrings();

                        foreach (DataGridViewRow row in gridChaves.Rows)
                        {
                            //    string sitChave = database.selectScalar(string.Format("SELECT situacao FROM chave" +
                            //                                                            " WHERE indice_chave = '{0}'",
                            //                                                            row.Cells[5].Value.ToString()));

                            if (row.Cells[1].Value.ToString() != "" && row.Cells[1].Value.ToString() != null)
                            {
                                database.update(string.Format("UPDATE chave" +
                                       " SET situacao = 'DISPONIVEL'" +
                                       " WHERE indice_chave = '{0}'", row.Cells[5].Value.ToString()));
                            }

                            


                            if (!(row.Cells[8].Value.ToString() == "" && row.Cells[9].Value.ToString() == "" && row.Cells[10].Value.ToString() == "" && row.Cells[11].Value.ToString() == ""))
                            {
                                database.insertInto(string.Format("INSERT INTO proposta (cod_chave, valor, condominio, forma_locacao, outros, emprestimo, data)" +
                                                                  " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", row.Cells[5].Value.ToString(), format.inserirBD(row.Cells[8].Value.ToString()), format.inserirBD(row.Cells[9].Value.ToString()),
                                                                  format.inserirBD(row.Cells[10].Value.ToString()), format.inserirBD(row.Cells[11].Value.ToString()), codigoEmprestimo, dataHoje));
                            }
                        }

                        dataHoje = Convert.ToDateTime(dataHoje.ToString("yyyy-MM-dd HH:mm:ss"));


                        //if (qtdChaves.Value != quantChaves || qtdControles.Value != quantControles)
                        //{
                        //    Message caixMensagem = new Message(string.Format("Há divergências na quantidade de chaves ou de controles." +
                        //        " Foram retirados:\n - {0} chaves\n - {1} controles\n\nDeseja registrar a devolução mesmo assim?", quantChaves, quantControles),
                        //        "", "aviso", "escolha");
                        //    caixMensagem.ShowDialog();
                        //    verificar = caixMensagem.DialogResult;
                        //}

                        database.update(string.Format("UPDATE emprestimo" +
                                        " SET data_entrega = '{0}', usuario_devolucao = '{1}'" +
                                        " WHERE cod_emprestimo = '{2}'", dataHoje, usuario, codigoEmprestimo));





                       

                        this.DialogResult = DialogResult.OK;

                        Message popup = new Message("A chave foi devolvida com sucesso! Por favor, coloque-a no quadro.", "", "sucesso", "confirma");
                        popup.ShowDialog();
                        this.Close();

                        verificarReserva();
                    }                 

                   


                }

                catch (Exception erro)
                {
                    Message popup = new Message("Não foi possível realizar a solicitação pelo seguinte erro:\n\n" + erro.Message, "Erro", "erro", "confirma");
                    popup.ShowDialog();
                }
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
            qtdChaves.Value = int.Parse(gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[6].Value.ToString());
            qtdControles.Value = int.Parse(gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[7].Value.ToString());

            boxValor.Text = gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[8].Value.ToString();
            boxCond.Text = gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[9].Value.ToString();
            boxFormaLoc.Text = gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[10].Value.ToString();
            boxOutros.Text = gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[11].Value.ToString();
        }

        private void qtdChaves_ValueChanged(object sender, EventArgs e)
        {
            gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[6].Value = qtdChaves.Value;

        }

        private void qtdControles_ValueChanged(object sender, EventArgs e)
        {
            gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[7].Value = qtdControles.Value;
        }

        private void boxValor_TextChanged(object sender, EventArgs e)
        {
            gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[8].Value = boxValor.Text.Trim();
            
        }

        private void boxCond_TextChanged(object sender, EventArgs e)
        {
            gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[9].Value = boxCond.Text.Trim();
            
        }

        private void boxFormaLoc_TextChanged(object sender, EventArgs e)
        {
            gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[10].Value = boxFormaLoc.Text.Trim();
           
        }

        private void boxOutros_TextChanged(object sender, EventArgs e)
        {
            gridChaves.Rows[gridChaves.CurrentRow.Index].Cells[11].Value = boxOutros.Text.Trim();
        }
    }
}
