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
    public class RecomendacionesRepository : IRecomendacionesRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public RecomendacionesRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RecomendacionesDto> CreateUpdate(RecomendacionesDto recomendacionesDto)
        {
            Recomendaciones recomendaciones = _mapper.Map<RecomendacionesDto, Recomendaciones>(recomendacionesDto);
            if (recomendaciones.ID_RECOMENDACIONES > 0)
            {
                _db.RECOMENDACIONES.Update(recomendaciones);
            }
            else
            {
                await _db.RECOMENDACIONES.AddAsync(recomendaciones);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Recomendaciones, RecomendacionesDto>(recomendaciones);
        }

        public async Task<bool> DeleteRecomendaciones(int id)
        {
            try
            {
                Recomendaciones recomendaciones = await _db.RECOMENDACIONES.FindAsync(id);
                if (recomendaciones == null)
                {
                    return false;
                }
                _db.RECOMENDACIONES.Remove(recomendaciones);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<RecomendacionesDto> GetRecomendacionesById(int id)
        {
            Recomendaciones recomendaciones = await _db.RECOMENDACIONES.FindAsync(id);

            return _mapper.Map<RecomendacionesDto>(recomendaciones);
        }

        public async Task<List<RecomendacionesDto>> GetRecomendaciones()
        {
            List<Recomendaciones> lista = await _db.RECOMENDACIONES.ToListAsync();

            return _mapper.Map<List<RecomendacionesDto>>(lista);
        }
    }
}