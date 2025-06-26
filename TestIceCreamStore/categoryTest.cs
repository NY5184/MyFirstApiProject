using Entity;
using IceCreamStoreRepostery;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIceCreamStore
{
    public class CategoryTest
    {
        [Fact]
        public async Task GetCategoriesAsync_GetCategoriesAsyncSucssesfuly()
        {
            var category = new Category
            {
                CategoryName = "huiu"
            };
            var categories = new List<Category> { category };
            var mockContext = new Mock<WebApiContext>();
            mockContext.Setup(x => x.Categories).ReturnsDbSet(categories);
            var repo = new IceCreamStoreReposteryCategory(mockContext.Object);
            var result = await repo.GetCategoriesAsync();
            Assert.NotNull(result);
            Assert.Equal("huiu", result[0].CategoryName);
        }
    }
}
