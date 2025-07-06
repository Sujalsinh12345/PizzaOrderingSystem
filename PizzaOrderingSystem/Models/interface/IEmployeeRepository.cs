namespace PizzaOrderingSystem.Models.internalinterface
{
    interface IEmployeeRepository
    {
        // Define methods for employee repository
        Task AddEmployee(Employee employee);
        Task<Employee> GetEmployeeById(int id);
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}
