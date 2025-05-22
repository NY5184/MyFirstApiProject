using Entity;
using IceCreamStoreRepostery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamStoreService
{
    public class IceCreamStoreServiceProduct : IIceCreamStoreServiceProduct
    {
        IIceCreamStoreReposteryProduct _repostery;
        public IceCreamStoreServiceProduct(IIceCreamStoreReposteryProduct repostery)
        {
            _repostery = repostery;
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await _repostery.GetAllProductsAsync();
            if (products == null || products.Count == 0)
                return new List<Product>();
            return products;
        }
    }
}
