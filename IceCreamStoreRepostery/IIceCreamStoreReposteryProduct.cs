using Entity;

namespace IceCreamStoreRepostery
{
    public interface IIceCreamStoreReposteryProduct
    {
        Task<List<Product>> GetAllProductsAsync();
    }
}