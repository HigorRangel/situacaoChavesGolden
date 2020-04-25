﻿using System;
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
    public partial class Emprestimo : MetroFramework.Forms.MetroForm
    {

        DateTime dataHoje = DateTime.Now;
        PostgreSQL database = new PostgreSQL();
        public Emprestimo()
        {
            InitializeComponent();
        }

        private void atualizarGridEmprestimo()
        {
            //try
            //{
                DataTable dadosEmprestimo = new DataTable();

                string situacao = groupMenuSup.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
                string tipo = groupTipoEmprestimo.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
                string dataRetirada = string.Format(" AND data_Retirada BETWEEN '{0}' AND '{1}'", dpMinDataRetirada.Value, dpMaxDataRetirada.Value);
                string entregaPrevista = string.Format(" AND entrega_prevista BETWEEN '{0}' AND '{1}'  ", dpMinPrevisEntrega.Value, dpMaxPrevisEntrega.Value);
                string dataEntrega = string.Format(" AND data_entrega BETWEEN '{0}' AND '{1}' ", dpMinDataEntrega.Value, dpMaxDataEntrega.Value);
                string busca = textBoxBusca.Text;

                if(!checkDataRetirada.Checked) { dataRetirada = ""; }
                if(!checkPrevisEntrega.Checked) { entregaPrevista = ""; }
                if(!checkDataEntrega.Checked) { dataEntrega = ""; }

                if (situacao == "TODOS") { situacao = ""; }
                if (tipo == "TODOS") { tipo = ""; }

                if(busca == "Buscar") { busca = ""; }

                dadosEmprestimo = database.select(string.Format("SELECT e.cod_emprestimo, c.cod_chave, c.rua || ', ' || c.numero || ' - ' || c.bairro as endereco," +
                                                  "  e.data_retirada, e.entrega_prevista, " +
                                                  " (CASE WHEN e.data_entrega is null THEN 'EM ANDAMENTO' ELSE 'FINALIZADO' END) as situacao " +
                                                  " FROM emprestimo e " +
                                                  " LEFT JOIN chave c on c.indice_chave = e.cod_chave " +
                                                  " LEFT JOIN cliente cl ON cl.cod_cliente = e.cod_cliente " +
                                                  " LEFT JOIN usuario u ON u.cod_usuario = e.cod_usuario " +
                                                  " LEFT JOIN proprietario p ON p.cod_proprietario = e.cod_proprietario " +
                                                  " WHERE " +
                                                        " ((CASE WHEN e.data_entrega is null THEN 'EM ANDAMENTO' ELSE 'FINALIZADO' END) ILIKE '%{0}%' " +
                                                        "  AND (CASE WHEN e.cod_proprietario is null AND e.cod_cliente is null THEN 'FUNCIONARIO' " +
                                                            " WHEN e.cod_proprietario is null AND e.cod_cliente is not null THEN 'CLIENTE' " +
                                                            " WHEN e.cod_proprietario is not null AND e.cod_cliente is null THEN 'PROPRIETARIO' END) ILIKE '%{1}%'" +
                                                            " {2} " +
                                                            " {3} " +
                                                            " {4} ) " +
                                                         " AND (cl.nome_cliente ILIKE '%{5}%' OR e.descricao ILIKE '%{5}%' OR " +
                                                         " c.rua ILIKE '%{5}%' OR u.nome_usuario ILIKE '%{5}%' OR  p.nome  ILIKE '%{5}%')", 
                                                         situacao, tipo,  dataRetirada, entregaPrevista, dataRetirada, busca));

                gridEmprestimo.DataSource = dadosEmprestimo;

                gridEmprestimo.Columns[0].HeaderText = "Código";        
                gridEmprestimo.Columns[1].HeaderText = "Chave";
                gridEmprestimo.Columns[2].HeaderText = "Endereço";
                gridEmprestimo.Columns[3].HeaderText = "Data retirada";
                gridEmprestimo.Columns[4].HeaderText = "Previsão de entrega";
                gridEmprestimo.Columns[5].HeaderText = "Situação";

                gridEmprestimo.Columns[0].Width = 40;
                gridEmprestimo.Columns[1].Width = 40;
                gridEmprestimo.Columns[2].Width = 234;
                gridEmprestimo.Columns[3].Width = 98;
                gridEmprestimo.Columns[4].Width = 98;
                gridEmprestimo.Columns[5].Width = 98;
            //}
            //catch (Exception erro)
            //{
            //    MessageBox.Show(erro.Message);
            //}
        }

        private void Emprestimo_Load(object sender, EventArgs e)
        {
            atualizarGridEmprestimo();


            dpMinDataRetirada.Value = dataHoje.AddMonths(-3);
            dpMinPrevisEntrega.Value = dataHoje.AddMonths(-3);
            dpMinDataEntrega.Value = dataHoje.AddMonths(-3);

            dpMaxDataRetirada.Value = dataHoje.AddDays(7);
            dpMaxPrevisEntrega.Value = dataHoje.AddDays(7);
            dpMaxDataEntrega.Value = dataHoje.AddDays(7);

            dpMaxDataRetirada.MaxDate = dataHoje;
            dpMaxDataEntrega.MaxDate = dataHoje;
        }

        private void GridEmprestimo_SelectionChanged(object sender, EventArgs e)
        {
            DataTable dadosEmprestimo = new DataTable();
            string filtrarSituacao = groupMenuSup.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();

            if(filtrarSituacao == "EM ANDAMENTO") { filtrarSituacao = "e.data_entrega is null"; }
            else if (filtrarSituacao == "FINALIZADO") { filtrarSituacao = "e.data_entrega is not null"; }
            else { filtrarSituacao = ""; }

            dadosEmprestimo = database.select(string.Format("" +
                "SELECT c.cod_imob, c.cod_chave, " +
                " (CASE WHEN e.data_entrega is null THEN 'EM ANDAMENTO' ELSE 'FINALIZADO' END) as situacao, " +
                " (CASE WHEN e.cod_proprietario is null AND e.cod_cliente is null THEN 'FUNCIONARIO' " +
                      "  WHEN e.cod_proprietario is null AND e.cod_cliente is not null THEN 'CLIENTE' " +
                       " WHEN e.cod_proprietario is not null AND e.cod_cliente is null THEN 'PROPRIETARIO' END) as tipo, " +
                       " '(' || cl.cod_cliente || ') - ' || cl.nome_cliente, cl.contato_principal || ' / ' || cl.contato_secundario, " +
                       " '(' || p.cod_proprietario || ') - ' || p.nome as proprietario, p.contato, u.nome_usuario, e.descricao, e.quant_chaves, " +
                       " e.quant_controles, e.data_retirada, e.entrega_prevista, e.data_entrega " +
                " FROM emprestimo e " +
                " LEFT JOIN chave c on c.indice_chave = e.cod_chave " +
                " LEFT JOIN cliente cl ON cl.cod_cliente = e.cod_cliente " +
                " LEFT JOIN usuario u ON u.cod_usuario = e.cod_usuario " +
                " LEFT JOIN proprietario p ON p.cod_proprietario = e.cod_proprietario" +
                " WHERE cod_emprestimo = '{0}'", gridEmprestimo.CurrentRow.Cells[0].Value.ToString()));

            foreach(DataRow row in dadosEmprestimo.Rows)
            {
                codigoImob.Text = row[0].ToString();
                codChave.Text = row[1].ToString();
                sitEmprestimo.Text = row[2].ToString();
                if(row[3].ToString() == "FUNCIONARIO")
                {
                    dadosRetirante.Text = string.Format("{0} [{1}]", row[8].ToString(), row[3].ToString());
                    
                }
                else if(row[3].ToString() == "CLIENTE")
                {
                    dadosRetirante.Text = string.Format("{0} [{1}]", row[4].ToString(), row[3].ToString());
                    contato.Text = row[5].ToString();
                }
                else
                {
                    dadosRetirante.Text = string.Format("{0} [{1}]", row[6].ToString(), row[3].ToString());
                    contato.Text = row[7].ToString();
                }
                descricao.Text = row[9].ToString();
                qtdChaves.Text = row[10].ToString();
                qtdControles.Text = row[11].ToString();
                funcionario.Text = row[8].ToString();
                dataRetirada.Text = row[12].ToString();
                previsEntrega.Text = row[13].ToString();
                dataEntrega.Text = row[14].ToString();
            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Endereco_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void SitChave_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void GridEmprestimo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CodigoImob_Click(object sender, EventArgs e)
        {

        }

        private void SitEmprestimo_Click(object sender, EventArgs e)
        {

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnFiltro_Click(object sender, EventArgs e)
        {
            filtrosPanel.Visible = true;
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            metroRadioButton1.Checked = true;
            checkDataRetirada.Checked = false;
            checkPrevisEntrega.Checked = false;
            checkDataEntrega.Checked = false;


            dpMinDataRetirada.Value = dataHoje.AddMonths(-3);
            dpMinPrevisEntrega.Value = dataHoje.AddMonths(-3);
            dpMinDataEntrega.Value = dataHoje.AddMonths(-3);

           

            dpMaxDataRetirada.MaxDate = dataHoje;
            dpMaxDataEntrega.MaxDate = dataHoje;
        }

        private void TextBoxBusca_Click(object sender, EventArgs e)
        {
            if (textBoxBusca.Text == "Buscar")
            {
                textBoxBusca.Text = "";
            }
        }

        private void TextBoxBusca_TextChanged(object sender, EventArgs e)
        {
            atualizarGridEmprestimo();
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            int contErro = 0;
            string msgErro = "A data mínima não pode ser superior à data máxima nos seguintes campos!\n\n";

            if(dpMinDataRetirada.Value > dpMaxDataRetirada.Value && checkDataRetirada.Checked)
            {
                msgErro += "- Data de Retirada";
                contErro++;
            }

            if (dpMinPrevisEntrega.Value > dpMaxPrevisEntrega.Value && checkPrevisEntrega.Checked)
            {
                msgErro += "- Previsão de entrega";
                contErro++;
            }

            if (dpMinDataEntrega.Value > dpMaxDataEntrega.Value && checkDataEntrega.Checked)
            {
                msgErro += "- Data de entrega";
                contErro++;
            }

            if(contErro != 0)
            {
                Message popup = new Message(msgErro, "", "erro", "confirma");
                popup.ShowDialog();
            }
            else
            {
                filtrosPanel.Visible = false;
                atualizarGridEmprestimo();
            }

            
        }

        private void MetroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FiltrosPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBoxBusca_Leave(object sender, EventArgs e)
        {
            if (textBoxBusca.Text == "")
            {
                textBoxBusca.Text = "Buscar";
            }
        }

        private void RadioTodos_CheckedChanged(object sender, EventArgs e)
        {
            atualizarGridEmprestimo();
        }

        private void GroupMenuSup_Enter(object sender, EventArgs e)
        {

        }

        private void CheckDataRetirada_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDataRetirada.Checked)
            {
                dpMinDataRetirada.Enabled = true; 
                dpMaxDataRetirada.Enabled = true;
            }
            else
            {
                dpMinDataRetirada.Enabled = false;
                dpMaxDataRetirada.Enabled = false;
            }
        }

        private void CheckPrevisEntrega_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPrevisEntrega.Checked)
            {
                dpMinPrevisEntrega.Enabled = true;
                dpMaxPrevisEntrega.Enabled = true;
            }
            else
            {
                dpMinPrevisEntrega.Enabled = false;
                dpMaxPrevisEntrega.Enabled = false;
            }
        }

        private void CheckDataEntrega_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDataEntrega.Checked)
            {
                dpMinDataEntrega.Enabled = true;
                dpMaxDataEntrega.Enabled = true;
            }
            else
            {
                dpMinDataEntrega.Enabled = false;
                dpMaxDataEntrega.Enabled = false;
            }
        }

        private void MetroRadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
