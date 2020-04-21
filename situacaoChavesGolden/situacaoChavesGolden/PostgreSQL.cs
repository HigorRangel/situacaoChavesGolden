using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace situacaoChavesGolden
{
    class PostgreSQL
    {
        public string nomeDB = "chaves_golden";

        private NpgsqlConnection conectar()
        {


            string connectionString = "";
            connectionString = "Server=localhost;Port=5432;UserID=postgres;Password=123456;Database=" + nomeDB; //String para conexão no PostgreSQL
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

            //try
            //{
                cmd.CommandText = comando;

                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            //}

            //catch (Exception erro)
            //{
            //    MessageBox.Show(erro.Message);
            //    return false;
            //}

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

        public void backup(string caminho, string nome)
        {
            MessageBox.Show("-h localhost -p 5432 -U postgres -F c -b -v -f \"" + caminho + nome + "\" postgres");
            string varAmbiente = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
            string[] colunas = varAmbiente.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            
            foreach (string variavel in colunas)
            {
                try
                {
                    ProcessStartInfo process = new ProcessStartInfo();
                    process.FileName = variavel + @"pg_dump.exe";
                
                    process.WindowStyle = ProcessWindowStyle.Minimized;
                    process.Arguments = "-h localhost -p 5432 -U postgres -F c -b -v -f \"" + caminho + nome + "\" chaves_golden";
                    Process processStart = new Process();
                    processStart.StartInfo = process;
                    processStart.Start();
                    processStart.WaitForExit();
                    break;
            }
                catch (Exception erro)
            {
               // MessageBox.Show("-h localhost - p 5432 - U postgres - F c - b - v - f \"" + caminho + nome + "\" postgres");
            }

        }

        }

        public void restore(string caminho, string nome)
        {
            string varAmbiente = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
            string[] colunas = varAmbiente.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string variavel in colunas)
            {
                try
                {
                    Environment.SetEnvironmentVariable("PGPASSWORD", "123456");
                    ProcessStartInfo process = new ProcessStartInfo();
                    process.FileName = variavel + @"pg_restore";
                    process.WindowStyle = ProcessWindowStyle.Normal;
                    //MessageBox.Show(variavel);
                    process.Arguments = "-U postgres -d chaves_golden -w \"" + caminho + nome + "\"";
                    //process.Arguments = "PGPASSWORD=123456";
                    Process processStart = new Process();
                    processStart.StartInfo = process;
                    processStart.Start();
                    processStart.WaitForExit();
                    break;
                }
                catch (Exception erro)
                {
                   //
                    //MessageBox.Show(erro.Message);
                }
               
            }
        }
    }
}
