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
    public partial class GerenciarUsuarios : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();
        public GerenciarUsuarios()
        {
            InitializeComponent();
        }

        private void atualizarGrid()
        {
            try
            {
                DataTable tabelaUsers = new DataTable();

                var col = new DataGridViewCheckBoxColumn();
                col.HeaderText = "Titulo";
                col.FalseValue = "0";
                col.TrueValue = "1";

                //Make the default checked
                //col.CellTemplate.Value = true;
                //col.CellTemplate.Style.NullValue = true;
                gridUsers.Columns.Insert(0, col);


                tabelaUsers = database.select("SELECT * FROM usuario" +
                                " ORDER BY cod_usuario");

                gridUsers.DataSource = tabelaUsers.DefaultView;

                gridUsers.Columns[1].HeaderText = "Cód";
                gridUsers.Columns[2].HeaderText = "Nome";
                gridUsers.Columns[3].Visible = false;


                gridUsers.Columns[0].Width = 44;
                gridUsers.Columns[1].Width = 40;
                gridUsers.Columns[2].Width = 200;

            }
            catch{}
        }
        private void GerenciarUsuarios_Load(object sender, EventArgs e)
        {
            atualizarGrid();
        }

        private void gridUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //DataGridViewRow row = gridUsers.Rows[e.RowIndex];

            //if (int.Parse(row.Cells[0].Value.ToString()) == 0)
            //{
                
            //}
        }
    }
}
