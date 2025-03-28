using Core.DTOs;
using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductRepository productRepository) : ControllerBase
{

    private readonly IProductRepository _productRepository = productRepository;

    // GET: api/<ProductController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _productRepository.GetAllAsync();
        return Ok(products);
    }

    // GET api/<ProductController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            return NotFound();
        else
            return Ok(product);
    }

    // POST api/<ProductController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductDTO productDto)
    {
        //if (string.IsNullOrWhiteSpace(productDto.Name))
        //{
        //    return BadRequest(new { message = "Value can not be empty" });
        //}

        var product = new Product
        {
            Artist = productDto.Artist,
            AlbumTitle = productDto.AlbumTitle,
            Price = productDto.Price,
            StockQuantity = productDto.StockQuantity,
            IsProductAvailable = productDto.IsProductAvailable,
            CategoryId = productDto.CategoryId
        };

        await _productRepository.AddAsync(product);

        return Ok(new { message = $"Added Product {product.Artist} {product.AlbumTitle}", product });



    }

    // PUT api/<ProductController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Product product)
    {
        if (id != product.Id)
            return BadRequest(new { message = $"Id: {id} not found." });
        else
        {
            await _productRepository.UpdateAsync(product);
            return Ok(new { message = $"{product.Id} has been updated." });
        }


    }

    // DELETE api/<ProductController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            return NotFound(new { message = "Product not found." });
        else
        {
            await _productRepository.DeleteAsync(id);
            return Ok(new { message = $"{product.Id} deleted." });

        }

    }
}

