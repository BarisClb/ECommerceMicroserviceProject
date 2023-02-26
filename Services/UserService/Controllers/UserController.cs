using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Commands.User.CreateUser;
using UserService.Application.Commands.User.DeleteUserById;
using UserService.Application.Commands.User.UpdateUser;
using UserService.Application.Queries.User;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("getusers")]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersQueryRequest getUsersRequest)
        {
            return Ok(await _mediator.Send(getUsersRequest));
        }

        [HttpGet("getuserbyid")]
        public async Task<IActionResult> GetUserById([FromQuery] GetUserByIdQueryRequest getUserByIdRequest)
        {
            return Ok(await _mediator.Send(getUserByIdRequest));
        }

        [HttpGet("getuserbyusername")]
        public async Task<IActionResult> GetUserByIUsername([FromQuery] GetUserByUsernameQueryRequest getUserByUsernameRequest)
        {
            return Ok(await _mediator.Send(getUserByUsernameRequest));
        }

        [HttpGet("getuserbyemail")]
        public async Task<IActionResult> GetUserByEmail([FromQuery] GetUserByEmailQueryRequest getUserByEmailRequest)
        {
            return Ok(await _mediator.Send(getUserByEmailRequest));
        }

        [HttpPost("createuser")]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserRequest)
        {
            return Ok(await _mediator.Send(createUserRequest));
        }

        [HttpPut("updateuser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest updateUserRequest)
        {
            return Ok(await _mediator.Send(updateUserRequest));
        }

        [HttpDelete("deleteuser")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            return Ok(await _mediator.Send(new DeleteUserByIdCommandRequest() { Id = userId }));
        }
    }
}
