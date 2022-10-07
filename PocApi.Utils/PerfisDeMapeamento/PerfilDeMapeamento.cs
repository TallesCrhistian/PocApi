using AutoMapper;
using Entidades;
using PocApi.Compartilhado.DTOs;

namespace PocApi.Utils.PerfisDeMapeamento
{
    public class PerfilDeMapeamento : Profile
    {
        public PerfilDeMapeamento()
        {
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
        }
    }
}
