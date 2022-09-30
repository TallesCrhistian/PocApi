namespace PocApi.Compartilhado.DTOs
{
    public class ClienteFiltroDTO
    {
        public int IdCliente { get; set; }
        public bool? Ativo { get; set; } = true;
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Cpf { get; set; }
        public int Pagina { get; set; }
        public int ItensPorPagina { get; set; }
    }
}

