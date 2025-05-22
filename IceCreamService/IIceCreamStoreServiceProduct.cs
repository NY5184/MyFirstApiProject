using Entity;

namespace IceCreamStoreService
{
    public interface IIceCreamStoreServiceProduct
    {
        Task<List<Product>> GetAllProductsAsync();
    }
}