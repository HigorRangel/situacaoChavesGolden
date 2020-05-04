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
    public partial class Propostas : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();
        public Propostas()
        {
            InitializeComponent();
        }

        void atualizarGrid()
        {
            gridPropostas.DataSource = database.select("SELECT p.cod_proposta, c.rua || ', ' || c.numero || ' - ' || c.bairro as endereco, p.data, p.situacao " +
                                                        " FROM proposta p " +
                                                        " INNER JOIN emprestimo e ON p.emprestimo = e.cod_emprestimo " +
                                                        " INNER JOIN chave c ON c.indice_chave = e.cod_chave");

            gridPropostas.Columns[0].HeaderText = "Código";
            gridPropostas.Columns[1].HeaderText = "Endereço";
            gridPropostas.Columns[2].HeaderText = "Data";
            gridPropostas.Columns[3].HeaderText = "Situação";

            gridPropostas.Columns[0].Width = 60;
            gridPropostas.Columns[1].Width = 258;
            gridPropostas.Columns[2].Width = 145;
            gridPropostas.Columns[3].Width = 145;
        }

        private void Propostas_Load(object sender, EventArgs e)
        {
            atualizarGrid();
        }

        private void FiltrosPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MetroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void CheckDataRetirada_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {

        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {

        }
    }
}
