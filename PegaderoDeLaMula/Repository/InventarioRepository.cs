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
    public class InventarioRepository : IInventarioRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public InventarioRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<InventarioDto> CreateUpdate(InventarioDto inventarioDto)
        {
            Inventario inventario = _mapper.Map<InventarioDto, Inventario>(inventarioDto);
            if (inventario.ID_PRODUCTO > 0)
            {
                _db.INVENTARIO.Update(inventario);
            }
            else
            {
                await _db.INVENTARIO.AddAsync(inventario);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Inventario, InventarioDto>(inventario);
        }

        public async Task<bool> DeleteInventario(int id)
        {
            try
            {
                Inventario inventario = await _db.INVENTARIO.FindAsync(id);
                if (inventario == null)
                {
                    return false;
                }
                _db.INVENTARIO.Remove(inventario);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<InventarioDto> GetInventarioById(int id)
        {
            Inventario inventario = await _db.INVENTARIO.FindAsync(id);

            return _mapper.Map<InventarioDto>(inventario);
        }

        public async Task<List<InventarioDto>> GetInventario()
        {
            List<Inventario> lista = await _db.INVENTARIO.ToListAsync();

            return _mapper.Map<List<InventarioDto>>(lista);
        }
    }
}