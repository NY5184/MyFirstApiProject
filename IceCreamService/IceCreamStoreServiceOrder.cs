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
    public class IceCreamStoreServiceOrder : IIceCreamStoreServiceOrder
    {
        IIceCreamStoreReposteryOrder _repostery;
        private readonly IMapper _mapper;
        public IceCreamStoreServiceOrder(IIceCreamStoreReposteryOrder repostery, IMapper mapper)
        {
            _repostery = repostery;
            _mapper = mapper;
        }
        public async Task<OrderDTO> AddOrderAsync(OrderDTO orderDto)
        {
            if (orderDto.OrderSum <= 0)
                throw new ArgumentException("Order sum must be positive");
            Order order = _mapper.Map<Order>(orderDto);
            order.OrderDate = DateTime.Now;
            var addedOrder= await _repostery.AddOrderAsync(order);
            return _mapper.Map<OrderDTO>(addedOrder);

        }
    }
}
