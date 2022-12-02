using AutoMapper;
using Entidades;
using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.ModeloDeVisualizacao;
using PocApi.Compartilhado.ModeloDeVisualizacao.DocumetoAReceber;
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
                .ReverseMap();
            CreateMap<PedidoAlterarViewModel, PedidoDTO>()
                .ReverseMap();

            CreateMap<PedidoDTO, Pedido>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.ClienteDTO))
                .ForMember(dest => dest.ItensPedido, opt => opt.MapFrom(src => src.ItemPedidoDTO))
                .ForMember(dest => dest.PedidosPagamento, opt => opt.MapFrom(src => src.PedidosPagamentoDTO));

            CreateMap<Pedido, PedidoDTO>()
                .ForMember(dest => dest.ClienteDTO, opt => opt.MapFrom(src => src.Cliente));

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
            CreateMap<PagamentoInserirViewModel, PagamentoDTO>()
                .ReverseMap();
            CreateMap<PagamentoAlterarViewModel, PagamentoDTO>()
                .ReverseMap();

            CreateMap<PedidoPagamentoViewModel, PedidoPagamentoDTO>()
                .ReverseMap();
            CreateMap<PedidoPagamentoDTO, PedidoPagamento>()
                .ReverseMap();

            CreateMap<ItemPedidoViewModel, ItemPedidoDTO>()
                .ReverseMap();
            CreateMap<ItemPedidoDTO, ItemPedido>()
                .ReverseMap();

            CreateMap<DocumentoAReceberInserirViewModel, DocumentoAReceberDTO>()
                .ReverseMap();
            CreateMap<DocumentoAReceberDTO, DocumentoAReceber>()
                .ReverseMap();
        }
    }
}