// using System.ComponentModel.DataAnnotations;
using StoreManagement.BL;
using StoreManagement.DB;
using StoreManagement.Models.DTOs;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace StoreManagement.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _authentication;

        public AuthenticationController(IAuthentication authentication)
        {
            _authentication = authentication;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserRequestDTO userRequest)
        {
            try
            {
                return Ok(await _authentication.Login(userRequest));
            }
            catch (AccessViolationException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequest registerationRequest)
        {
            try
            {
                var result = await _authentication.Register(registerationRequest);
                //return CreatedAtAction(nameof(GetProduct), new { Id = result.Id }, result);
                return Created("", result);
            }
            catch (MissingFieldException mess)
            {
                return BadRequest(mess.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}