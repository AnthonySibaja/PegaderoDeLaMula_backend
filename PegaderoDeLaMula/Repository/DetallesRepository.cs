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
    public class DetallesRepository : IDetallesRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public DetallesRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<DetallesDto> CreateUpdate(DetallesDto detallesDto)
        {
            Detalles detalles = _mapper.Map<DetallesDto, Detalles>(detallesDto);
            if (detalles.NUMERO_PRODUCTO > 0)
            {
                _db.DDA.Update(detalles);
            }
            else
            {
                await _db.DDA.AddAsync(detalles);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Detalles, DetallesDto>(detalles);
        }

        public async Task<bool> DeleteDetalle(int id)
        {
            try
            {
                Detalles detalles = await _db.DDA.FindAsync(id);
                if (detalles == null)
                {
                    return false;
                }
                _db.DDA.Remove(detalles);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<DetallesDto> GetDetalleById(int id)
        {
            Detalles detalles = await _db.DDA.FindAsync(id);

            return _mapper.Map<DetallesDto>(detalles);
        }

        public async Task<List<DetallesDto>> GetDetalles()
        {
            List<Detalles> lista = await _db.DDA.ToListAsync();

            return _mapper.Map<List<DetallesDto>>(lista);
        }
    }
}