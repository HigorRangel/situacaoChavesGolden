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

            chaves = database.select("SELECT cod_imob, rua || ', ' || numero as endereco, bairro, situacao_imovel  FROM chave");


            gridChaves.DataSource = chaves;

            gridChaves.Columns[0].HeaderText = "Código";
            gridChaves.Columns[1].HeaderText = "Endereço";
            gridChaves.Columns[2].HeaderText = "Bairro";
            gridChaves.Columns[3].HeaderText = "Situação";

            gridChaves.Columns[0].Width = 60;
            gridChaves.Columns[1].Width = 315;
            gridChaves.Columns[2].Width = 132;
            gridChaves.Columns[3].Width = 100;







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
    
    }
}
