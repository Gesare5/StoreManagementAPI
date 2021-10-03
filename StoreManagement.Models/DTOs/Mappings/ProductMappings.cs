using StoreManagement.Models.DTOs;
using StoreManagement.Models;

namespace StoreManagement.Models.DTOs.Mappings
{
    public class ProductMappings
    {
        public static Product GetProduct(AddProductRequestDTO storeRequest)
        {
            return new Product
            {
                Name = storeRequest.Name,
                StoreId = storeRequest.StoreId
            };
        }
        public static ProductResponseDTO GetProductResponse(Product product)
        {
            return new ProductResponseDTO
            {
                Name = product.Name,
                Id = product.Id,
                StoreId = product.StoreId,

            };
        }
    }
}