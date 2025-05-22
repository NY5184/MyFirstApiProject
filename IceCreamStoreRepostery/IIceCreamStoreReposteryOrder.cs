using Entity;

namespace IceCreamStoreRepostery
{
    public interface IIceCreamStoreReposteryOrder
    {
        Task<Order> AddOrderAsync(Order order);
    }
}