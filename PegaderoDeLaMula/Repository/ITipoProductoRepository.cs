using PegaderoDeLaMula.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PegaderoDeLaMula.Repository
{
    public interface ITipoProductoRepository
    {
        Task<List<TipoProductoDto>> GetTiposProductos();

        Task<TipoProductoDto> GetTipoProductoById(int id);

        Task<TipoProductoDto> CreateUpdate(TipoProductoDto tipoProductoDto);

        Task<bool> DeleteTipoProducto(int id);
    }
}