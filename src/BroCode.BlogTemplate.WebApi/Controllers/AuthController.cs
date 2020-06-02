using BroCode.BlogTemplate.Application.Contracts;
using BroCode.BlogTemplate.DTO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BroCode.BlogTemplate.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<LoginResultDTO> Login(LoginCredentialsDTO credentialsDTO)
        {
            try
            {
                var loginResultDTO = _authService.Login(credentialsDTO);
                return Ok(loginResultDTO);
            }
            catch (Exception)
            {
                return Unauthorized("Invalid credentials");
            }
        }
    }
}
