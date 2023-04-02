using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Commands.User.CreateUser;
using UserService.Application.Commands.User.DeleteUserById;
using UserService.Application.Commands.User.UpdateUser;
using UserService.Application.Queries.User.GetUserByEmail;
using UserService.Application.Queries.User.GetUserById;
using UserService.Application.Queries.User.GetUserByUsername;
using UserService.Application.Queries.User.GetUsers;

namespace UserService.WebAPI.Controllers
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


        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersQueryRequest getUsersRequest)
        {
            return Ok(await _mediator.Send(getUsersRequest));
        }

        [HttpGet("getUserById")]
        public async Task<IActionResult> GetUserById([FromQuery] GetUserByIdQueryRequest getUserByIdRequest)
        {
            return Ok(await _mediator.Send(getUserByIdRequest));
        }

        [HttpGet("getUserByUsername")]
        public async Task<IActionResult> GetUserByIUsername([FromQuery] GetUserByUsernameQueryRequest getUserByUsernameRequest)
        {
            return Ok(await _mediator.Send(getUserByUsernameRequest));
        }

        [HttpGet("getUserByEmail")]
        public async Task<IActionResult> GetUserByEmail([FromQuery] GetUserByEmailQueryRequest getUserByEmailRequest)
        {
            return Ok(await _mediator.Send(getUserByEmailRequest));
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserRequest)
        {
            return Ok(await _mediator.Send(createUserRequest));
        }

        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest updateUserRequest)
        {
            return Ok(await _mediator.Send(updateUserRequest));
        }

        [HttpDelete("deleteUser")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            return Ok(await _mediator.Send(new DeleteUserByIdCommandRequest() { Id = userId }));
        }
    }
}
