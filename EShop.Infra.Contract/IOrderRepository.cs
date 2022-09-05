using EShop.Infra.Domain.Entity;

namespace EShop.Infra.Contract;
 
public interface IOrderRepository
{
    public Task AddOrder(Order order);

    public Task<Order> GetOrder(int id);

    public void UpdateOrder(Order order);
}
