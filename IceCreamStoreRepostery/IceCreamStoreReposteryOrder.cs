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
            order.OrderDate = DateTime.Now;
        
            _WebApiContext.Orders.Add(order); // Add זה סינכרוני
            var addedOrder=await _WebApiContext.SaveChangesAsync(); // פה מחכים לסיום השמירה
            return order;
        }

    }
}
