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
   public class CategoryIntegrationTest : IClassFixture<DatabaseFixture>
    {
        private readonly IceCreamStoreReposteryCategory _categoryRepository;
        private readonly WebApiContext _dbContext;

        public CategoryIntegrationTest(DatabaseFixture fixture)
        {
            _dbContext = fixture.Context;
            _categoryRepository = new IceCreamStoreReposteryCategory(_dbContext);
        }
        [Fact]
        public async Task GetCategoriesAsync_testONIntegration()
        {
            var category = new Category
            {
                CategoryName = "huiu"
            };
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
         
           
            var categories = await _categoryRepository.GetCategoriesAsync();
            Assert.NotNull(categories);
            Assert.Contains(categories, p => p.CategoryName =="huiu");

        }
    }
}
