using System.Data.SqlClient;

namespace ControleAcesso.Repository
{
    public class Usuario
    {

        Conexao conexao = new Conexao();

        public bool Autenticar(string usuario, string senha)
        {
            using (SqlConnection conexao = new SqlConnection(@"Data Source=localhost\\SQLEXPRESS;Initial Catalog=Controle_Acesso;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexao;

                // Evitar la inyección SQL utilizando parámetros
                cmd.CommandText = "SELECT * FROM Usuario WHERE login = @usuario AND senha = @senha";
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@senha", senha);

                try
                {
                    conexao.Open();

                    // Utiliza ExecuteReader para verificar si las credenciales son válidas
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // Las credenciales son válidas
                            return true;
                        }
                        else
                        {
                            // Las credenciales son inválidas
                            return false;
                        }
                    }
                }
                catch (SqlException e)
                {
                    // Manejar la excepción aquí o simplemente dejar que se propague
                    throw e;
                }
            }
        }
    }
}

