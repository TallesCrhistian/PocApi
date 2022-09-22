namespace PocApi.Compartilhado.DTOs
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public bool Ativo { get; set; } = true;
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Cpf { get; set; }
    }
}
