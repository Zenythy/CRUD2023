using ControleAcesso;
using ControleAcesso.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ControleAcesso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost(Name = "Autenticar")]
        public HttpStatusCode Post(string usuario, string senha)
        {
            var user = new Repository.Usuario();

            if (user.Autenticar(usuario, senha))
            {

                return HttpStatusCode.OK;

            }
            else {

                return HttpStatusCode.NotFound;
            
            }
            

        }

        [HttpGet(Name = "Autenticar")]
        public bool Get(string Usuario, string senha)
        {

            return true;

        }
    }
}


