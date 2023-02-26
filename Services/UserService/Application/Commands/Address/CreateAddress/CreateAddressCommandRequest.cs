﻿using MediatR;
using SharedLibrary.Models;

namespace UserService.Application.Commands.Address.CreateAddress
{
    public class CreateAddressCommandRequest : IRequest<BaseResponse<CreateAddressCommandResponse>>
    {
        public string Name { get; set; }
        public string AddressLine { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        // Relations
        public Guid UserId { get; set; }
    }
}
