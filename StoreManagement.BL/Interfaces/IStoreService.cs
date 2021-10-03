using System.Threading.Tasks;
using StoreManagement.Models;
using System.Collections.Generic;

namespace StoreManagement.BL
{
    public interface IStoreService
    {

        Task<Store> CreateStore(Store store);
        Task<Store> GetStoreDetails(string storeId);
        Task<List<Store>> GetStores(string customerId);
        Task<bool> AddProducts(string Id, string userId, int amount);
        Task<int> GetNumberOfProductsInStore(string storeId);

        //Task<bool> RemoveProducts(int increase, string customerId, string storeId);
    }
}