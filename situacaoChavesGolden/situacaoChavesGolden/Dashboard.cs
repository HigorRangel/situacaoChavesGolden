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
    public partial class Dashboard : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();
        string user = "";
        public Dashboard(string usuario)
        {
            InitializeComponent();
            user = usuario;
        }

        void atualizarInfo()
        {
            try
            {
                entAtrasada.Text = database.selectScalar("SELECT COUNT(*) " +
                            " FROM emprestimo " +
                            " WHERE data_entrega is null AND entrega_prevista < CURRENT_DATE");
            }
            catch
            {
                entAtrasada.Text = "";
            }

            try
            {
                reservaAtiva.Text = database.selectScalar("SELECT COUNT(*) " +
                             " FROM reserva " +
                             " WHERE situacao = 'EM ANDAMENTO'");
            }
            catch
            {
                reservaAtiva.Text = "";
            }

            try
            {
                emprestAtivo.Text = database.selectScalar("SELECT COUNT(*) " +
                             " FROM EMPRESTIMO " +
                             " WHERE data_entrega is null");
            }
            catch
            {
                emprestAtivo.Text = "";
            }

            try
            {
                propostas.Text = database.selectScalar("SELECT COUNT(*) " +
                            " FROM proposta " +
                            " WHERE situacao = 'EM ANALISE'");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
               propostas.Text = "";
            }

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            atualizarInfo();
        }

        private void EntregaAtrasadaPic_Click(object sender, EventArgs e)
        {
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.ShowDialog();
        }

        private void ReservasAtivasPic_Click(object sender, EventArgs e)
        {
            Reserva reserva = new Reserva(user);
            reserva.ShowDialog();

        }

        private void EmprestAtivosPic_Click(object sender, EventArgs e)
        {
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.ShowDialog();
        }
    }
}
