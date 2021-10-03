namespace StoreManagement.Models.DTOs.Mappings
{
    public class StoreMappings
    {
        public static Store GetStore(AddStoreRequestDTO storeRequest)
        {
            return new Store
            {
                StoreName = storeRequest.StoreName,
                NumberOfProducts = storeRequest.NumberOfProducts,
                StoreType = storeRequest.StoreType,
                UserId = storeRequest.CustomerId
            };

        }
    }
}