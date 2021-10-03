using System.ComponentModel.DataAnnotations;

namespace StoreManagement.Models.DTOs
{
    public class UserRequestDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}