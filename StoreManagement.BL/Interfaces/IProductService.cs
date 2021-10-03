using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManagement.Models;

namespace StoreManagement.BL
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product product);
        Task<bool> DeleteProduct(string productId);
        Task<List<Product>> GetAllProducts(string productId);
        Task<Product> Getproduct(string productId);
        // Task<bool> UpdateProduct(ProductPutRequest productDTO, string Id);
    }

}