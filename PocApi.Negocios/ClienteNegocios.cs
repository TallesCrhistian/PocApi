using PocApi.Compartilhado.DTOs;
using PocApi.Data.Entidades;
using PocApi.Data.Interfaces;
using PocApi.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocApi.Negocios
{
    public class ClienteNegocios : IClienteNegocios
    {
        private IClienteRepositorio _clienteRepositorio;
        public ClienteNegocios(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        public async Task<ClienteDTO> Alterar(ClienteDTO clienteDTO)
        {
            throw new NotImplementedException();
        }


        public async Task<ClienteDTO> Inserir(ClienteDTO clienteDTO)
        {
            Cliente cliente = await _clienteRepositorio.Inserir(new Cliente());
            ClienteDTO _clienteDTO = new ClienteDTO {IdCliente=cliente.IdCliente, Nome = cliente.Nome };
            return _clienteDTO;

        }

        public async Task<List<ClienteDTO>> Listar(ClienteFiltroDTO clienteDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<ClienteDTO> ObterPorCodigo(int codigo)
        {
            throw new NotImplementedException();
        }
    }
}
