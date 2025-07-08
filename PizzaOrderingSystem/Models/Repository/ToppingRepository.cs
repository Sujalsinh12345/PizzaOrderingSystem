using Microsoft.EntityFrameworkCore;
using PizzaOrderingSystem.Models.internalinterface;

namespace PizzaOrderingSystem.Models.Repository
{
    public class ToppingRepository : IToppingRepository
    {
        private readonly PizzaOrderingDbContext dbcontext;

        public ToppingRepository(PizzaOrderingDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task Add(Topping topping)
        {
            await dbcontext.Toppings.AddAsync(topping);
            await dbcontext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var topping = await dbcontext.Toppings.FindAsync(id);
            if (topping != null)
            {
                dbcontext.Toppings.Remove(topping);
                await dbcontext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"topping with ID {id} not found.");

            }
        }

        public async Task<IEnumerable<Topping>> GetAll()
        {
            return await dbcontext.Toppings.ToListAsync();
        }

        public async Task Update(Topping topping)
        {
            dbcontext.Toppings.Update(topping);
            await dbcontext.SaveChangesAsync();
        }
    }
}
