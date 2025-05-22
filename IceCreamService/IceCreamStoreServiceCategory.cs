using Entity;
using IceCreamStoreRepostery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamStoreService
{
    public class IceCreamStoreServiceCategory : IIceCreamStoreServiceCategory
    {
        IIceCreamStoreReposteryCategory _repostery;
        public IceCreamStoreServiceCategory(IIceCreamStoreReposteryCategory repostery)
        {
            _repostery = repostery;
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categorys = await _repostery.GetCategoriesAsync();
            if (categorys == null || categorys.Count == 0)
                return new List<Category>();
            return categorys;
        }
    }
}
