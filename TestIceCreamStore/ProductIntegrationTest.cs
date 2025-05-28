using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Entity;
using IceCreamStoreRepostery;

namespace TestIceCreamStore
{
    public class ProductIntegrationTest : IClassFixture<DatabaseFixture>
    {
        private readonly IceCreamStoreReposteryProduct _productRepository;
        private readonly WebApiContext _dbContext;

        public ProductIntegrationTest(DatabaseFixture fixture)
        {
            _dbContext = fixture.Context;
            _productRepository = new IceCreamStoreReposteryProduct(_dbContext);
        }
        [Fact]
        public async Task GetAllProductsAsync_testONIntegration()
        {
            var category = new Category
            {
                CategoryName = "huiu"
            };
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            var prod = new Product
            {
                CategoryId = 1,
                ProductName = "cc",
                ProductDescription = "gg",
                PathOfPicture = "jj"
            };
            _dbContext.Products.Add(prod);
            _dbContext.SaveChanges();
            var products = await _productRepository.GetAllProductsAsync();
            Assert.NotNull(products);
            Assert.Contains(products, p => p.ProductName == "cc");

        }
    }
}

