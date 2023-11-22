using PegaderoDeLaMula.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PegaderoDeLaMula.Repository
{
    public interface IClienteRepository
    {
        Task<List<ClienteDto>> GetClientes();

        Task<ClienteDto> GetClienteById(int id);

        Task<ClienteDto> CreateUpdate(ClienteDto clienteDto);

        Task<bool> DeleteCliente(int id);
    }
}
