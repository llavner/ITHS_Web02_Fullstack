using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(ICustomerRepository customerRepository) : ControllerBase
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    // GET: api/<CustomerController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var customer = await _customerRepository.GetAllAsync();
        return Ok(customer);
    }

    // GET api/<CustomerController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);

        if (customer == null)
            return NotFound();
        else
            return Ok(customer);
    }

    // POST api/<CustomerController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Customer customer)
    {
        if (string.IsNullOrWhiteSpace(customer.FirstName))
        {
            return BadRequest(new { message = "Value can not be empty" });
        }
        
        await _customerRepository.AddAsync(customer);

        return Ok(new { message = $"Added user {customer.FirstName} {customer.LastName}", customer });
    }

    // PUT api/<CustomerController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Customer customer)
    {
        if (id != customer.Id)
            return BadRequest(new { message = $"Id: {id} not found." });
        else
        {
            await _customerRepository.UpdateAsync(customer);
            return Ok(new { message = $"Customer has been updated." });
        }
    }

    // DELETE api/<CustomerController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);

        if (customer == null)
            return NotFound(new { message = "Product not found." });
        else
        {
            await _customerRepository.DeleteAsync(id);
            return Ok(new { message = $"Customer with Id: {customer.Id} deleted." });

        }
    }
}

