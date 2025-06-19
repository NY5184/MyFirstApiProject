using Entity;
using DTO;

namespace IceCreamStoreService
{
    public interface IIceCreamStoreServiceCategory
    {
        Task<List<CategoryDTO>> GetCategoriesAsync();
    }
}