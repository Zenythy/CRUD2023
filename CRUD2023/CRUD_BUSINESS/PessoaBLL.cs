using CRUD_DTO;
using CRUD_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_BUSINESS
{
    public class PessoaBLL
    {
        CRUD_DAO.PessoaDAL pessoaDAL = new CRUD_DAO.PessoaDAL();

        public bool Cadastro(Pessoa_DTO pessoa) {

         return pessoaDAL.Cadastro(pessoa);

        }

        public bool Editar(Pessoa_DTO pessoa) { 
        
            return pessoaDAL.Editar(pessoa);
        
        }

        public bool Deletar(int id_pessoa) {

            return pessoaDAL.Deletar(id_pessoa);
        
        }

    }
}
