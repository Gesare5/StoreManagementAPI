using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using StoreManagement.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManagement.Models;
using StoreManagement.Models.DTOs;
using StoreManagement.Models.DTOs.Mappings;


namespace StoreManagement.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        public StoreController(StoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddStore([FromBody] AddStoreRequestDTO addStore)
        {
            try
            {
                Store store = StoreMappings.GetStore(addStore);
                var result = await _storeService.CreateStore(store);
                return CreatedAtAction(nameof(GetStore), new { storeId = result.Id }, result);
            }
            catch (ArgumentException)
            {
                return BadRequest("Resource does not exist.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<bool>> GetStore([FromQuery] string storeId)
        {
            try
            {
                var result = await _storeService.GetStoreDetails(storeId);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Resource does not exist.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Store>>> GetStores(string customerId)
        {
            try
            {
                var result = await _storeService.GetStores(customerId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateProducts(string id, string userId, int amount)
        {
            try
            {
                var result = await _storeService.AddProducts(id, userId, amount);
                return Ok(result);

            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}

// [HttpDelete]
// public async Task<ActionResult<bool>> Delete([FromQuery] string storeId)
// {
//     try
//     {
//         var result = await _storeService.Delete(storeId);
//         if (result)
//         {
//             return NoContent();
//         }
//         return NotFound("Resource not found");
//     }

//     catch (Exception)
//     {
//         return StatusCode(StatusCodes.Status500InternalServerError);
//     }

// }

// }