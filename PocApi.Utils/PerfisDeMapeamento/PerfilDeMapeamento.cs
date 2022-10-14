using AutoMapper;
using Entidades;
using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.ModeloDeVisualizacao;

namespace PocApi.Utils.PerfisDeMapeamento
{
    public class PerfilDeMapeamento : Profile
    {
        public PerfilDeMapeamento()
        {
            CreateMap<ClienteViewModel, ClienteDTO>().ReverseMap();
            CreateMap<ClienteDTO, Cliente>().ReverseMap();

            CreateMap<PedidoInserirViewModel, PedidoDTO>().ReverseMap();            

            CreateMap<PedidoDTO, Pedido>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.ClienteDTO));

            CreateMap<Pedido, PedidoDTO>()
                .ForMember(dest => dest.ClienteDTO, opt => opt.MapFrom(src => src.Cliente));

        }
    }
}
