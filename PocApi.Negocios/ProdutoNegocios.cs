﻿using AutoMapper;
using Entidades;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Interfaces;
using PocApi.Negocios.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Negocios
{
    public class ProdutoNegocios : IProdrutoNegocios
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;
        public ProdutoNegocios(IProdutoRepositorio produtoRepositorio, IMapper mapper)
        {
            _produtoRepositorio = produtoRepositorio;
            _mapper = mapper;
        }

        public async Task<ProdutoDTO> Alterar(ProdutoDTO produtoDTO)
        {
            Produto produto = _mapper.Map<Produto>(produtoDTO);
            produto = await _produtoRepositorio.Alterar(produto);
            return _mapper.Map<ProdutoDTO>(produto);
        }

        public async Task<ProdutoDTO> Deletar(int codigo)
        {
            Produto produto = await _produtoRepositorio.Deletar(codigo);
            ProdutoDTO produtoDTO = (produto != null) ? _mapper.Map<ProdutoDTO>(produto) : new ProdutoDTO();
            return produtoDTO;
        }

        public async Task<ProdutoDTO> Inserir(ProdutoDTO produtoDTO)
        {
            Produto produto = _mapper.Map<Produto>(produtoDTO);
            produto = await _produtoRepositorio.Inserir(produto);
            return _mapper.Map<ProdutoDTO>(produto);
        }

        public async Task<List<ProdutoDTO>> Listar(ProdutoFiltroDTO produtoFiltroDTO)
        {
            List<Produto> produtos = await _produtoRepositorio.Listar(produtoFiltroDTO);
            List<ProdutoDTO> produtoDTO = _mapper.Map<List<ProdutoDTO>>(produtos);
            
            return produtoDTO;
        }

        public async Task<ProdutoDTO> ObterPorCodigo(int codigo)
        {
            Produto produto = await _produtoRepositorio.ObterPorCodigo(codigo);
            ProdutoDTO produtoDTO = (produto != null) ? _mapper.Map<ProdutoDTO>(produto) : new ProdutoDTO();
            return produtoDTO;
        }
    }
}
