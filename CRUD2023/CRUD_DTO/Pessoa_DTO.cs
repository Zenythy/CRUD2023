using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DTO
{
    public class Pessoa_DTO


    {

        public int id { get; set; }
        public String nome { get; set; }
        public String sexo { get; set; }
        public String email { get; set; }
        public String cpf { get; set; }
        public String telefone { get; set; }
        public Endereco_DTO endereco { get; set; }
        

        
    }
    
}
