using FluentValidation;
using SharedLibrary.Helpers;
using UserService.Application.Commands.Address.CreateAddress;
using UserService.Application.Commands.Address.DeleteAddressById;
using UserService.Application.Commands.Address.UpdateAddress;
using UserService.Application.Queries.Address;
using UserService.Application.Queries.Address.GetAddresses;

namespace UserService.Infrastructure.FluentValidation
{
    public class AddressValidators
    {
        public class GetAddressesRequestValidator : CustomAbstractValidator<GetAddressesQueryRequest>
        {
            public GetAddressesRequestValidator()
            { }
        }

        public class GetAddressByIdRequestValidator : CustomAbstractValidator<GetAddressByIdQueryRequest>
        {
            public GetAddressByIdRequestValidator()
            {
                RuleFor(address => address.Id).NotEmpty().WithMessage("Address: Id is empty.");
            }
        }

        public class GetAddressesByUserIdRequestValidator : CustomAbstractValidator<GetAddressesByUserIdQueryRequest>
        {
            public GetAddressesByUserIdRequestValidator()
            {
                RuleFor(address => address.UserId).NotEmpty().WithMessage("Address: Id is empty.");
            }
        }

        public class CreateAddressRequestValidator : CustomAbstractValidator<CreateAddressCommandRequest>
        {
            public CreateAddressRequestValidator()
            {
                RuleFor(address => address.Name).NotEmpty().WithMessage("Address: Name is empty.");
                RuleFor(address => address.AddressLine).NotEmpty().WithMessage("Address: AddressLine is empty.");
                RuleFor(address => address.District).NotEmpty().WithMessage("Address: District is empty.");
                RuleFor(address => address.City).NotEmpty().WithMessage("Address: City is empty.");
                RuleFor(address => address.PostalCode).NotEmpty().WithMessage("Address: PostalCode is empty.");
                //.Matches(@"^[0-9]*$").WithMessage("Address: PostalCode must only contain numbers.");
                RuleFor(address => address.UserId).NotEmpty().WithMessage("Address: UserId is empty.");
            }
        }

        public class UpdateAddressRequestValidator : CustomAbstractValidator<UpdateAddressCommandRequest>
        {
            public UpdateAddressRequestValidator()
            {
                RuleFor(address => address.Id).NotEmpty().WithMessage("Address: Id is empty.");
                //When(address => !string.IsNullOrEmpty(address.PostalCode), () =>
                //{
                //    RuleFor(user => user.PostalCode).Matches(@"^[0-9]*$").WithMessage("Address: PostalCode must only contain numbers.");
                //});
            }
        }

        public class DeleteAddressByIdRequestValidator : CustomAbstractValidator<DeleteAddressByIdCommandRequest>
        {
            public DeleteAddressByIdRequestValidator()
            {
                RuleFor(address => address.Id).NotEmpty().WithMessage("Address: Id is empty.");
            }
        }
    }
}
