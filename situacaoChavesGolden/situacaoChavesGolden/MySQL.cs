using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace situacaoChavesGolden
{
    class MySQL
    {
        public string nomeDB = "chaves_golden";

        private MySqlConnection conectar()
        {
            string connectionString = "";
            connectionString = "Server=localhost;Port=3306;User Id=root;Database=" + nomeDB + ";Password=;SslMode=none"; //String para conexão no PostgreSQL
            MySqlConnection conn = new MySqlConnection(connectionString); //Cria objeto para conexão


            conn.Open(); // Inicia conexão

            return conn;
        }



        public void insertInto(string comando)
        {

            var conn = conectar();
            MySqlCommand cmd = new MySqlCommand(); //Cria objeto para utilizar os comandos no PostgreSQL
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


            MySqlDataAdapter dados = new MySqlDataAdapter(comando, conn); //Objeto de dados


            dados.Fill(dtTabela); //Completa a tabelas com os dados


            conn.Close();

            return dtTabela;


        }

        public string selectScalar(string comando)
        {
            string resultado = "";


            var conn = conectar();


            MySqlCommand dados = new MySqlCommand(comando, conn); //Objeto de dados


            resultado = dados.ExecuteScalar().ToString();


            conn.Close();



            return resultado;
        }

        public bool update(string comando)
        {
            var conn = conectar(); //Chama método de conexão ao Banco de dados
            MySqlCommand cmd = new MySqlCommand(); //Cria objeto para utilizar os comandos no PostgreSQL
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
            MySqlCommand cmd = new MySqlCommand(); //Cria objeto para utilizar os comandos no PostgreSQL
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
