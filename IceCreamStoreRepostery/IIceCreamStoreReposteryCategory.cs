using Entity;

namespace IceCreamStoreRepostery
{
    public interface IIceCreamStoreReposteryCategory
    {
        Task<List<Category>> GetCategoriesAsync();
    }
}