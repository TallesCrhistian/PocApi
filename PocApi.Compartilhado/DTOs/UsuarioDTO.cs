namespace PocApi.Compartilhado.DTOs
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string EMail { get; set; }
        public bool Ativo { get; set; }
    }
}
