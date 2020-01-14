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
    public partial class Chaves : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();
        public Chaves()
        {
            InitializeComponent();
        }

        private void Chaves_Load(object sender, EventArgs e)
        {
            DataTable chaves = new DataTable();

            chaves = database.select("SELECT cod_chave, cod_imob, rua || ', ' || numero as endereco, bairro, situacao_imovel  FROM chave");


            gridChaves.DataSource = chaves;

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


        }

        private void gridChaves_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void gridChaves_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{

            //    if(gridChaves.CurrentCell != null)
            //    {
            //        DataGridView.HitTestInfo info;
            //        info = gridChaves.HitTest(e.X, e.Y);
            //        if (info.Type == DataGridViewHitTestType.Cell)
            //        {
            //            if (info.Type == DataGridViewHitTestType.Cell && info.ColumnIndex == 1)
            //                gridChaves.CurrentCell.Selected = false;
            //            gridChaves[info.ColumnIndex, info.RowIndex].Selected = true;
            //            gridChaves.Refresh();
            //            contextMenuStrip1.Show(gridChaves, new Point(e.X, e.Y));
            //        }
            //    }



                //DataRowView rowView = gridChaves.SelectedRows[0].DataBoundItem as DataRowView;

                //DataRow dtRow = rowView.Row;
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
            if(gridChaves.CurrentRow != null)
            {

                string codigoChave = gridChaves.CurrentRow.Cells[0].Value.ToString();

                DataTable dadosChave = new DataTable();

                dadosChave = database.select(string.Format("SELECT * FROM chave WHERE cod_chave = '{0}'", codigoChave));
                

                foreach(DataRow row in dadosChave.Rows)
                {
                    codigoImob.Text = row[10].ToString();
                    finalidade.Text = row[12].ToString();
                    sitImovel.Text = row[13].ToString();
                    endereco.Text = string.Format("{0}, {1} - {2} - {3}/{4} [{5}]", row[1].ToString(),
                        row[2].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(),
                        row[4].ToString());
                    proprietario.Text = row[9].ToString();
                    tipoImovel.Text = row[11].ToString();
                    sitChave.Text = row[7].ToString();
                    localizacao.Text = row[7].ToString();
                                                          
                }

                string codEmprestimo = "";
                try
                {
                    codEmprestimo = database.selectScalar(string.Format("" +
                                        " SELECT e.cod_emprestimo" +
                                        " FROM emprestimo e" +
                                        " INNER JOIN chave c ON c.cod_chave = e.cod_chave" +
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
            cadastroChave cadastro = new cadastroChave();

            cadastro.ShowDialog();
        }
    }
}
