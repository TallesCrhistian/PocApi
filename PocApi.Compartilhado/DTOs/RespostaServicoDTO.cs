using System;
using System.Collections.Generic;
namespace PocApi.Compartilhado.DTOs
{
    public class RespostaServicoDTO
    {
        public class RespostaServico<T>
        {
            public T Dados { get; set; }
            public bool Sucesso { get; set; } = true;
            public string Mensagem { get; set; }
        }
    }
}
