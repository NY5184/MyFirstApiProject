using Entity;
using IceCreamStoreRepostery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using AutoMapper;

namespace IceCreamStoreService
{
    public class IceCreamStoreServiceCategory : IIceCreamStoreServiceCategory
    {
        IIceCreamStoreReposteryCategory _repostery;
        private readonly IMapper _mapper;
        public IceCreamStoreServiceCategory(IIceCreamStoreReposteryCategory repostery, IMapper mapper)
        {
            _repostery = repostery;
            _mapper = mapper;
        }
        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            var categorys = await _repostery.GetCategoriesAsync();
            if (categorys == null || categorys.Count == 0)
                return new List<CategoryDTO>();
            return _mapper.Map<List<CategoryDTO>>(categorys);
            //you can do this too
            //return _mapper.Map<List<CategoryDTO>>(await _repostery.GetCategoriesAsync() ?? new List<Category>());
        }
    }
}
