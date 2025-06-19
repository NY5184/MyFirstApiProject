using Entity;
using DTO;

namespace IceCreamStoreService
{
    public interface IIceCreamStoreServiceOrder
    {
        Task<OrderDTO> AddOrderAsync(OrderDTO orderDto);
    }
}