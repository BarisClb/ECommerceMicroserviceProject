using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Commands.Address.CreateAddress;
using UserService.Application.Commands.Address.DeleteAddressById;
using UserService.Application.Commands.Address.UpdateAddress;
using UserService.Application.Queries.Address.GetAddressById;
using UserService.Application.Queries.Address.GetAddresses;
using UserService.Application.Queries.Address.GetAddressesByUserId;

namespace UserService.WebAPI.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("getAddresses")]
        public async Task<IActionResult> GetAddresses([FromQuery] GetAddressesQueryRequest getAddressesRequest)
        {
            return Ok(await _mediator.Send(getAddressesRequest));
        }

        [HttpGet("getAddressById")]
        public async Task<IActionResult> GetAddressById([FromQuery] GetAddressByIdQueryRequest getAddressByIdRequest)
        {
            return Ok(await _mediator.Send(getAddressByIdRequest));
        }

        [HttpGet("getAddressesByUserId")]
        public async Task<IActionResult> GetAddressesByUserId([FromQuery] GetAddressesByUserIdQueryRequest getAddressesByUserIdRequest)
        {
            return Ok(await _mediator.Send(getAddressesByUserIdRequest));
        }

        [HttpPost("createAddress")]
        public async Task<IActionResult> CreateAddress(CreateAddressCommandRequest createAddressRequest)
        {
            return Ok(await _mediator.Send(createAddressRequest));
        }

        [HttpPut("updateAddress")]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommandRequest updateAddressRequest)
        {
            return Ok(await _mediator.Send(updateAddressRequest));
        }

        [HttpDelete("deleteAddress")]
        public async Task<IActionResult> DeleteAddress(Guid addressId)
        {
            return Ok(await _mediator.Send(new DeleteAddressByIdCommandRequest() { Id = addressId }));
        }
    }
}
