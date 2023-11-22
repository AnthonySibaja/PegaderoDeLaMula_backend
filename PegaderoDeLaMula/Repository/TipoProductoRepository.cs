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
    public class TipoProductoRepository : ITipoProductoRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public TipoProductoRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<TipoProductoDto> CreateUpdate(TipoProductoDto tipoProductoDto)
        {
            TipoProducto tipoProducto = _mapper.Map<TipoProductoDto, TipoProducto>(tipoProductoDto);
            if (tipoProducto.ID_TIPO_PRODUCTO > 0)
            {
                _db.TIPO_PRODUC.Update(tipoProducto);
            }
            else
            {
                await _db.TIPO_PRODUC.AddAsync(tipoProducto);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<TipoProducto, TipoProductoDto>(tipoProducto);
        }

        public async Task<bool> DeleteTipoProducto(int id)
        {
            try
            {
                TipoProducto tipoProducto = await _db.TIPO_PRODUC.FindAsync(id);
                if (tipoProducto == null)
                {
                    return false;
                }
                _db.TIPO_PRODUC.Remove(tipoProducto);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<TipoProductoDto> GetTipoProductoById(int id)
        {
            TipoProducto tipoProducto = await _db.TIPO_PRODUC.FindAsync(id);

            return _mapper.Map<TipoProductoDto>(tipoProducto);
        }

        public async Task<List<TipoProductoDto>> GetTiposProductos()
        {
            List<TipoProducto> lista = await _db.TIPO_PRODUC.ToListAsync();

            return _mapper.Map<List<TipoProductoDto>>(lista);
        }
    }
}