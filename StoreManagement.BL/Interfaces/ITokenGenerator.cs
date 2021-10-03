using StoreManagement.Models;
using System.Threading.Tasks;

namespace StoreManagement.BL
{
    public interface ITokenGenerator
    {
        Task<string> GenerateToken(AppUser user);

    }
}