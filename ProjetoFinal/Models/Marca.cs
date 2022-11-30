using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoFinal.Models
{
    public class Marca
    {
        public int id { get; set; }

        public string marca { get; set; }

        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("USE vendas;", Banco.Conexao);
                Banco.Comando.ExecuteNonQuery();

                Banco.Comando = new MySqlCommand("INSERT INTO cidades (marca) VALUES (@marca);", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@marca", marca);

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

                Banco.Comando = new MySqlCommand("UPDATE marcas SET marca = @marca " +
                                                 "WHERE id = @id;", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@marca", marca);
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

                Banco.Comando = new MySqlCommand("DELETE FROM marcas WHERE id = @id;", Banco.Conexao);
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

                Banco.Comando = new MySqlCommand("SELECT * FROM marcas WHERE marca like @marca " +
                                                 "order by marca;", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@marca", marca + "%");

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
