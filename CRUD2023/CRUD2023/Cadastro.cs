using CRUD_DTO;
using CRUD_BUSINESS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD2023
{
    public class Cadastro
    {
        PessoaBLL p = new PessoaBLL();
        public bool Cadastrar(Pessoa_DTO pessoa)
        {

            return p.Cadastro(pessoa);

        }

    }
}
