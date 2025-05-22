using Entity;

namespace IceCreamStoreService
{
    public interface IIceCreamStoreServiceCategory
    {
        Task<List<Category>> GetCategoriesAsync();
    }
}