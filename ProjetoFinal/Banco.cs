﻿using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoFinal
{
    public class Banco
    {
        public static MySqlConnection Conexao;
        public static MySqlCommand Comando; //Passa as instruções a serem executadas
        public static MySqlDataAdapter Adaptador; //Insere dados em um dataTable
        public static DataTable datTabela;

        public static void AbrirConexao()
        {
            try
            {
                Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=etecjau");
                Conexao.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void FecharConexao()
        {
            try
            {
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CriarBanco()
        {
            try
            {
                AbrirConexao();
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas;", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("USE vendas;", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("create table if not exists cidades(" +
                                            "id int auto_increment," +
                                            "nome varchar(40)," + 
                                            "uf char(2)," + 
                                            "primary key (id));", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("create table if not exists marcas(" +
                                            "id int auto_increment," +
                                            "marca varchar(40)," +
                                            "primary key (id));", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("create table if not exists categorias(" +
                                            "id int auto_increment," +
                                            "categoria varchar(20)," +
                                            "primary key (id));", Conexao);
                Comando.ExecuteNonQuery();

                FecharConexao();
            } 
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
