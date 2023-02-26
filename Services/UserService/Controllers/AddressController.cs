using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Commands.Address.CreateAddress;
using UserService.Application.Commands.Address.DeleteAddressById;
using UserService.Application.Commands.Address.UpdateAddress;
using UserService.Application.Queries.Address;
using UserService.Application.Queries.Address.GetAddresses;

namespace UserService.Controllers
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


        [HttpGet("getaddresses")]
        public async Task<IActionResult> GetAddresses([FromQuery] GetAddressesQueryRequest getAddressesRequest)
        {
            return Ok(await _mediator.Send(getAddressesRequest));
        }

        [HttpGet("getaddressbyid")]
        public async Task<IActionResult> GetAddressById([FromQuery] GetAddressByIdQueryRequest getAddressByIdRequest)
        {
            return Ok(await _mediator.Send(getAddressByIdRequest));
        }

        [HttpGet("getaddressesbyuserid")]
        public async Task<IActionResult> GetAddressesByUserId([FromQuery] GetAddressesByUserIdQueryRequest getAddressesByUserIdRequest)
        {
            return Ok(await _mediator.Send(getAddressesByUserIdRequest));
        }

        [HttpPost("createaddress")]
        public async Task<IActionResult> CreateAddress(CreateAddressCommandRequest createAddressRequest)
        {
            return Ok(await _mediator.Send(createAddressRequest));
        }

        [HttpPut("updateaddress")]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommandRequest updateAddressRequest)
        {
            return Ok(await _mediator.Send(updateAddressRequest));
        }

        [HttpDelete("deleteaddress")]
        public async Task<IActionResult> DeleteAddress(Guid addressId)
        {
            return Ok(await _mediator.Send(new DeleteAddressByIdCommandRequest() { Id = addressId }));
        }
    }
}
