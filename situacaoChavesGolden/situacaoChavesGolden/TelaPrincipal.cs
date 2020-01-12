﻿using System;
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
        private void atualizarForm(MetroForm form)
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

            //Adiciona o form nos controles do painel
            painelPrincipal.Controls.Add(form);

            //Mostra o form no painel
            form.Show();
        }


        public TelaPrincipal(string codigo)
        {
            InitializeComponent();
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            
        }

       
        private void BtnInicio_Click(object sender, EventArgs e)
        {
            cadastroChave telaCadastro = new cadastroChave();
            atualizarForm(telaCadastro);
        }
    }
}