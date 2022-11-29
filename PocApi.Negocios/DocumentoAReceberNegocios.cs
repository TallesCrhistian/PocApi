﻿using AutoMapper;
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
            DocumentoAReceber documentoAReceber = new DocumentoAReceber();
            await _documentoAReceberRepositorio.Inserir(documentoAReceber);
            return _mapper.Map<DocumentoAReceberDTO>(documentoAReceber);
        }
    }
}
