using AutoMapper;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Interfaces;
using PocApi.Entidades;
using PocApi.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Negocios
{
    public class DocumentoAReceberNegocios : IDocumentoAReceberNegocios
    {
        private readonly IDocumentoAReceberRepositorio _documentoAReceberRepositorio;
        private readonly IPagamentoNegocios _pagamentoNegocios;
        private readonly IMapper _mapper;

        public DocumentoAReceberNegocios(IDocumentoAReceberRepositorio documentoAReceberRepositorio, IMapper mapper)
        {
            _documentoAReceberRepositorio = documentoAReceberRepositorio;
            _mapper = mapper;
        }
        public async Task<DocumentoAReceberDTO> Inserir(PagamentoDTO pagamentoDTO)
        {
            DocumentoAReceber documentoAReceber = await ReceberValores(pagamentoDTO);

            documentoAReceber = await _documentoAReceberRepositorio.Inserir(documentoAReceber);
            return _mapper.Map<DocumentoAReceberDTO>(documentoAReceber);
        }
        public async Task<DocumentoAReceber> ReceberValores(PagamentoDTO pagamentoDTO)
        {
            DocumentoAReceberDTO documentoAReceberDTO = new DocumentoAReceberDTO();
            documentoAReceberDTO.IdPagamento = pagamentoDTO.IdPagamento;
           // documentoAReceberDTO.IdCliente = pagamentoDTO.PedidoDTO.IdCliente;
           // documentoAReceberDTO.IdPedido = pagamentoDTO.PedidoDTO.IdPedido;
            documentoAReceberDTO.QuantidadeParcela = pagamentoDTO.Parcelas;
            documentoAReceberDTO.Carencia = pagamentoDTO.DiasCarencia;
            documentoAReceberDTO.DataJuros = DateTime.Now;
            documentoAReceberDTO.Restante = documentoAReceberDTO.Valor - documentoAReceberDTO.ValorPago;
           // documentoAReceberDTO.Valor = pagamentoDTO.PedidoDTO.ValorProdutos;

            return _mapper.Map<DocumentoAReceber>(documentoAReceberDTO);

        }
    }
}

