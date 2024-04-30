using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Data.SqlClient;
namespace Csharp2904
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sql;
            MySqlCommand cmd;
            string connectionString = "Server=192.168.8.10;Port=3306;Database=grupo05;Uid=root;Pwd='password';";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // Exemplo de consulta
                sql = "SELECT * FROM login";
                cmd = new MySqlCommand(sql, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader["usuario"]);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();

            Console.WriteLine("Inserir Dados\n\n");

            sql = "insert into login(usuario,senh) values(@usuario,@senha)";
            cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@usuario", "teste1");
            cmd.Parameters.AddWithValue("@senha", "teste2");

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new Exception("Nenhuma linha foi afetada pela consulta.");
                }
                else
                {
                    Console.WriteLine("Linhas afetadas:", rowsAffected);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro:", ex.Message);
            }


            Console.ReadKey();
        }
    }
}