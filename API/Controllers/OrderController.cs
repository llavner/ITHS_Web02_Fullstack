using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(IOrderRepository orderRepository) : ControllerBase
{

    private readonly IOrderRepository _orderRepository = orderRepository;
    // GET: api/<OrderController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var orders = await _orderRepository.GetAllAsync();
        return Ok(orders);
    }

    // GET api/<OrderController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);

        if (order == null)
            return NotFound();
        else
            return Ok(order);
    }

    // POST api/<OrderController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Order order)
    {
        if (string.IsNullOrWhiteSpace(order.Status))
        {
            return BadRequest(new { message = "Value can not be empty" });
        }

        await _orderRepository.AddAsync(order);

        return Ok(new { message = $"Added order {order.Id}", order });
    }

    // PUT api/<OrderController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Order order)
    {
        if (id != order.Id)
            return BadRequest(new { message = $"Id: {id} not found." });
        else
        {
            await _orderRepository.UpdateAsync(order);
            return Ok(new { message = $"Order with Id: {order.Id} has been updated." });
        }


    }

    // DELETE api/<OrderController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);

        if (order == null)
            return NotFound(new { message = "Order not found." });
        else
        {
            await _orderRepository.DeleteAsync(id);
            return Ok(new { message = $"Order with Id: {order.Id} deleted." });

        }

    }
}

