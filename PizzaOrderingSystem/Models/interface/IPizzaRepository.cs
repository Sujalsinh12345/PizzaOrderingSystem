namespace PizzaOrderingSystem.Models.internalinterface
{
    interface IPizzaRepository
    {
        Task<IEnumerable<Pizza>> GetAll();
        Task<Pizza> GetById(int id);
        Task Add(Pizza pizza);
        Task Update(Pizza pizza);
        Task Delete(int id);
    }
}
