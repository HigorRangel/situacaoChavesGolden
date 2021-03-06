﻿using System;
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
        public string serverBD = Properties.Settings.Default.serverBD;
        NpgsqlConnection conn = new NpgsqlConnection();

        public PostgreSQL()
        {
            conn.ConnectionString = string.Format("Server={0};Port=5432;UserID=postgres;Password=123456;Database={1};Maximum Pool Size=1000", serverBD, nomeDB);
            conn.Open();
        }
        

        public void excluirConn()
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(string.Format("SELECT " +
                                                   " pg_terminate_backend(pg_stat_activity.pid) " +
                                                   " FROM pg_stat_activity " +
                                                   " WHERE " +
                                                      " pg_stat_activity.datname = '{0}' " +
                                                   " AND pid <> pg_backend_pid()", nomeDB));

                cmd.Connection = conn;
                cmd.ExecuteNonQuery();


            }
            catch { }




        }
        public void insertInto(string comando)
        {
           
            NpgsqlCommand cmd = new NpgsqlCommand(); //Cria objeto para utilizar os comandos no PostgreSQL
            cmd.Connection = conn;



            cmd.CommandText = comando;

            cmd.ExecuteNonQuery();
        }


        public DataTable select(string comando)
        {


            DataTable dtTabela = new DataTable(); //Cria tabela de dados
            dtTabela.Clear(); //Apaga todos os dados da tabela


            NpgsqlDataAdapter dados = new NpgsqlDataAdapter(comando, conn); //Objeto de dados


            dados.Fill(dtTabela); //Completa a tabelas com os dados


            //conn.Close();

            return dtTabela;

        }

        public string selectScalar(string comando)
        {
            //excluirConn();
            string resultado = "";


            //var conn = conectar();


            NpgsqlCommand dados = new NpgsqlCommand(comando, conn); //Objeto de dados


            resultado = dados.ExecuteScalar().ToString();


            //conn.Close();



            return resultado;
        }

        public bool update(string comando)
        {
            //excluirConn();
            //var conn = conectar(); //Chama método de conexão ao Banco de dados
            NpgsqlCommand cmd = new NpgsqlCommand(); //Cria objeto para utilizar os comandos no PostgreSQL
            cmd.Connection = conn;

            //try
            //{
                cmd.CommandText = comando;

                cmd.ExecuteNonQuery();
                //conn.Close();

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
           //excluirConn();
           // var conn = conectar(); //Chama método de conexão ao Banco de dados
            NpgsqlCommand cmd = new NpgsqlCommand(); //Cria objeto para utilizar os comandos no PostgreSQL
            cmd.Connection = conn;

            try
            {
                cmd.CommandText = comando;

                cmd.ExecuteNonQuery();
                //conn.Close();

                return true;
            }

            catch
            {
                return false;
            }
        }

        public void backup(string nome)
        {
            //excluirConn();


            string nomeArquivo = Environment.CurrentDirectory + @"\BACKUPS\" +
                DateTime.Now.ToString("yyyy-MM-dd hh.mm.ss") + " - " + nome + ".sql";

            

            string varAmbiente = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
            string[] colunas = varAmbiente.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            
            foreach (string variavel in colunas)
            {
                try
                {
                    ProcessStartInfo process = new ProcessStartInfo();
                    process.FileName = variavel + @"pg_dump";
                
                    process.WindowStyle = ProcessWindowStyle.Hidden;
                    process.Arguments = "-h " + serverBD + " -p 5432 -U postgres -F c -b -v -f \"" + nomeArquivo + "\" chaves_golden";
                //MessageBox.Show("-h localhost -p 5432 -U postgres -F c -b -v -f \"" + nomeArquivo + "\" chaves_golden");
                    //process.Arguments = "PGPASSWORD=123456";
                    Environment.SetEnvironmentVariable("PGPASSWORD", "123456");
                    Process processStart = new Process();
                    processStart.StartInfo = process;
                    processStart.Start();
                    processStart.WaitForExit();

                    //MessageBox.Show("DEU BOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOM");

                    break;

                }
                catch (Exception erro)
                {
                    //MessageBox.Show(erro.Message);
                }

            }

        }

        public void restore(string caminho, string nome)
        {
            //excluirConn();
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
