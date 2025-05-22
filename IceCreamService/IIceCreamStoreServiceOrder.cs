using Entity;

namespace IceCreamStoreService
{
    public interface IIceCreamStoreServiceOrder
    {
        Task<Order> AddOrderAsync(Order order);
    }
}