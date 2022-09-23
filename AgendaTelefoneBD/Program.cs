using System;
using System.Data.SqlClient;

namespace AgendaTelefoneBD
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Nome: ");
            string n = Console.ReadLine();

            Console.WriteLine("Apelido: ");
            string a = Console.ReadLine();

            Console.WriteLine("Telefone: ");
            string t = Console.ReadLine();

            Console.WriteLine("Email: ");
            string e = Console.ReadLine();

            Contato c = new(n, a, t, e);

            #region Conexao com o Banco
            Banco conn = new Banco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();
            #endregion
            #region Inserir
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Contatos(Nome, Telefone, Apelido, Email) VALUES (@Nome, @Telefone, @Apelido, @Email);";

            SqlParameter nome = new SqlParameter("@Nome", System.Data.SqlDbType.VarChar, 50);
            SqlParameter telefone = new SqlParameter("@Telefone", System.Data.SqlDbType.VarChar, 11);
            SqlParameter apelido = new SqlParameter("@Apelido", System.Data.SqlDbType.VarChar, 50);
            SqlParameter email = new SqlParameter("@Email", System.Data.SqlDbType.VarChar, 50);

            nome.Value = c.Nome;
            telefone.Value = c.Telefone;
            apelido.Value = c.Apelido;
            email.Value = c.Email;

            cmd.Parameters.Add(nome);
            cmd.Parameters.Add(telefone);
            cmd.Parameters.Add(apelido);
            cmd.Parameters.Add(email);

            cmd.Connection = conexaosql;
            cmd.ExecuteNonQuery();

            conexaosql.Close();
            #endregion

            cmd = new SqlCommand();

            cmd.CommandText = "SELECT ID, Nome, Telefone, Apelido, Email FROM Contatos";

            cmd.Connection = conexaosql;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine("{0}", reader.GetInt32(0));
                    Console.WriteLine("{0}", reader.GetString(1));
                    Console.WriteLine("{0}", reader.GetString(2));
                    Console.WriteLine("{0}", reader.GetString(3));
                    Console.WriteLine("{0}", reader.GetString(4));
                }
            }
            conexaosql.Close();
        }
    }
}
