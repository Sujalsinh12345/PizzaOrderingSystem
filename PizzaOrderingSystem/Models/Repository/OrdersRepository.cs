using Microsoft.EntityFrameworkCore;
using PizzaOrderingSystem.Models.internalinterface;

namespace PizzaOrderingSystem.Models.Repository
{
    public class OrdersRepository: IOrdersRepository
    {
        private readonly PizzaOrderingSystemContext dbcontext;

        public OrdersRepository(PizzaOrderingSystemContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task AddOrder(Order order)
        {
            dbcontext.Orders.Add(order);
            await dbcontext.SaveChangesAsync();
        }

        public async Task DeleteOrder(int id)
        {
            var order = await dbcontext.Orders.FindAsync(id);
            if (order != null)
            {
                dbcontext.Orders.Remove(order);
                await dbcontext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Order with ID {id} not found.");
            }
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await dbcontext.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await dbcontext.Orders.FindAsync(id);
        }

        public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
        {
            return dbcontext.Orders
                .Where(o => o.CustomerId == customerId)
                .ToList();
        }

        public async Task UpdateOrder(Order order)
        {
            dbcontext.Orders.Update(order);
            await dbcontext.SaveChangesAsync();
        }
    }
}
