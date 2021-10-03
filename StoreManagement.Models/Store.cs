using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace StoreManagement.Models
{
    public class Store
    {
        public string StoreName { get; set; }

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int NumberOfProducts { get; set; }

        [Required]
        public string StoreType { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}