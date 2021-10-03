using System.Threading.Tasks;
using StoreManagement.Models.DTOs;

namespace StoreManagement.BL
{
    public interface IUserService
    {
        Task<bool> DeleteUser(string userId);
        Task<UserResponseDTO> GetUser(string userId);
        Task<bool> Update(string userId, UpdateUserRequest updateUser);
    }

}