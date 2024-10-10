using Microsoft.AspNetCore.Mvc;
using POSWebApi.Models;
using POSWebApi.Repositories.IRepositories;

namespace POSWebApi.Controllers{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController :ControllerBase{
        private readonly ICustomerRepository _customerRepo;

        public CustomersController(ICustomerRepository customerRepo){
            _customerRepo = customerRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers(){
            var customers = await _customerRepo.GetAllCutomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(Guid id){
            var customer = await _customerRepo.GetCustomerByIdAsync(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody]Customer customer){
            await _customerRepo.CreateCustomer(customer);
            return CreatedAtAction(nameof(GetCustomer), new {id = customer.Id}, customer);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(Guid id, [FromBody] Customer customer){
            var existingCustomer = await _customerRepo.GetCustomerByIdAsync(id);
            await _customerRepo.UpdateCustomer(existingCustomer);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(Guid id){
            var existingCustomer = await _customerRepo.GetCustomerByIdAsync(id);
            await _customerRepo.DeleteCustomer(existingCustomer.Id);
            return NoContent();
        }
    }
}