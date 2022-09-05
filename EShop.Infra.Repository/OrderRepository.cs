using EShop.Infra.Contract;
using EShop.Infra.Domain;
using EShop.Infra.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EShop.Infra.Repository;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(EshopContext eshopContext) : base(eshopContext)
    {
    }

    public async Task AddOrder(Order order)
    {
        await Add(order);
    }

    public async Task<Order> GetOrder(int id)
    {
        var order = await FindByCondition(x => x.Id == id, false)
            .Include(x => x.Product).FirstOrDefaultAsync();

        return order;
    }

    public void UpdateOrder(Order order)
    {
        Update(order);
    }

}