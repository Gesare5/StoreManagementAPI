namespace StoreManagement.Models.DTOs.Mappings
{
    public class UserMappings
    {
        public static UserResponseDTO GetUserResponse(AppUser user)
        {
            return new UserResponseDTO
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Id = user.Id
            };
        }
        public static AppUser GetUser(RegistrationRequest request)
        {
            return new AppUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber
            };
        }
    }
}