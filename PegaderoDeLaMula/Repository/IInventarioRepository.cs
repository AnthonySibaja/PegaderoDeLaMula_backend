using PegaderoDeLaMula.Models;
using PegaderoDeLaMula.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PegaderoDeLaMula.Repository
{
    public interface IInventarioRepository
    {
        Task<List<InventarioDto>> GetInventario();

        Task<InventarioDto> GetInventarioById(int id);

        Task<InventarioDto> CreateUpdate(InventarioDto inventarioDto);

        Task<bool> DeleteInventario(int id);
    }
}