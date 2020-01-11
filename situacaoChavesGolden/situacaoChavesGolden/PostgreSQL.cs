using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace situacaoChavesGolden
{
    class PostgreSQL
    {
        public string nomeDB = "postgres";

        private NpgsqlConnection conectar()
        {


            string connectionString = "";
            connectionString = "Server=imob-golden.cluxnabums8p.us-east-2.rds.amazonaws.com;Port=5432;UserID=postgres;Password=45945261;Database=" + nomeDB; //String para conexão no PostgreSQL
            NpgsqlConnection conn = new NpgsqlConnection(connectionString); //Cria objeto para conexão


            conn.Open(); // Inicia conexão

            return conn;

        }



        public void insertInto(string comando)
        {

            var conn = conectar();
            NpgsqlCommand cmd = new NpgsqlCommand(); //Cria objeto para utilizar os comandos no PostgreSQL
            cmd.Connection = conn;



            cmd.CommandText = comando;

            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public DataTable select(string comando)
        {


            var conn = conectar();



            DataTable dtTabela = new DataTable(); //Cria tabela de dados
            dtTabela.Clear(); //Apaga todos os dados da tabela


            NpgsqlDataAdapter dados = new NpgsqlDataAdapter(comando, conn); //Objeto de dados


            dados.Fill(dtTabela); //Completa a tabelas com os dados


            conn.Close();

            return dtTabela;


        }

        public string selectScalar(string comando)
        {
            string resultado = "";


            var conn = conectar();


            NpgsqlCommand dados = new NpgsqlCommand(comando, conn); //Objeto de dados


            resultado = dados.ExecuteScalar().ToString();


            conn.Close();



            return resultado;
        }

        public bool update(string comando)
        {
            var conn = conectar(); //Chama método de conexão ao Banco de dados
            NpgsqlCommand cmd = new NpgsqlCommand(); //Cria objeto para utilizar os comandos no PostgreSQL
            cmd.Connection = conn;

            try
            {
                cmd.CommandText = comando;

                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                return false;
            }

        }

        public bool delete(string comando)
        {
            var conn = conectar(); //Chama método de conexão ao Banco de dados
            NpgsqlCommand cmd = new NpgsqlCommand(); //Cria objeto para utilizar os comandos no PostgreSQL
            cmd.Connection = conn;

            try
            {
                cmd.CommandText = comando;

                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }

            catch
            {
                return false;
            }
        }

    }
}
