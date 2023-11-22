using PegaderoDeLaMula.Models;
using PegaderoDeLaMula.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PegaderoDeLaMula.Repository
{
    public interface IDetallesRepository
    {
        Task<List<DetallesDto>> GetDetalles();

        Task<DetallesDto> GetDetalleById(int id);

        Task<DetallesDto> CreateUpdate(DetallesDto detalleDto);

        Task<bool> DeleteDetalle(int id);
    }
}