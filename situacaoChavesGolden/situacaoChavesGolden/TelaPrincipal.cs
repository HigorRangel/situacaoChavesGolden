using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace situacaoChavesGolden
{
    public partial class TelaPrincipal : MetroFramework.Forms.MetroForm
    {
        //Método para atualizar o form
        public void atualizarForm(MetroForm form)
        {
            
            //Desativa o TopLevel
            form.TopLevel = false;

            //Apaga atual form dentro do panel
            if (painelPrincipal.Controls.Count != 0)
            {
                painelPrincipal.Controls.RemoveAt(0);
            }

            //Deixa maximizado para evitar erros
            form.WindowState = FormWindowState.Maximized;
            form.ShadowType = MetroFormShadowType.None;

            //Adiciona o form nos controles do painel
            painelPrincipal.Controls.Add(form);

            //Mostra o form no painel
            form.Show();


            
        }

        string usuario = "";


        
        public TelaPrincipal(string codigoUsuario)
        {
            InitializeComponent();
            usuario = codigoUsuario;
        }

        public TelaPrincipal()
        {
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(usuario);
            atualizarForm(dashboard);
        }

       
        private void BtnInicio_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(usuario);
            atualizarForm(dashboard);
        }

        private void btnChaves_Click(object sender, EventArgs e)
        {
            Chaves telaChaves = new Chaves(usuario);
            atualizarForm(telaChaves);
            telaChaves.radioTodos.Checked = true;
            telaChaves.radioLocacao.Checked = false;
            telaChaves.radioVenda.Checked = false;
        }

        private void BtnProprietarios_Click(object sender, EventArgs e)
        {
            Proprietarios proprietario = new Proprietarios();
            atualizarForm(proprietario);
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            EmManutencao telaManut = new EmManutencao("PREVISÃO DE RETORNO: 23/05/2020");
            atualizarForm(cliente);
        }

        private void BtnEmprestimos_Click(object sender, EventArgs e)
        {
            Emprestimo telaEmprestimo = new Emprestimo();
            atualizarForm(telaEmprestimo);
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            Reserva telaReserva = new Reserva(usuario);
            atualizarForm(telaReserva);

            //EmManutencao telaManut = new EmManutencao("PREVISÃO DE RETORNO: 20/05/2020");
            //atualizarForm(telaManut);
        }

        private void BtnPropostas_Click(object sender, EventArgs e)
        {
            Propostas propostas = new Propostas();
            atualizarForm(propostas);
        }

        private void PainelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnRetirados_Click(object sender, EventArgs e)
        {
            Retirados ret = new Retirados();

            atualizarForm(ret);
        }
    }
}
