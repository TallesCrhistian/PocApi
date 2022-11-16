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
        private readonly IMapper _mapper;

        public DocumenoAReceberNegocios(IDocumentoAReceberRepositorio documentoAReceberRepositorio, IMapper mapper)
        {
            _documentoAReceberRepositorio = documentoAReceberRepositorio;
            _mapper = mapper;
        }
        public async Task<DocumentoAReceberDTO> Inserir(PedidoDTO pedidoDTO)
        {
            DocumentoAReceber documentoAReceberber = new DocumentoAReceber();
            documentoAReceberber.Valor = pedidoDTO.ValorProdutos;
            documentoAReceberber.ValorPago = pedidoDTO.Frete;
            documentoAReceberber = _mapper.Map<DocumentoAReceber>(documentoAReceberber);
            documentoAReceberber = await _documentoAReceberRepositorio.Inserir(documentoAReceberber);
            return _mapper.Map<DocumentoAReceberDTO>(documentoAReceberber);
        }        
    }
}

