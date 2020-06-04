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
    public partial class Proprietarios : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();
        DataTable proprietariosTable = new DataTable();

        public Proprietarios()
        {
            InitializeComponent();
        }

        private void atualizarGridProprietarios()
        {
            gridProprietarios.Columns.Clear();
            try
            {
                DataGridViewImageColumn cellImageEdit = new DataGridViewImageColumn();
                cellImageEdit.Image = new Bitmap(Properties.Resources.Edit);

                gridProprietarios.Columns.Insert(0, cellImageEdit);

                DataTable proprietarios = new DataTable();

                proprietarios = database.select(string.Format("SELECT DISTINCT p.* " +
                                                                " FROM proprietario p" +
                                                                " INNER JOIN chave c ON c.proprietario = p.cod_proprietario" +
                                                                " WHERE cod_proprietario::TEXT || 'p' ILIKE '{0}' OR nome ILIKE '%{0}%' OR contato::TEXT ILIKE '%{0}%' OR" +
                                                                " email ILIKE '%{0}%' OR c.cod_chave::text || 'c' = '{0}' OR c.rua ILIKE '{0}' OR c.cond ILIKE '{0}' OR" +
                                                                " unaccent(nome) ILIKE '%{0}%' OR unaccent(contato::text) ILIKE '%{0}%'OR unaccent(nome) ILIKE '%{0}%' OR " +
                                                                " unaccent(email) ILIKE '%{0}%' OR unaccent(c.cond) ILIKE '%{0}%'" +
                                                                " ORDER BY nome", boxBuscar.Text));
                proprietariosTable = proprietarios;
                
                gridProprietarios.DataSource = proprietarios.DefaultView;


                gridProprietarios.Columns[1].HeaderText = "Código";
                gridProprietarios.Columns[2].HeaderText = "Nome do Proprietário";
                gridProprietarios.Columns[3].HeaderText = "Contato";
                gridProprietarios.Columns[4].HeaderText = "Email do Proprietário";

               

                

                gridProprietarios.Columns[0].Width = 30;
                gridProprietarios.Columns[1].Width = 50;
                gridProprietarios.Columns[2].Width = 228;
                gridProprietarios.Columns[3].Width = 100;
                gridProprietarios.Columns[4].Width = 170;

            }
            catch { }

        }

        private void Proprietarios_Load(object sender, EventArgs e)
        {
            atualizarGridProprietarios();

            gridProprietarios.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            gridProprietarios.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            gridProprietarios.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            gridProprietarios.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void atualizarGridChave()
        {
            //string cod = gridProprietarios.Rows[gridProprietarios.CurrentRow.Index].Cells[2].Value.ToString();
            //if (gridProprietarios.SelectedRows != null)
            //{
            //    DataTable chaves = new DataTable();

            //    chaves = database.select(string.Format("" +
            //        "SELECT cod_chave, cod_imob, rua || ', ' || numero as endereco, bairro, situacao_imovel  " +
            //        " FROM chave " +
            //        " WHERE proprietario = '{0}'" +
            //        " ORDER BY situacao_imovel, rua, cod_imob", cod));

            //    gridChaves.DataSource = chaves.DefaultView;



            //    gridChaves.Columns[0].HeaderText = "Código";
            //    gridChaves.Columns[1].HeaderText = "Cód Imob";
            //    gridChaves.Columns[2].HeaderText = "Endereço";
            //    gridChaves.Columns[3].HeaderText = "Bairro";
            //    gridChaves.Columns[4].HeaderText = "Situação";

            //    gridChaves.Columns[0].Width = 60;
            //    gridChaves.Columns[1].Width = 60;
            //    gridChaves.Columns[2].Width = 275;
            //    gridChaves.Columns[3].Width = 112;
            //    gridChaves.Columns[4].Width = 100;
            //}
        }
        private void gridProprietarios_SelectionChanged(object sender, EventArgs e)
        {
            //atualizarGridChave();
            try
            {
                if (gridProprietarios.SelectedRows != null)
                {
                    DataTable chaves = new DataTable();

                    chaves = database.select(string.Format("" +
                        "SELECT cod_chave, cod_imob, rua || ', ' || numero as endereco, bairro, situacao_imovel  " +
                        " FROM chave " +
                        " WHERE proprietario = '{0}'" +
                        " ORDER BY situacao_imovel, rua, cod_imob", proprietariosTable.Rows[gridProprietarios.CurrentRow.Index][0]));

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
                }
            }
            catch { }
           
        }

        private void btnCadastrarProprietario_Click(object sender, EventArgs e)
        {
            cadastroProprietario cadastro = new cadastroProprietario();
            cadastro.ShowDialog();

            atualizarGridProprietarios();

        }

        private void gridProprietarios_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                //cadastroProprietario cp = new cadastroProprietario()
            }
            if(e.ColumnIndex == 1)
            {
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                gridProprietarios.AccessibilityObject.HitTest(MousePosition.X, MousePosition.Y).Select(AccessibleSelection.TakeSelection);

            }
            catch { }
        }

        private void gridProprietarios_MouseClick(object sender, MouseEventArgs e)
        {

            DataGridView.HitTestInfo hit = gridProprietarios.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.ColumnHeader)
            {
                return;
            }

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastroProprietario cadastro = new cadastroProprietario(gridProprietarios.CurrentRow.Cells[0].Value.ToString());
            cadastro.ShowDialog();

            atualizarGridProprietarios();
        }

        private void GridProprietarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                cadastroProprietario cadProp = new cadastroProprietario(proprietariosTable.Rows[e.RowIndex][e.ColumnIndex].ToString());
                cadProp.ShowDialog();
                atualizarGridChave();
                
            }
           
        }

        private void ExcluirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void GridChaves_MouseClick(object sender, MouseEventArgs e)
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
                        contextMenuStrip2.Show(gridChaves, new Point(e.X, e.Y));
                    }
                }



                DataRowView rowView = gridChaves.SelectedRows[0].DataBoundItem as DataRowView;

                DataRow dtRow = rowView.Row;
            }
        }

        private void RetirarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void GridProprietarios_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
           

            if (e.ColumnIndex == 0)
            {
                gridProprietarios.Cursor = Cursors.Hand;
            }
            else
            {
                gridProprietarios.Cursor = Cursors.Arrow;
            }
        }

        private void GridProprietarios_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void MetroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void BoxBuscar_TextChanged(object sender, EventArgs e)
        {
            atualizarGridProprietarios();
        }
    }
}
