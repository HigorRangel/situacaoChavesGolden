using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace situacaoChavesGolden
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();
        List<string> ListaCodigos = new List<string>();


        public Form1()
        {
            InitializeComponent();
            
            
        }
                      

        private void Form1_Load(object sender, EventArgs e)
        {
            //Cria tabela para preencher com os usuários
            DataTable usuarios = new DataTable();

            //Coloca os usuários cadastrados na tabela
            usuarios = database.select(string.Format("SELECT * FROM usuario"));

            //Apaga itens da ComboBox
            comboUsuarios.Items.Clear();

            //Percorre os resultados e coloca os nomes dentro do comboBox
            foreach(DataRow row in usuarios.Rows)
            {
                comboUsuarios.Items.Add(row[1].ToString());
                ListaCodigos.Add(row[0].ToString());
            }

        }

        //Evento no momento em que o mouse é colocado em cima do botão
        private void BtnEntrar_MouseEnter(object sender, EventArgs e)
        {
            //Muda cor do texto do botão
            btnEntrar.ForeColor = Color.White;

        }
        //Evento no momento em que o mouse é deixado decima do botão
        private void BtnEntrar_MouseLeave(object sender, EventArgs e)
        {
            //Muda cor do texto do botão
            btnEntrar.ForeColor = Color.FromArgb(0, 149, 255);
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //Se não tiver usuário selecionado
            if(comboUsuarios.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um usuário");
            }
            //Se tiver
            else
            {
                //Abre a tela principal
                TelaPrincipal tela = new TelaPrincipal(ListaCodigos[comboUsuarios.SelectedIndex]);

                tela.ShowDialog();
            }
        }
    }
}
