using Microsoft.EntityFrameworkCore;
using PizzaOrderingSystem.Models.internalinterface;

namespace PizzaOrderingSystem.Models.Repository
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzaOrderingDbContext dbcontext;

        public PizzaRepository(PizzaOrderingDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task Add(Pizza pizza)
        {
            await dbcontext.Pizzas.AddAsync(pizza);
            await dbcontext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var pizza = await dbcontext.Pizzas.FindAsync(id);
            if (pizza != null)
            {
                dbcontext.Pizzas.Remove(pizza);
                await dbcontext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Pizza with ID {id} not found.");
            }
        }

        public async Task<IEnumerable<Pizza>> GetAll()
        {
            return await dbcontext.Pizzas.ToListAsync();
        }

        public async Task<Pizza> GetById(int id)
        {
            return await dbcontext.Pizzas.FindAsync(id);
        }

        public async Task Update(Pizza pizza)
        {
            dbcontext.Pizzas.Update(pizza);
            await dbcontext.SaveChangesAsync();
        }
    }
}
