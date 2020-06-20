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
    public partial class ProrrogarReserva : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();

        string codReserva = "";
        public ProrrogarReserva(string codRes)
        {
            InitializeComponent();
            codReserva = codRes;
            novaData.MinDate = DateTime.Now;
        }

        private void ProrrogarReserva_Load(object sender, EventArgs e)
        {
            novaData.Value = DateTime.Now;
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            database.update(string.Format("UPDATE reserva" +
                                           " SET data_reserva = '{0}'" +
                                           " WHERE cod_reserva = '{1}'", novaData.Value, codReserva));

            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
