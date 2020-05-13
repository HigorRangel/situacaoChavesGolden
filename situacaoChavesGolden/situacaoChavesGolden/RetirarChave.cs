﻿using System;
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
    public partial class RetirarChave : MetroFramework.Forms.MetroForm
    {
        PostgreSQL database = new PostgreSQL();
        DateTime dataHora = DateTime.Now;

        string codigoChave = "";
        string usuario = "";

        public RetirarChave(string codChave, string user)
        {
            InitializeComponent();

            codigoChave = codChave;

            usuario = user;
        }

        private void RetirarChave_Load(object sender, EventArgs e)
        {

        }

        private void MetroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            int contErros = 0;
            string texto = "Não foi possível cadastrar a retirada. Verifique os campos abaixo e tente novamente.\n\n";
            string tipoRetirada = groupTipo.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text;

            if(tipoRetirada == "Proprietário (a)") { tipoRetirada = "PROPRIETARIO"; }
            else if (tipoRetirada == "Funcionário (a)") { tipoRetirada = "FUNCIONARIO"; } 
            else { tipoRetirada = "OUTRO"; }


            if (quemRetirouBox.Text.Length == 0)
            {
                contErros++;
                texto += "\n- Quem retirou (Preenchimento obrigatório)";
            }

            if(descricaoBox.Text.Length == 0)
            {
                contErros++;
                texto += "\n- Descrição/motivo (Preenchimento obrigatório)";
            }

            string dataAgora = dataHora.ToString("yyyy-MM-dd H:mm:ss");

            if(contErros == 0)
            {
                FormatarStrings format = new FormatarStrings();
                try
                {
                    database.insertInto(string.Format("INSERT INTO retirado (cod_chave, tipo_retirada, quem_retirou, descricao, data_retirada, cod_usuario)" +
                                                    " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", codigoChave, tipoRetirada, format.inserirBD(quemRetirouBox.Text),
                                                    format.inserirBD(descricaoBox.Text), dataAgora, usuario));

                    database.update(string.Format("UPDATE chave " +
                                                  " SET situacao = 'INDISPONIVEL', localizacao = '{0}'," +
                                                  " situacao_imovel = 'INATIVO', cod_chave = null" +
                                                  " WHERE indice_chave = '{1}'", tipoRetirada, codigoChave));

                    database.update(string.Format("UPDATE reserva" +
                                                    " SET situacao = 'FINALIZADO'" +
                                                    " WHERE cod_chave = '{0}'", codigoChave));

                    Message caixaMensagem = new Message("Chave retirada com sucesso!", "", "sucesso", "confirma");
                    caixaMensagem.ShowDialog();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception erro)
                {
                    
                    Message caixaMensagem = new Message("Não foi possível cadastrar a retirada! \n\n Erro: " + erro, "", "sucesso", "confirma");
                    caixaMensagem.ShowDialog();

                }
            }
                
            else
            {
                Message boxMsg = new Message(texto, "Erro ao cadastrar", "erro", "confirma");
                boxMsg.ShowDialog();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
