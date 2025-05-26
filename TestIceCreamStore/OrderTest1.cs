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
    public class OrderTest1
    {
        [Fact]
        public async Task AddOrderAsync_AddOrderAsyncSucssefully()
        {
            var orders = new List<Order>();
            var mockContext = new Mock<WebApiContext>();
            // Mock את DbSet<User> כך שיתמוך ב־AddAsync ושישתמש ברשימת users
            mockContext.Setup(x => x.Orders).ReturnsDbSet(orders);
            var repo = new IceCreamStoreReposteryOrder(mockContext.Object);
            var order = new Order
            {
                OrderId = 1,
                OrderSum = 100,
                UserId = 1
            };
            var result = await repo.AddOrderAsync(order);
            Assert.Equal(order, result);

        }
    }
}
