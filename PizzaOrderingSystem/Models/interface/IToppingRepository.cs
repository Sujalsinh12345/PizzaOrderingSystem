namespace PizzaOrderingSystem.Models.internalinterface
{
    interface IToppingRepository
    {
        Task<IEnumerable<Topping>> GetAll();
        Task Add(Topping topping);
        Task Update(Topping topping);
        Task Delete(int id);
    }
}
