using Entity;
using Xunit;
using IceCreamStoreRepostery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIceCreamStore
{
    public class OrderIntegrationTest:IClassFixture<DatabaseFixture>
    {
        private readonly IceCreamStoreReposteryOrder _orderRepository;
        private readonly WebApiContext _dbContext;
        public OrderIntegrationTest(DatabaseFixture fixture)
        {
            _dbContext = fixture.Context;
            _orderRepository = new IceCreamStoreReposteryOrder(_dbContext);
        }

        [Fact]
        public async Task AddOrderAsync_sucsseedIntegration()
        {
            var user = new User
            {
                FirstName = "Test",
                LastName = "User",
                UserName = "testuser1",
                Password = "StrongPass123!"
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            var order = new Order
            {
             
                OrderSum = 100,
                UserId = 1
            };
           var addedOrder= await _orderRepository.AddOrderAsync(order);
            Assert.NotNull(addedOrder);
            Assert.Equal(100, addedOrder.OrderSum);
        }
    }


}

