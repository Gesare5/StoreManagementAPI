using System.Threading.Tasks;
using System;
using StoreManagement.Models;
using StoreManagement.DB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace StoreManagement.BL
{
    public class StoreService : IStoreService
    {
        private readonly DBContext _context;
        public StoreService(DBContext context)
        {
            _context = context;
        }

        // adds/creates a new store
        public async Task<Store> CreateStore(Store store)
        {
            await _context.AddAsync(store);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
            {
                throw new ArgumentException("Cannot create store at this time");
            }

            return store;
        }

        // gets a particular store using the id
        public async Task<Store> GetStoreDetails(string storeId)
        {
            Store store = await _context.Stores
            .FirstOrDefaultAsync(store => store.Id == storeId);

            if (store is null)
            {
                throw new ArgumentNullException("Resource does not exist");
            }
            return store;

        }
        // get all the stores
        public async Task<List<Store>> GetStores(string customerId)
        {
            return await _context.Stores.Where(store => store.UserId == customerId).ToListAsync();
        }

        // add store products
        public async Task<bool> AddProducts(string Id, string userId, int amount)
        {

            var store = await GetStoreDetails(Id);

            if (store.UserId != userId)
            {
                throw new UnauthorizedAccessException("You do not have Access");
            }
            store.NumberOfProducts += amount;

            _context.Stores.Update(store);
            var result = await _context.SaveChangesAsync();
            return result > 0;

        }
        public async Task<int> GetNumberOfProductsInStore(string storeId)
        {
            Store store = await _context.Stores
                            .FirstOrDefaultAsync(store => store.Id == storeId);

            if (store is null)
            {
                throw new ArgumentNullException("Resource does not exist");
            }

            return store.NumberOfProducts;

        }
    }
}

//         public async Task<bool> RemoveProducts(int increase, string customerId, string storeId)
//         {
//             var result = await _storeRepository.RemoveProducts(increase, customerId, storeId);
//             return result;
//         }



//         public async Task<string> GetStoreId(string storeName, string storeType)
//         {
//             var result = await _storeRepository.GetStoreId(storeName, storeType);
//             return result;
//         }
//     }
// }
