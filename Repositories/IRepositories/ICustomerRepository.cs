using POSWebApi.Models;

namespace POSWebApi.Repositories.IRepositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCutomersAsync();
        Task<Customer> GetCustomerByIdAsync(Guid id);
        Task CreateCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(Guid id);
    }
}