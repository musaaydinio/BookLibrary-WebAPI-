using Entities.DataTranferObjcets;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _services;
        public AuthenticationController(IServiceManager services)
        {
            _services = services;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidetionFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody]UserForResgistrationDto userForResgistrationDto)
        {
            var result=await _services.AuthenticationService.Register(userForResgistrationDto);
            if (result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof (ValidetionFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if(!await _services.AuthenticationService.ValidateUser(user))
                return Unauthorized();
            return Ok(new
            {
                Token=await  _services.AuthenticationService.CreateToken()
            });
        }
    }    
}
