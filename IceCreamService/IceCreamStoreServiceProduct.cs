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
    public class IceCreamStoreServiceProduct : IIceCreamStoreServiceProduct
    {
        IIceCreamStoreReposteryProduct _repostery;
        private readonly IMapper _mapper;

        public IceCreamStoreServiceProduct(IIceCreamStoreReposteryProduct repostery, IMapper mapper)
        {
            _repostery = repostery;
            _mapper = mapper;
        }
        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _repostery.GetAllProductsAsync();
            Console.WriteLine("1111111111111");
            if (products == null || products.Count == 0)
                return new List<ProductDTO>();
            return _mapper.Map<List<ProductDTO>>(products);
        }
    }
}
