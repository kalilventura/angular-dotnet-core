using System;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var result = await _repository.GetAllProductsAsync();
                return Ok(result);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + error.Message);
            }
        }

        [HttpGet("{productId}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            try
            {
                var product = await _repository.GetProductById(productId);
                return Ok(product);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + error.Message);
            }
        }

        [HttpPost]
        [Route("RegisterProduct")]
        [Produces("application/json")]
        public async Task<IActionResult> RegisterProduct(Product product)
        {
            try
            {
                var result = await _repository.AddAsync(product);
                await _repository.SaveChangesAsync();
                return Created($"Product {result.Name} successfully registered on the system", result);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + error.Message);
            }
        }

        [HttpPut("{productId}")]
        [Produces("application/json")]
        public async Task<IActionResult> Put(Product product, int productId)
        {
            try
            {
                product.ProductId = productId;
                var result = await _repository.UpdateAsync(product);
                return Ok(result);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + error.Message);
            }
        }

        [HttpDelete("{productId}")]
        [Produces("application/json")]
        public async Task<IActionResult> RemoveProduct(int productId)
        {
            try
            {
                var product = await _repository.GetProductById(productId);
                _repository.DeleteAsync(product);

                return NoContent();
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + error.Message);
            }
        }

    }
}