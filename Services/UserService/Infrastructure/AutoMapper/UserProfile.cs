using AutoMapper;
using UserService.Application.Commands.User.CreateUser;
using UserService.Application.Commands.User.UpdateUser;
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
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUserByEmailQueryResponse>().ForMember(user => user.Addresses, options => options.MapFrom(expression => expression.Addresses))
                                                          .ReverseMap();
            CreateMap<User, GetUserByIdQueryResponse>().ForMember(user => user.Addresses, options => options.MapFrom(expression => expression.Addresses))
                                                       .ReverseMap();
            CreateMap<User, GetUserByUsernameQueryResponse>().ForMember(user => user.Addresses, options => options.MapFrom(expression => expression.Addresses))
                                                             .ReverseMap();
            CreateMap<User, GetUsersQueryResponse>().ForMember(user => user.Addresses, options => options.MapFrom(expression => expression.Addresses))
                                                    .ReverseMap();

            CreateMap<User, CreateUserCommandResponse>().ReverseMap();
            CreateMap<User, UpdateUserCommandResponse>().ReverseMap();


            // Relational

            CreateMap<User, GetAddressesQueryUserModel>().ReverseMap();
            CreateMap<User, GetAddressByIdQueryUserModel>().ReverseMap();
            CreateMap<User, GetAddressesByUserIdQueryUserModel>().ReverseMap();
        }
    }
}
