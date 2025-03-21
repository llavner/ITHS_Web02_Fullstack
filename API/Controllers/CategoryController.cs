using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICatogoryRepository categoryRepository) : ControllerBase
{
    private readonly ICatogoryRepository _categoryRepository = categoryRepository;

    // GET: api/<CategoryController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return Ok(categories);
    }

    // GET api/<CategoryController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category == null)
            return NotFound();
        else
            return Ok(category);
    }

    // POST api/<CategoryController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Category category)
    {
        if (string.IsNullOrWhiteSpace(category.Name))
        {
            return BadRequest(new { message = "Value can not be empty" });
        }

        await _categoryRepository.AddAsync(category);

        return Ok(new { message = $"Added category {category.Name}", category });
    }

    // PUT api/<CategoryController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Category category)
    {
        if (id != category.Id)
            return BadRequest(new { message = $"Id: {id} not found." });
        else
        {
            await _categoryRepository.UpdateAsync(category);
            return Ok(new { message = $"Category has been updated." });
        }
    }

    // DELETE api/<CategoryController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category == null)
            return NotFound(new { message = "Product not found." });
        else
        {
            await _categoryRepository.DeleteAsync(id);
            return Ok(new { message = $"{category.Name} deleted." });

        }
    }
}

