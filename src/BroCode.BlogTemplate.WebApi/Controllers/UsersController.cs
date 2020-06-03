using BroCode.BlogTemplate.Application.Contracts;
using BroCode.BlogTemplate.DTO;
using Kinvo.Utilities.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BroCode.BlogTemplate.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Create(CreateUserDTO createUserDTO)
        {
            try
            {
                _userService.Create(createUserDTO);
                return StatusCode(201);
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public ActionResult<LoginResultDTO> Update(ChangeCredentialsDTO changeCredentialsDTO)
        {
            try
            {
                var loggedUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                _userService.Update(loggedUserId, changeCredentialsDTO);
                return NoContent();
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
