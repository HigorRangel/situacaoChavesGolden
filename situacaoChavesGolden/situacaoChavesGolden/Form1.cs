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
using System.IO;

namespace situacaoChavesGolden
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();
        List<string> ListaCodigos = new List<string>();
        string codigo = "";
        FormatarStrings format = new FormatarStrings();

        public Login()
        {
            InitializeComponent();
            
            
        }
                      
        private void limparTemp()
        {
            try
            {
                DirectoryInfo diretorio = new DirectoryInfo(Environment.CurrentDirectory + @"\temp");

                FileInfo[] arquivos = diretorio.GetFiles();

                foreach(FileInfo file in arquivos)
                {
                    try
                    {
                        file.Delete();
                    }
                    catch { }
                    
                }
            }
            catch { }
        }

        private void criarPastas()
        {
            string folder = Environment.CurrentDirectory + @"\temp";
            if (!Directory.Exists(folder))
            {

                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);

            }

            folder = Environment.CurrentDirectory + @"\BACKUPS";

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            criarPastas();
            limparTemp();


            //string caminho = Environment.CurrentDirectory;
            //caminho = caminho.Replace("bin\\Debug", "");

            //database.restore(caminho, "backupDados.backup");

            //Cria tabela para preencher com os usuários
            DataTable usuarios = new DataTable();

            //Coloca os usuários cadastrados na tabela
            usuarios = database.select(string.Format("SELECT * FROM usuario" +
                                                     " ORDER BY nome_usuario"));

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //string caminho = Environment.CurrentDirectory;
            //caminho = caminho.Replace("bin\\Debug", "");



            //database.backup(caminho, "\\backupDados.dump");

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void MaskedTextBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            format.permitirNumeros( e);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();

            f2.ShowDialog();
        }
    }
}
