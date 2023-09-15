using CRUD_DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DAO
{
    public class PessoaDAL
    {
        Conexao conexao = new Conexao();
        


        public bool Cadastro(Pessoa_DTO pessoa)

        {
            SqlCommand cmd = new SqlCommand();

            // Pegando os parametros
            cmd.Parameters.AddWithValue("@nome", pessoa.nome);
            cmd.Parameters.AddWithValue("@sexo", pessoa.sexo);
            cmd.Parameters.AddWithValue("@email", pessoa.email);
            cmd.Parameters.AddWithValue("@cpf", pessoa.cpf);
            cmd.Parameters.AddWithValue("@telefone", pessoa.telefone);
            cmd.Parameters.AddWithValue("@endereco", pessoa.endereco.rua);
            cmd.Parameters.AddWithValue("@cidade", pessoa.endereco.cidade);
            cmd.Parameters.AddWithValue("@estado", pessoa.endereco.estado);

            // Comando sql -- sqlCommand -- insert
            cmd.CommandText = "insert into clientes(nome, sexo, email, cpf, telefone, endereco, cidade, estado)" +
                              "values(@nome, @sexo, @email, @cpf, @telefone, @endereco, @cidade, @estado)";


            // Conectar com o banco de dados -- Conexao
            try
            {
                cmd.Connection = conexao.conectar();

                // Executar comando

                cmd.ExecuteNonQuery();

                // Desconectar

                conexao.desconectar();

                // Menssagem de erro ou sucesso -- variavel

                //this.mensagem = "Cadastrado com Sucesso!";


            }
            catch (SqlException e)
            {

                //this.mensagem = $"{e.Message} Erro ao Tentar se Conectar com o Banco de Dados!";

                return false;
            }

            return true;

        }

        public bool Editar(Pessoa_DTO pessoa)
        {
            SqlCommand cmd = new SqlCommand();

            // Comando sql -- sqlCommand -- update
            cmd.CommandText = "update clientes " +
                              "set nome = @nome, sexo = @sexo, email = @email, " +
                              "cpf = @cpf, telefone = @telefone, endereco = @endereco, " +
                              "cidade = @cidade, estado = @estado " +
                              "where id_cliente = @id_cliente";  // Assuming there's an 'id' field for identifying the record

            // Adicionar os parâmetros
            cmd.Parameters.AddWithValue("@id_cliente", pessoa.id);  // Assuming you have an 'id' property in Pessoa_DTO
            cmd.Parameters.AddWithValue("@nome", pessoa.nome);
            cmd.Parameters.AddWithValue("@sexo", pessoa.sexo);
            cmd.Parameters.AddWithValue("@email", pessoa.email);
            cmd.Parameters.AddWithValue("@cpf", pessoa.cpf);
            cmd.Parameters.AddWithValue("@telefone", pessoa.telefone);
            cmd.Parameters.AddWithValue("@endereco", pessoa.endereco.rua);
            cmd.Parameters.AddWithValue("@cidade", pessoa.endereco.cidade);
            cmd.Parameters.AddWithValue("@estado", pessoa.endereco.estado);

            // Conectar com o banco de dados -- Conexao
            try
            {
                cmd.Connection = conexao.conectar();

                // Executar comando
                cmd.ExecuteNonQuery();

                // Desconectar
                conexao.desconectar();

                // Mensagem de erro ou sucesso -- variável
                // this.mensagem = "Atualizado com Sucesso!";
            }
            catch (SqlException e)
            {
                // this.mensagem = $"{e.Message} Erro ao Tentar se Conectar com o Banco de Dados!";
                return false;
            }

            return true;
        }

        public bool Deletar(int  id_pessoa)
        {
            SqlCommand cmd = new SqlCommand();

            // Comando sql -- sqlCommand -- update
            cmd.CommandText = "DELETE FROM clientes WHERE id_cliente = @id_cliente";


            // Adicionar os parâmetros
            cmd.Parameters.AddWithValue("@id_cliente", id_pessoa);  // Assuming you have an 'id' property in Pessoa_DTO
            

            // Conectar com o banco de dados -- Conexao
            try
            {
                cmd.Connection = conexao.conectar();

                // Executar comando
                cmd.ExecuteNonQuery();

                // Desconectar
                conexao.desconectar();

                
            }
            catch (SqlException e)
            {
                // this.mensagem = $"{e.Message} Erro ao Tentar se Conectar com o Banco de Dados!";
                return false;
            }

            return true;
        }


    }

}
