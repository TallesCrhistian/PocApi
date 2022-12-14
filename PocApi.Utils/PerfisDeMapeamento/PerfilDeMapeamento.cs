using AutoMapper;
using Entidades;
using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.ModeloDeVisualizacao;
using PocApi.Compartilhado.ModeloDeVisualizacao.DocumetoAReceber;
using PocApi.Compartilhado.ModeloDeVisualizacao.Pagamento;
using PocApi.Entidades;

namespace PocApi.Utils.PerfisDeMapeamento
{
    public class PerfilDeMapeamento : Profile
    {
        public PerfilDeMapeamento()
        {
            CreateMap<ClienteViewModel, ClienteDTO>()
                .ReverseMap();
            CreateMap<ClienteDTO, Cliente>()
                .ReverseMap();

            CreateMap<PedidoInserirViewModel, PedidoDTO>()
                .ForMember(dest => dest.PedidosPagamentoDTO, opt => opt.MapFrom(src => src.PedidoPagamentoViewModels))
                .ForMember(dest => dest.ItemPedidoDTO, opt => opt.MapFrom(src => src.ItemPedidoViewModels));

            CreateMap<PedidoDTO, PedidoInserirViewModel>()
                .ForMember(dest => dest.PedidoPagamentoViewModels, opt => opt.MapFrom(src => src.PedidosPagamentoDTO))
                .ForMember(dest => dest.ItemPedidoViewModels, opt => opt.MapFrom(src => src.ItemPedidoDTO));

            CreateMap<PedidoDTO, Pedido>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.ClienteDTO))
                .ForMember(dest => dest.PedidosPagamento, opt => opt.MapFrom(src => src.PedidosPagamentoDTO))
                .ForMember(dest => dest.ItensPedido, opt => opt.MapFrom(src => src.ItemPedidoDTO))
                .ForMember(dest => dest.DocumentoAReceber, opt => opt.MapFrom(src => src.DocumentoAReceberDTO));

            CreateMap<Pedido, PedidoDTO>()
                .ForMember(dest => dest.ClienteDTO, opt => opt.MapFrom(src => src.Cliente))
                .ForMember(dest => dest.PedidosPagamentoDTO, opt => opt.MapFrom(src => src.PedidosPagamento))
                .ForMember(dest => dest.ItemPedidoDTO, opt => opt.MapFrom(src => src.ItensPedido))
                .ForMember(dest => dest.DocumentoAReceberDTO, opt => opt.MapFrom(src => src.DocumentoAReceber));

            CreateMap<PedidoPagamentoViewModel, PedidoPagamentoDTO>()
                .ForMember(dest => dest.PagamentoDTO, opt => opt.MapFrom(src => src.PagamentoViewModel));

            CreateMap<PedidoPagamentoDTO, PedidoPagamento>()
                .ReverseMap();

            CreateMap<UsuarioInserirViewModel, UsuarioDTO>()
                .ReverseMap();
            CreateMap<UsuarioDTO, Usuario>()
                .ReverseMap();

            CreateMap<ProdutoInserirViewModel, ProdutoDTO>()
                .ReverseMap();
            CreateMap<ProdutoDTO, Produto>()
                .ReverseMap();
            CreateMap<ProdutoAlterarViewModel, ProdutoDTO>()
                .ReverseMap();
            CreateMap<ProdutoFiltroViewModel, ProdutoFiltroDTO>()
                .ReverseMap();
            CreateMap<ProdutoFiltroDTO, Produto>()
                .ReverseMap();

            CreateMap<PagamentoDTO, Pagamento>()
                .ReverseMap();
            CreateMap<PagamentoViewModel, PagamentoDTO>()
                .ReverseMap();
            CreateMap<PagamentoInserirViewModel, PagamentoDTO>()
                .ReverseMap();
            CreateMap<PagamentoAlterarViewModel, PagamentoDTO>()
                .ReverseMap();

            CreateMap<ItemPedidoViewModel, ItemPedidoDTO>()
                .ReverseMap();
            CreateMap<ItemPedidoDTO, ItemPedido>()
                .ReverseMap();

            CreateMap<DocumentoAReceberViewModel, DocumentoAReceberDTO>()
                .ReverseMap();
            CreateMap<DocumentoAReceberDTO, DocumentoAReceber>()
                .ReverseMap();
        }
    }
}