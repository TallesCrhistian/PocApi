using AutoMapper;
using Entidades;
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
        private readonly IMapper _mapper;
        private IClienteRepositorio _clienteRepositorio;
        public ClienteNegocios(IMapper mapper, IClienteRepositorio clienteRepositorio)
        {
            _mapper = mapper;
            _clienteRepositorio = clienteRepositorio;
        }
        public async Task<ClienteDTO> Alterar(ClienteDTO clienteDTO)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
            cliente = await _clienteRepositorio.Alterar(cliente);
            return _mapper.Map<ClienteDTO>(cliente);
        }


        public async Task<ClienteDTO> Inserir(ClienteDTO clienteDTO)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
            cliente = await _clienteRepositorio.Inserir(cliente);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<List<ClienteDTO>> Listar(ClienteFiltroDTO clienteFiltroDTO)
        {
            List<Cliente> cliente = await _clienteRepositorio.Listar(clienteFiltroDTO);
            List<ClienteDTO> clienteDTO = _mapper.Map<List<ClienteDTO>>(cliente);
            return clienteDTO;
            
        }

        public async Task<ClienteDTO> ObterPorCodigo(int codigo)
        {
            throw new NotImplementedException();
        }
    }
}
