using Entity;
using IceCreamStoreRepostery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamStoreService
{
    public class IceCreamStoreServiceOrder : IIceCreamStoreServiceOrder
    {
        IIceCreamStoreReposteryOrder _repostery;
        public IceCreamStoreServiceOrder(IIceCreamStoreReposteryOrder repostery)
        {
            _repostery = repostery;
        }
        public async Task<Order> AddOrderAsync(Order order)
        {
            if (order.OrderSum <= 0)
                throw new ArgumentException("Order sum must be positive");

            order.OrderDate = DateTime.Now;
            return await _repostery.AddOrderAsync(order);
        }
    }
}
