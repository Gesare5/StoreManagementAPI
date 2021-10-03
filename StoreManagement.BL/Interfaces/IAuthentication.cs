using System.Threading.Tasks;
using StoreManagement.Models.DTOs;

namespace StoreManagement.BL
{
    public interface IAuthentication
    {
        Task<UserResponseDTO> Login(UserRequestDTO userRequest);
        Task<UserResponseDTO> Register(RegistrationRequest registrationRequest);
    }
}