using Entity;
using DTO;

namespace IceCreamStoreService
{
    public interface IIceCreamStoreServiceProduct
    {
        Task<List<ProductDTO>> GetAllProductsAsync();
    }
}