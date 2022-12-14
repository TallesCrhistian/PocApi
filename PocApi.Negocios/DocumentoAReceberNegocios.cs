using AutoMapper;
using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.Enumeradores;
using PocApi.Data.Interfaces;
using PocApi.Entidades;
using PocApi.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocApi.Negocios
{
    public class DocumentoAReceberNegocios : IDocumentoAReceberNegocios
    {
        private readonly IDocumentoAReceberRepositorio _documentoAReceberRepositorio;
        private readonly IMapper _mapper;

        public DocumentoAReceberNegocios(IDocumentoAReceberRepositorio documentoAReceberRepositorio, IMapper mapper)
        {
            _documentoAReceberRepositorio = documentoAReceberRepositorio;
            _mapper = mapper;
        }

        public async Task<DocumentoAReceberDTO> Inserir(DocumentoAReceberDTO documentoAReceberDTO)
        {
            DocumentoAReceber documentoAReceber = _mapper.Map<DocumentoAReceber>(documentoAReceberDTO);
            await _documentoAReceberRepositorio.Inserir(documentoAReceber);
            return _mapper.Map<DocumentoAReceberDTO>(documentoAReceber);
        }

        public List<DocumentoAReceberDTO> CriarDocumentoAReceberDTO(PedidoDTO pedidoDTO)
        {
            DateTime datavencimento = DateTime.Now;
            List<DocumentoAReceberDTO> documentoAReceberDTO = new List<DocumentoAReceberDTO>();
            foreach (PedidoPagamentoDTO pedidoPagamentoDTO in pedidoDTO.PedidosPagamentoDTO.Where(x => x.PagamentoDTO.PagamentoForma == PagamentoFormaEnum.Crediario).ToList())
            {
                decimal valorRestante = pedidoPagamentoDTO.Valor;
                decimal valorParcela = valorRestante / pedidoPagamentoDTO.PagamentoDTO.Parcelas;
                DateTime ultimoVencimento = datavencimento;
                for (int numeroParcela = 1; numeroParcela <= pedidoPagamentoDTO.PagamentoDTO.Parcelas; numeroParcela++)
                {
                    decimal valor = (numeroParcela != pedidoPagamentoDTO.PagamentoDTO.Parcelas) ? valorParcela : valorRestante;
                    ultimoVencimento = ultimoVencimento.AddDays(pedidoPagamentoDTO.PagamentoDTO.DiasPagamento);
                    DocumentoAReceberDTO _documentoAReceberDTO = new DocumentoAReceberDTO
                    {
                        IdCliente = pedidoDTO.IdCliente,
                        QuantidadeParcela = pedidoPagamentoDTO.PagamentoDTO.Parcelas,
                        NumeroParcela = numeroParcela,
                        DataLancamento = pedidoPagamentoDTO.DataLancamento,
                        DataVencimento = ultimoVencimento,
                        DataJuros = ultimoVencimento,
                        Carencia = pedidoPagamentoDTO.PagamentoDTO.DiasCarencia,
                        Valor = valor,
                        Restante = valor,
                        PercentualJuros = pedidoPagamentoDTO.PagamentoDTO.ValorJuros,
                        ValorPago = 0
                    };
                    valorRestante -= valor;
                    documentoAReceberDTO.Add(_documentoAReceberDTO);
                }
            }

            return documentoAReceberDTO;
        }
    }
}