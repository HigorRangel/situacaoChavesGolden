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
    public partial class Chaves : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();


        public void atualizarGridChaves()
        {
            DataTable chaves = new DataTable();

            string textoBusca = textBoxBusca.Text;
            string filtroSitImovel = groupBoxSituacaoIm.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string filtroSitChave = groupBoxSituacaoCh.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string typeImovel = groupBoxTipoImovel.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            string filtro = groupMenuSup.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text.ToUpper();
            
            if(textoBusca == "Buscar") { textoBusca = ""; }
            if (filtroSitImovel == "TODOS") { filtroSitImovel = ""; }
            if (filtroSitChave == "TODOS") { filtroSitChave = ""; }
            if (typeImovel == "TODOS") { typeImovel = ""; }
            if (filtro == "TODOS") { filtro = ""; }

            
            try
            {
                chaves = database.select(string.Format("SELECT cod_chave, cod_imob, rua || ', ' || numero as endereco, bairro, situacao_imovel " +
                                             " FROM chave C" +
                                             " INNER JOIN proprietario p ON p.cod_proprietario = c.proprietario " +
                                             " WHERE (rua ILIKE '%{0}%' OR bairro ILIKE '%{0}%' OR cidade ILIKE '%{0}%' OR estado ILIKE '%{0}%' OR" +
                                             " numero  ILIKE '%{0}%' OR complemento ILIKE '%{0}%' OR cod_imob ILIKE '%{0}%' OR p.nome ILIKE '%{0}%') AND" +
                                             " (finalidade ILIKE '%{1}%' AND situacao ILIKE '%{2}%' AND situacao_imovel ILIKE '%{3}%' AND " +
                                             "  tipo_imovel ILIKE '%{4}%')" +
                                             " ORDER BY situacao_imovel, rua, cod_imob", textoBusca, filtro, filtroSitChave,
                                              filtroSitImovel, typeImovel));
               

                gridChaves.DataSource = chaves;

                if(chaves.Rows.Count == 0)
                {
                    codigoImob.Text = "";
                    finalidade.Text = "";
                    sitImovel.Text = "";
                    endereco.Text = "";
                    proprietario.Text = "";
                    tipoImovel.Text = "";
                    sitChave.Text = "";
                    localizacao.Text = "";
                }
                else
                {
                    gridChaves.Columns[0].HeaderText = "Código";
                    gridChaves.Columns[1].HeaderText = "Cód Imob";
                    gridChaves.Columns[2].HeaderText = "Endereço";
                    gridChaves.Columns[3].HeaderText = "Bairro";
                    gridChaves.Columns[4].HeaderText = "Situação";

                    gridChaves.Columns[0].Width = 60;
                    gridChaves.Columns[1].Width = 60;
                    gridChaves.Columns[2].Width = 275;
                    gridChaves.Columns[3].Width = 112;
                    gridChaves.Columns[4].Width = 100;




                    endereco.MaximumSize = new Size(520, 0);
                    endereco.AutoSize = true;
                    gridChaves.ClearSelection();
                    gridChaves.Rows[0].Selected = false;

                    if(proprietario.Text != " ")
                    {
                        proprietario.Cursor = Cursors.Hand;
                    }
                    

                }

                
            }
            catch (Exception erro)
            {

                //MessageBox.Show(erro.Message);
            }


        }


        public Chaves()
        {
            InitializeComponent();
        }

        private void Chaves_Load(object sender, EventArgs e)
        {

            atualizarGridChaves();

        }

        private void gridChaves_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                if (gridChaves.CurrentCell != null)
                {
                    DataGridView.HitTestInfo info;
                    info = gridChaves.HitTest(e.X, e.Y);
                    if (info.Type == DataGridViewHitTestType.Cell)
                    {
                        if (info.Type == DataGridViewHitTestType.Cell && info.ColumnIndex == 1)
                            gridChaves.CurrentCell.Selected = false;
                        gridChaves[info.ColumnIndex, info.RowIndex].Selected = true;
                        gridChaves.Refresh();
                        contextMenuStrip1.Show(gridChaves, new Point(e.X, e.Y));
                    }
                }



                DataRowView rowView = gridChaves.SelectedRows[0].DataBoundItem as DataRowView;

                DataRow dtRow = rowView.Row;
            }
        }

        private void gridChaves_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                gridChaves.AccessibilityObject.HitTest(MousePosition.X, MousePosition.Y).Select(AccessibleSelection.TakeSelection);

            }
            catch { }


        }

        private void GridChaves_SelectionChanged(object sender, EventArgs e)
        {
            if(gridChaves.CurrentRow == null)
            {
                codigoImob.Text = "";
                finalidade.Text = "";
                sitImovel.Text = "";
                endereco.Text = "";
                proprietario.Text = "";
                tipoImovel.Text = "";
                sitChave.Text = "";
                localizacao.Text =   "";
            }

            if (gridChaves.CurrentRow != null)
            {

                string codigoChave = gridChaves.CurrentRow.Cells[0].Value.ToString();

                DataTable dadosChave = new DataTable();

                dadosChave = database.select(string.Format("SELECT c.*, p.nome " +
                                                           " FROM chave c  " +
                                                           " INNER JOIN proprietario p ON p.cod_proprietario = c.proprietario " +
                                                           " WHERE cod_chave = {0}", codigoChave));


                foreach (DataRow row in dadosChave.Rows)
                {
                    codigoImob.Text = row[10].ToString();
                    finalidade.Text = row[12].ToString();
                    sitImovel.Text = row[13].ToString();
                    endereco.Text = string.Format("{0}, {1} - {2} - {3}/{4} [{5}]", row[1].ToString(),
                        row[5].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(),
                        row[6].ToString());
                    proprietario.Text = row[15].ToString();
                    tipoImovel.Text = row[11].ToString();
                    sitChave.Text = row[7].ToString();
                    localizacao.Text = row[8].ToString();

                }

                string codEmprestimo = "";
                try
                {
                    codEmprestimo = database.selectScalar(string.Format("" +
                                        " SELECT e.cod_emprestimo" +
                                        " FROM emprestimo e" +
                                        " INNER JOIN chave c ON c.indice_chave = e.cod_chave" +
                                        " WHERE e.cod_chave = {0} AND e.data_entrega is null", codigoChave));
                    emprestimo.Text = codEmprestimo;
                    emprestimo.Cursor = Cursors.Hand;

                }
                catch (NullReferenceException)
                {
                    emprestimo.Text = "N/A";
                    emprestimo.Cursor = Cursors.Default;
                }



            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void RadioTodos_CheckedChanged(object sender, EventArgs e)
        {
            atualizarGridChaves();
        }

        private void EditarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridChaves.CurrentRow != null)
            {

                string codigoChave = gridChaves.CurrentRow.Cells[0].Value.ToString();


                cadastroChave editarChave = new cadastroChave(codigoChave);

                editarChave.ShowDialog();

            }
        }

        private void BtnCadastrarChave_Click(object sender, EventArgs e)
        {
            cadastroChave cadastro = new cadastroChave();

            cadastro.ShowDialog();

            if(cadastro.DialogResult == DialogResult.Yes)
            {
                atualizarGridChaves();
            }
        }

        private void textBoxBusca_Click(object sender, EventArgs e)
        {
            if(textBoxBusca.Text == "Buscar")
            {
                textBoxBusca.Text = "";
            }
            
        }

        private void X(object sender, EventArgs e)
        {

        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            filtrosPanel.Visible = true;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtrosPanel.Visible = false;
            atualizarGridChaves();
        }


        private void TextBoxBusca_Leave(object sender, EventArgs e)
        {
            if(textBoxBusca.Text == "")
            {
                textBoxBusca.Text = "Buscar";
            }
        }

        private void TextBoxBusca_TextChanged(object sender, EventArgs e)
        {
            atualizarGridChaves();          
        }

        private void Proprietario_Click(object sender, EventArgs e)
        {
            if(proprietario.Text != " ")
            {
                string codigoProp = database.selectScalar(string.Format("SELECT cod_proprietario FROM proprietario" +
                                                                        " WHERE nome = '{0}'", proprietario.Text));

                cadastroProprietario showProprietario = new cadastroProprietario(codigoProp);
                showProprietario.ShowDialog();
            }
        }

        private void ExcluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string codigoChaveRetirar = gridChaves.CurrentRow.Cells[0].Value.ToString();

            RetirarChave telaRetirar = new RetirarChave(codigoChaveRetirar);
            telaRetirar.ShowDialog();
        }
    }
}
