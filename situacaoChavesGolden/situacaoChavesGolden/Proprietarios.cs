using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace situacaoChavesGolden
{
    public partial class Proprietarios : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();

        public Proprietarios()
        {
            InitializeComponent();
        }

        private void atualizarGridProprietarios()
        {
            try
            {
                DataTable proprietarios = new DataTable();

                proprietarios = database.select(string.Format("SELECT * FROM proprietario ORDER BY nome"));

                gridProprietarios.DataSource = proprietarios;


                gridProprietarios.Columns[0].HeaderText = "Código";
                gridProprietarios.Columns[1].HeaderText = "Nome do Proprietário";
                gridProprietarios.Columns[2].HeaderText = "Contato";
                gridProprietarios.Columns[3].HeaderText = "Email do Proprietário";

                gridProprietarios.Columns[0].Width = 50;
                gridProprietarios.Columns[1].Width = 258;
                gridProprietarios.Columns[2].Width = 100;
                gridProprietarios.Columns[3].Width = 200;
            }
            catch { }
            

            


        }

        private void Proprietarios_Load(object sender, EventArgs e)
        {
            atualizarGridProprietarios();
        }

        private void gridProprietarios_SelectionChanged(object sender, EventArgs e)
        {
            if(gridProprietarios.SelectedRows != null)
            {
                DataTable chaves = new DataTable();

                chaves = database.select(string.Format("" +
                    "SELECT cod_chave, cod_imob, rua || ', ' || numero as endereco, bairro, situacao_imovel  " +
                    " FROM chave " +
                    " WHERE proprietario = '{0}'" +
                    " ORDER BY situacao_imovel, rua, cod_imob", gridProprietarios.CurrentRow.Cells[0].Value));

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

        private void btnCadastrarProprietario_Click(object sender, EventArgs e)
        {
            cadastroProprietario cadastro = new cadastroProprietario();
            cadastro.ShowDialog();

            atualizarGridProprietarios();

        }

        private void gridProprietarios_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
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
            if (e.Button == MouseButtons.Right)
            {

                if (gridProprietarios.CurrentCell != null)
                {
                    DataGridView.HitTestInfo info;
                    info = gridProprietarios.HitTest(e.X, e.Y);
                    if (info.Type == DataGridViewHitTestType.Cell)
                    {
                        if (info.Type == DataGridViewHitTestType.Cell && info.ColumnIndex == 1)
                            gridProprietarios.CurrentCell.Selected = false;
                        gridProprietarios[info.ColumnIndex, info.RowIndex].Selected = true;
                        gridProprietarios.Refresh();
                        contextMenuStrip1.Show(gridProprietarios, new Point(e.X, e.Y));
                    }
                }



                DataRowView rowView = gridProprietarios.SelectedRows[0].DataBoundItem as DataRowView;

                DataRow dtRow = rowView.Row;
            }

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastroProprietario cadastro = new cadastroProprietario(gridProprietarios.CurrentRow.Cells[0].Value.ToString());
            cadastro.ShowDialog();

            atualizarGridProprietarios();
        }
    }
}
