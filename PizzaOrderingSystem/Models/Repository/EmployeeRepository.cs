using Microsoft.EntityFrameworkCore;
using PizzaOrderingSystem.Models.internalinterface;

namespace PizzaOrderingSystem.Models.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PizzaOrderingDbContext dbContext;

        public EmployeeRepository(PizzaOrderingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddEmployee(Employee employee)
        {
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            var Employee = await dbContext.Employees.FindAsync(id);
            if(Employee != null)
            {
                dbContext.Employees.Remove(Employee);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await dbContext.Employees.ToListAsync(); 
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
           return await dbContext.Employees.FindAsync(id);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            dbContext.Employees.Update(employee);
            await dbContext.SaveChangesAsync();
        }
    }
}
