using Microsoft.EntityFrameworkCore;
using PizzaOrderingSystem.Models.internalinterface;

namespace PizzaOrderingSystem.Models.Repository
{
    public class CustomersRepository : ICustomerRepository
    {
        private readonly PizzaOrderingSystemContext dbcontext;

        public CustomersRepository(PizzaOrderingSystemContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task Add(Customer customer)
        {
            await dbcontext.Customers.AddAsync(customer);
            await dbcontext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var customer = dbcontext.Customers.Find(id);
            if (customer != null)
            {
                dbcontext.Customers.Remove(customer);
                await dbcontext.SaveChangesAsync();
            }
            else { 
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await dbcontext.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await dbcontext.Customers.FindAsync(id);
        }

        public async Task Update(Customer customer)
        {
            dbcontext.Customers.Update(customer);
            await dbcontext.SaveChangesAsync();
        }
    }
}
