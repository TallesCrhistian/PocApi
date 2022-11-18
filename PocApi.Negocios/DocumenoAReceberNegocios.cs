using AutoMapper;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Interfaces;
using PocApi.Entidades;
using PocApi.Negocios.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Negocios
{
    public class DocumenoAReceberNegocios : IDocumentoAReceberNegocios
    {
        private readonly IDocumentoAReceberRepositorio _documentoAReceberRepositorio;
        private readonly IPagamentoNegocios _pagamentoNegocios;
        private readonly IMapper _mapper;

        public DocumenoAReceberNegocios(IDocumentoAReceberRepositorio documentoAReceberRepositorio, IMapper mapper)
        {
            _documentoAReceberRepositorio = documentoAReceberRepositorio;
            _mapper = mapper;
        }
        public async Task<DocumentoAReceberDTO> Inserir(PedidoDTO pedidoDTO)
        {
            DocumentoAReceber documentoAReceber = await ReceberValores(pedidoDTO);

            documentoAReceber = _mapper.Map<DocumentoAReceber>(documentoAReceber);
            documentoAReceber = await _documentoAReceberRepositorio.Inserir(documentoAReceber);
            return _mapper.Map<DocumentoAReceberDTO>(documentoAReceber);
        }


        public async Task<DocumentoAReceber> ReceberValores(PedidoDTO pedidoDTO)
        {
           // PagamentoDTO pagamento = await _pagamentoNegocios.ObterPorCodigo(pedidoDTO);
            DocumentoAReceber documentoAReceber = new DocumentoAReceber();
            documentoAReceber.IdCliente = pedidoDTO.IdCliente;
            documentoAReceber.IdPedido = pedidoDTO.IdPedido;
            documentoAReceber.Valor = pedidoDTO.ValorProdutos;
            documentoAReceber.QuantidadeParcela = pagamento.Parcelas;
            return documentoAReceber;
        }
    }
}

