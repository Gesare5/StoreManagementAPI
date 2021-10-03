using System;

namespace StoreManagement.Models
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string StoreId { get; set; }

    }
}