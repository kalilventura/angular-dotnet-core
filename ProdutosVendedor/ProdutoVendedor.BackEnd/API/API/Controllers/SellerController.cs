using System;
using System.Threading.Tasks;
using Api.Repository.Interface;
using API.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerRepository _repository;

        public SellerController(ISellerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetBestSellerAsync")]
        [Produces("application/json")]
        public async Task<IActionResult> GetBestSellerAsync()
        {
            try
            {
                var best = await _repository.GetBestSellerAsync();

                return Ok(best);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + error.Message);
            }
        }

        [HttpGet]
        [Route("GetWorstSellerAsync")]
        [Produces("application/json")]
        public async Task<IActionResult> GetWorstSellerAsync()
        {
            try
            {
                var worst = await _repository.GetWorstSellersAsync();

                if (worst == null)
                    return BadRequest();
                else
                    return Ok(worst);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + error.Message);
            }
        }

        [HttpGet]
        [Route("GetAllSellersAsync")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllSellersAsync()
        {
            try
            {
                var sellers = await _repository.GetAllSellersAsync();
                return Ok(sellers);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + error.Message);
            }
        }

        [HttpGet]
        [Route("GetSellerByNameAsync")]
        [Produces("application/json")]
        public async Task<IActionResult> GetSellerByNameAsync(string name)
        {
            try
            {
                var seller = await _repository.GetSellerByName(name);

                if (seller == null)
                    return BadRequest("Seller not found");
                else
                    return Ok(seller);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + error.Message);
            }
        }

        [HttpGet("{sellerId}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetSellerByIdAsync(int sellerId)
        {
            try
            {
                var result = await _repository.GetSellerById(sellerId);
                return Ok(result);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + error.Message);
            }
        }

        [HttpPost]
        [Route("RegisterSellerAsync")]
        [Produces("application/json")]
        public async Task<IActionResult> RegisterSellerAsync(Seller seller)
        {
            try
            {
                var result = await _repository.AddAsync(seller);
                await _repository.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + error.Message);
            }
        }

        [HttpPut("{sellerId}")]
        [Produces("application/json")]
        public async Task<IActionResult> Put(Seller seller, int sellerId)
        {
            try
            {
                seller.SellerId = sellerId;
                var result = await _repository.UpdateAsync(seller);
                return Ok(result);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + error.Message);
            }
        }

        [HttpDelete("{sellerId}")]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(int sellerId)
        {
            try
            {
                var seller = await _repository.GetSellerById(sellerId);
                _repository.DeleteAsync<Seller>(seller);

                return NoContent();
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + error.Message);
            }
        }
    }
}
