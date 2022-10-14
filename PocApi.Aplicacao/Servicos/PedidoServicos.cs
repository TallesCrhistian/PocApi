﻿using PocApi.Aplicacao.Interfaces;
using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.Menssagens;
using PocApi.Data.Interfaces;
using PocApi.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Servicos
{
    public class PedidoServicos : IPedidoServicos
    {
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        private readonly IPedidoNegocios _pedidoNegocios;
        private readonly IClienteNegocios _clienteNegocios;
        public PedidoServicos(IUnidadeDeTrabalho unidadeDeTrabalho, IPedidoNegocios pedidoNegocios,IClienteNegocios clienteNegocios)
        {
            _clienteNegocios = clienteNegocios;
            _pedidoNegocios = pedidoNegocios;
            _unidadeDeTrabalho = unidadeDeTrabalho;
        }
        public async Task<RespostaServicoDTO<PedidoDTO>> Inserir(PedidoDTO pedidoDTO)
        {
            RespostaServicoDTO<PedidoDTO> respostaServicoDTO = new RespostaServicoDTO<PedidoDTO>();
            try
            {
                if(! await Validar(respostaServicoDTO, pedidoDTO))
                {
                    return respostaServicoDTO;
                }

                respostaServicoDTO.Dados = await _pedidoNegocios.Inserir(pedidoDTO);
                await _unidadeDeTrabalho.CommitAsync();
            }
            catch (Exception ex)
            {
                respostaServicoDTO.Sucesso = false;
                respostaServicoDTO.Mensagem = ex.GetBaseException().Message;
                _unidadeDeTrabalho.Rollback();
            }
            return respostaServicoDTO;

        }


        public async Task<bool> Validar(RespostaServicoDTO<PedidoDTO> respostaServicoDTO, PedidoDTO pedidoDTO)
        {
            bool pedidoValido = true; 
            ClienteDTO clienteDTO = await _clienteNegocios.ObterPorCodigo(pedidoDTO.ClienteDTO.IdCliente);
            if(clienteDTO == null || clienteDTO.IdCliente == 0)
            {
                respostaServicoDTO.Mensagem = ConstantesMensagens.ClienteNaoLocalizado;
                pedidoValido = false;
            }
            return pedidoValido;
        }
        public async Task<RespostaServicoDTO<List<PedidoDTO>>> Listar(PedidoFiltroDTO pedidoFiltroDTO)
        {
            RespostaServicoDTO<List<PedidoDTO>> respostaServicoDTO = new RespostaServicoDTO<List<PedidoDTO>>();
            try
            {
                respostaServicoDTO.Dados = await _pedidoNegocios.Listar(pedidoFiltroDTO);

            }
            catch (Exception ex)
            {
                respostaServicoDTO.Sucesso = false;
                respostaServicoDTO.Mensagem = ex.GetBaseException().Message;
            }
            return respostaServicoDTO;
        }
    }
}
