namespace ControleAcesso.Model
{
    public class Usuario
    {
        public int id { get; set; }
        public string login { get; set;}
        public string senha { get; set;}
        public bool ativo { get; set;}
        public DateTime validade { get;set; }
        public string email { get; set;}
    }
}
