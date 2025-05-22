using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamStoreRepostery
{
    public class IceCreamStoreReposteryCategory : IIceCreamStoreReposteryCategory
    {
        WebApiContext _WebApiContext;
        public IceCreamStoreReposteryCategory(WebApiContext WebApiContext)
        {
            _WebApiContext = WebApiContext;
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _WebApiContext.Categories.ToListAsync();
        }
    }
}
