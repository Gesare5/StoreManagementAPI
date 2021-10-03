using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManagement.BL;
using StoreManagement.Models;
using StoreManagement.DB;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using StoreManagement.Models.DTOs;
using StoreManagement.Models.DTOs.Mappings;

namespace StoreManagement.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    // [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;


        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductRequestDTO productRequest)
        {
            try
            {
                var newProduct = ProductMappings.GetProduct(productRequest);
                var result = await _productService.AddProduct(newProduct);
                // var result = ProductMapping.GetAddProductResponse(newProduct);

                return CreatedAtAction(nameof(GetProduct), new { productId = newProduct.Id }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromQuery] string productId)
        {
            try
            {
                var result = await _productService.DeleteProduct(productId);
                if (result)
                {
                    return NoContent();
                }

                return NotFound("Resource not found");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        public async Task<ActionResult<ProductResponseDTO>> GetProduct([FromQuery] string productId)
        {
            try
            {
                var product = await _productService.Getproduct(productId);
                var result = ProductMappings.GetProductResponse(product);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return NotFound("Resource does not exist");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}