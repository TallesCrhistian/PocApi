using PocApi.Aplicacao.Interfaces;
using PocApi.Compartilhado.DTOs;
using PocApi.Data.Interfaces;
using PocApi.Negocios.Interfaces;
using System;
using System.Threading.Tasks;

namespace PocApi.Aplicacao.Servicos
{
    public class PedidoServicos : IPedidoServicos
    {
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        private readonly IPedidoNegocios _pedidoNegocios;
        public PedidoServicos(IUnidadeDeTrabalho unidadeDeTrabalho, IPedidoNegocios pedidoNegocios)
        {
            _pedidoNegocios = pedidoNegocios;
            _unidadeDeTrabalho = unidadeDeTrabalho;
        }
        public async Task<RespostaServicoDTO<PedidoDTO>> Iserir(PedidoDTO pedidoDTO)
        {
            RespostaServicoDTO<PedidoDTO> respostaServicoDTO = new RespostaServicoDTO<PedidoDTO>();
            try
            {
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
    }
}
