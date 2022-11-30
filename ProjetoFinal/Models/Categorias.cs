using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoFinal.Models
{
    public class Categoria
    {
        public int id { get; set; }
        public string categoria { get; set; }


        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("USE vendas;", Banco.Conexao);
                Banco.Comando.ExecuteNonQuery();

                Banco.Comando = new MySqlCommand("INSERT INTO categorias (categoria) VALUES (@categoria);", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@categoria", categoria);

                Banco.Comando.ExecuteNonQuery();
                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Alterar()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("USE vendas;", Banco.Conexao);
                Banco.Comando.ExecuteNonQuery();

                Banco.Comando = new MySqlCommand("UPDATE categorias SET categoria = @categoria " +
                                                 "WHERE id = @id;", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@categoria", categoria);
                Banco.Comando.Parameters.AddWithValue("@id", id);

                Banco.Comando.ExecuteNonQuery();
                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Excluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("USE vendas;", Banco.Conexao);
                Banco.Comando.ExecuteNonQuery();

                Banco.Comando = new MySqlCommand("DELETE FROM categorias WHERE id = @id;", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@id", id);
                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable Consultar()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("USE vendas;", Banco.Conexao);
                Banco.Comando.ExecuteNonQuery();

                Banco.Comando = new MySqlCommand("SELECT * FROM categorias WHERE categoria like @categoria " +
                                                 "order by categoria;", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@categoria", categoria + "%");

                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);

                Banco.FecharConexao();
                return Banco.datTabela;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }

}
