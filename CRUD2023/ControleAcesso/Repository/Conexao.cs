

using System.Data.SqlClient;

namespace ControleAcesso.Repository
{
    public class Conexao
    {

        SqlConnection con = new SqlConnection();

        //Construtor
        public Conexao()
        {
            con.ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Controle_Acesso;Integrated Security=True";
        }

        //Metodo conectar
        public SqlConnection conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        //Metodo desconectar
        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}

