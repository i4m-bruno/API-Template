using System;
using System.Net;
using System.Threading.Tasks;
using API.Domain.Dtos;
using API.Domain.interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<Object> Login([FromServices] ILoginService service, [FromBody] LoginDto user)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if(user == null)
                return BadRequest();

            try
            {
                var result = await service.FindByLogin(user);
                if(result == null)
                    return NotFound();

                return result;
            }
            catch(ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
