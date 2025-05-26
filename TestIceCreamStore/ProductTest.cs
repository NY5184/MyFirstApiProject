using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IceCreamStoreRepostery;
using Moq;
using Moq.EntityFrameworkCore;

namespace TestIceCreamStore
{
    public class ProductTest
    {
        [Fact]
        public async Task GetAllProductsAsync_GetAllProductsAsyncSucssesfully()
        {
            var prod = new Product
            {
                CategoryId = 1,
                ProductName = "cc",
                ProductDescription = "gg",
                PathOfPicture = "jj"
            };
            var products = new List<Product> { prod };
            var mockContext = new Mock<WebApiContext>();
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);
            var repo = new IceCreamStoreReposteryProduct(mockContext.Object);
            var result = await repo.GetAllProductsAsync();
            Assert.NotNull(result);
           
            Assert.Equal("cc", result[0].ProductName);
            Assert.Equal("gg", result[0].ProductDescription);
            Assert.Equal("jj", result[0].PathOfPicture);




        }
    }
}
