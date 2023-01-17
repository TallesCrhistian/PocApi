using System.ComponentModel;

namespace PocApi.Compartilhado.Enumeradores
{
    public enum TipoPesquisaClienteEnum
    {
        [Description("Id")]
        Id = 1,

        [Description("Nome")]
        Nome = 2,

        [Description("Sobre nome")]
        SobreNome = 3,

        [Description("Cpf")]
        Cpf = 4
    }
}