using AutoMapper;
using NSubstitute;
using PocApi.API.Controllers;
using PocApi.Aplicacao.Servicos;
using PocApi.Compartilhado.DTOs;
using PocApi.Compartilhado.ModeloDeVisualizacao;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PocAPI.Test
{
    public class TestaClienteControllerInserir
    {
        private readonly IClienteServicos _iclienteServicos;
        private readonly ClienteController _clienteController;
        private readonly ClienteDTO _clienteDTO;
        private readonly ClienteViewModel _clienteViewModel;
        private readonly IMapper _mapper;

        public TestaClienteControllerInserir()
        {
            _iclienteServicos = Substitute.For<IClienteServicos>();
            _clienteController = new ClienteController(_iclienteServicos, _mapper);
            _clienteDTO = new ClienteDTO { Cpf = "123456", Nome = "Talles", SobreNome = "Arriel" };
            _clienteViewModel = new ClienteViewModel { Cpf = "123456", Nome = "Talles", SobreNome = "Arriel" };
        }

        [Fact]
        public async Task<RespostaServicoDTO<ClienteDTO>> AdicionaClienteComSucesso()
        {
            RespostaServicoDTO<ClienteDTO> respostaServicoDTO = await _iclienteServicos.Inserir(_clienteDTO);

            var resposta = _clienteController.Inserir(_clienteViewModel);

            Assert.NotNull(resposta);

            return respostaServicoDTO;
        }
    }
}