namespace PizzaOrderingSystem.Models.internalinterface
{
    interface IOrdersRepository
    {
        Task AddOrder(Order order);
        Task<Order> GetOrderById(int id);
        Task<IEnumerable<Order>> GetAllOrders();
        Task UpdateOrder(Order order);
        Task DeleteOrder(int id);
        IEnumerable<Order> GetOrdersByCustomerId(int customerId);

    }
}
