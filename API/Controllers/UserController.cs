using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserRepository userRepository) : ControllerBase
{
    private readonly IUserRepository _userRepository = userRepository;

    // GET: api/<UserController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var user = await _userRepository.GetAllAsync();
        return Ok(user);
    }

    // GET api/<UserController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return NotFound();
        else
            return Ok(user);
    }

    // POST api/<UserController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName))
        {
            return BadRequest(new { message = "Value can not be empty" });
        }
        
        await _userRepository.AddAsync(user);

        return Ok(new { message = $"Added user {user.FirstName} {user.LastName}", user });
    }

    // PUT api/<UserController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] User user)
    {
        if (id != user.Id)
            return BadRequest(new { message = $"Id: {id} not found." });
        else
        {
            await _userRepository.UpdateAsync(user);
            return Ok(new { message = $"User has been updated." });
        }
    }

    // DELETE api/<UserController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return NotFound(new { message = "Product not found." });
        else
        {
            await _userRepository.DeleteAsync(id);
            return Ok(new { message = $"User with Id: {user.Id} deleted." });

        }
    }
}

