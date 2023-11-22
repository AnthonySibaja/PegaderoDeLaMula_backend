using PegaderoDeLaMula.Models;
using System.Threading.Tasks;

namespace PegaderoDeLaMula.Repository
{
    public interface IUserRepository
    {
        Task<string> Register(User user, string password);
        Task<string> Login(string userName, string password);
        Task<bool> UserExiste(string username);
    }
}
