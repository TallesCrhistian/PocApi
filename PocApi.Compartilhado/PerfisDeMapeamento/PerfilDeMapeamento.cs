using AutoMapper;
using Entidades;
using PocApi.Compartilhado.DTOs;

namespace PocApi.Compartilhado.PerfisDeMapeamento
{
    public class PerfilDeMapeamento : Profile
    {
        public PerfilDeMapeamento()
        {
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
        }
    }
}
