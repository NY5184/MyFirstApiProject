using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamStoreRepostery
{
    public class IceCreamStoreReposteryProduct : IIceCreamStoreReposteryProduct
    {
        WebApiContext _WebApiContext;
        public IceCreamStoreReposteryProduct(WebApiContext WebApiContext)
        {
            _WebApiContext = WebApiContext;
        }
        public async Task<List<Product>> GetAllProductsAsync()//(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await _WebApiContext.Products.Include(p=> p.Category).ToListAsync();
        }
    }
}
