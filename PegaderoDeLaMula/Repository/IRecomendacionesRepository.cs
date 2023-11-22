using PegaderoDeLaMula.Models;
using PegaderoDeLaMula.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PegaderoDeLaMula.Repository
{
    public interface IRecomendacionesRepository
    {
        Task<List<RecomendacionesDto>> GetRecomendaciones();

        Task<RecomendacionesDto> GetRecomendacionesById(int id);

        Task<RecomendacionesDto> CreateUpdate(RecomendacionesDto recomendacionesDto);

        Task<bool> DeleteRecomendaciones(int id);
    }
}