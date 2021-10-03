using StoreManagement.DB;
using StoreManagement.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System;

namespace StoreManagement.BL
{
    public class ProductService : IProductService
    {
        private readonly DBContext _context;

        public ProductService(DBContext context)
        {
            _context = context;
        }

        // Add product
        public async Task<Product> AddProduct(Product product)
        {
            await _context.AddAsync(product);
            var result = await _context.SaveChangesAsync();

            return product;
        }

        // Delete product
        public async Task<bool> DeleteProduct(string productId)
        {
            Product product = await _context.Products
                            .FirstOrDefaultAsync(product => product.Id == productId);
            if (product == null)
            {
                return false;
            }

            _context.Remove(product);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Get all products
        public async Task<List<Product>> GetAllProducts(string productId)
        {
            return await _context.Products.Where(product => product.StoreId == productId)
                                        .ToListAsync();
        }

        // Get a product
        public async Task<Product> Getproduct(string productId)
        {
            Product product = await _context.Products

                .FirstOrDefaultAsync(product => product.Id == productId);
            if (product is null)
            {
                throw new ArgumentNullException("Resource does not exist");
            }
            return product;

        }

    }
}
