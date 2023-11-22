using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PegaderoDeLaMula.Data;
using PegaderoDeLaMula.Models;
using PegaderoDeLaMula.Models.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PegaderoDeLaMula.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ClienteRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ClienteDto> CreateUpdate(ClienteDto clienteDto)
        {
            Cliente cliente = _mapper.Map<ClienteDto, Cliente>(clienteDto);
            if (cliente.ID_CLIENTE > 0)
            {
                _db.CLIENTE.Update(cliente);
            }
            else
            {
                await _db.CLIENTE.AddAsync(cliente);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Cliente, ClienteDto>(cliente);
        }

        public async Task<bool> DeleteCliente(int id)
        {
            try
            {
                Cliente cliente = await _db.CLIENTE.FindAsync(id);
                if (cliente == null)
                {
                    return false;
                }
                _db.CLIENTE.Remove(cliente);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ClienteDto> GetClienteById(int id)
        {
            Cliente cliente = await _db.CLIENTE.FindAsync(id);

            return _mapper.Map<ClienteDto>(cliente);
        }

        public async Task<List<ClienteDto>> GetClientes()
        {
            List<Cliente> lista = await _db.CLIENTE.ToListAsync();

            return _mapper.Map<List<ClienteDto>>(lista);
        }
    }
}
