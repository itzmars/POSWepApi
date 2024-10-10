using POSWebApi.Data;
using POSWebApi.Models;
using POSWebApi.Repositories.IRepositories;

namespace POSWebApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly POSDbContext _context;

        public CustomerRepository(POSDbContext context){
            _context = context;
        }
        
        public Task CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllCutomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}