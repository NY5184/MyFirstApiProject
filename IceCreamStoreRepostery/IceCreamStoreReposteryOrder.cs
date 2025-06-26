using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamStoreRepostery
{
    public class IceCreamStoreReposteryOrder : IIceCreamStoreReposteryOrder
    {

        WebApiContext _WebApiContext;
        public IceCreamStoreReposteryOrder(WebApiContext context)
        {
            _WebApiContext = context;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            _WebApiContext.Orders.Add(order); //change to AddAsync 
            await _WebApiContext.SaveChangesAsync();// Save changes to the database 
            return order;
        }

    }
}
