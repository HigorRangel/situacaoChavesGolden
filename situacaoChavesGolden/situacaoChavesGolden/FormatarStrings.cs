using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace situacaoChavesGolden
{
    class FormatarStrings
    {
        public string inserirBD(string texto)
        {
            texto = texto.Replace("'", "''");

            return texto;
        }

        public void permitirNumeros(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
