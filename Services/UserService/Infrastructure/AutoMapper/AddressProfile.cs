using AutoMapper;
using UserService.Application.Commands.Address.CreateAddress;
using UserService.Application.Commands.Address.UpdateAddress;
using UserService.Application.Queries.Address.GetAddressById;
using UserService.Application.Queries.Address.GetAddresses;
using UserService.Application.Queries.Address.GetAddressesByUserId;
using UserService.Application.Queries.User.GetUserByEmail;
using UserService.Application.Queries.User.GetUserById;
using UserService.Application.Queries.User.GetUserByUsername;
using UserService.Application.Queries.User.GetUsers;
using UserService.Domain.Entities;

namespace UserService.Infrastructure.AutoMapper
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, GetAddressesQueryResponse>().ForMember(address => address.User, options => options.MapFrom(expression => expression.User))
                                                           .ReverseMap();
            CreateMap<Address, GetAddressByIdQueryResponse>().ForMember(address => address.User, options => options.MapFrom(expression => expression.User))
                                                             .ReverseMap();
            CreateMap<Address, GetAddressesByUserIdQueryResponse>().ForMember(address => address.User, options => options.MapFrom(expression => expression.User))
                                                                   .ReverseMap();

            CreateMap<Address, CreateAddressCommandResponse>().ReverseMap();
            CreateMap<Address, UpdateAddressCommandResponse>().ReverseMap();


            // Relational

            CreateMap<Address, GetUserByIdQueryAddressModel>().ReverseMap();
            CreateMap<Address, GetUserByEmailQueryAddressModel>().ReverseMap();
            CreateMap<Address, GetUserByUsernameQueryAddressModel>().ReverseMap();
            CreateMap<Address, GetUsersQueryAddressModel>().ReverseMap();
        }
    }
}
