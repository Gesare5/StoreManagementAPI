using System.ComponentModel.DataAnnotations;


namespace StoreManagement.Models.DTOs
{
    public class AddStoreRequestDTO
    {
        [Required]
        public string StoreName { get; set; }

        public int NumberOfProducts { get; set; }

        [Required]
        public string StoreType { get; set; }
        public string CustomerId
        {
            get; set;
        }
    }
}