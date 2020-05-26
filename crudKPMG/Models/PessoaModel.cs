using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace crudKPMG.Models
{
    public class PessoaModel : IDisposable
    {
        private SqlConnection connection;

        public PessoaModel()
        {
            string strConn = "Data Source=localhost;Initial Catalog=BDCrud;Integrated Security=true";
            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void Create(Pessoa Pessoa)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO Pessoa VALUES (@nome, @email, @DDD, @Telefone, @Endereco, @Num_endereco)";

            cmd.Parameters.AddWithValue("@nome", Pessoa.Nome);
            cmd.Parameters.AddWithValue("@email", Pessoa.Email);
            cmd.Parameters.AddWithValue("@DDD", Pessoa.DDD);
            cmd.Parameters.AddWithValue("@Telefone", Pessoa.Telefone);
            cmd.Parameters.AddWithValue("@Endereco", Pessoa.Endereco);
            cmd.Parameters.AddWithValue("@Num_endereco", Pessoa.Num_endereco);

            cmd.ExecuteNonQuery();
        }

        public List<Pessoa> Read()
        {

            List<Pessoa> lista = new List<Pessoa>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM Pessoa";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Pessoa Pessoa = new Pessoa();
                Pessoa.Id           = (int)reader["ID"];
                Pessoa.Nome         = (string)reader["Nome"];
                Pessoa.Email        = (string)reader["Email"];
                Pessoa.DDD          = (int)reader["DDD"];
                Pessoa.Telefone     = (int)reader["Telefone"];
                Pessoa.Endereco     = (string)reader["Endereco"];
                Pessoa.Num_endereco = (int)reader["Num_endereco"];

                lista.Add(Pessoa);
            }

            return lista;
        }

        public void Update(Pessoa Pessoa)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE Pessoa SET Nome=@Nome, Email=@Email WHERE Id=@Id, DDD=@DDD, Telefone=@Telefone, Endereco=@Endereco, Num_endereco=@Num_endereco where Id=@Id";

            cmd.Parameters.AddWithValue("@Nome", Pessoa.Nome);
            cmd.Parameters.AddWithValue("Nemail", Pessoa.Email);
            cmd.Parameters.AddWithValue("@Id", Pessoa.Id);
            cmd.Parameters.AddWithValue("@DDD", Pessoa.DDD);
            cmd.Parameters.AddWithValue("@Telefone", Pessoa.Telefone);
            cmd.Parameters.AddWithValue("@Endereco", Pessoa.Endereco);
            cmd.Parameters.AddWithValue("@Num_endereco", Pessoa.Num_endereco);


            cmd.ExecuteNonQuery();
        }

        public void Delete(int Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE FROM Pessoa WHERE Id=@Id";

            cmd.Parameters.AddWithValue("@Id", Id);

            cmd.ExecuteNonQuery();
        }

    }
}