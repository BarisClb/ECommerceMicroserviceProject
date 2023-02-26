using AutoMapper;
using MediatR;
using SharedLibrary.Models;
using UserService.Application.Helpers;
using UserService.Application.Interfaces;

namespace UserService.Application.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, BaseResponse<CreateUserCommandResponse>>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IMapper mapper)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            // If (AppUser != null && AppUser.IsAdmin) ? bool isAdmin == request.IsAdmin : AdminPasswordCheck(requst.AdminPassword);
            bool isAdmin = (request.IsAdmin ?? false) ? true : await UserHelpers.CheckAdminPassword(request.AdminPassword);

            Domain.Entities.User createUser = new()
            {
                Name = request.Name,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                IsAdmin = isAdmin,
                UserType = request.UserType
            };

            var newUser = await _userWriteRepository.AddAsync(createUser);
            if (newUser == null)
                return BaseResponse<CreateUserCommandResponse>.Fail($"Failed to Create User.", 500);

            return BaseResponse<CreateUserCommandResponse>.Success(_mapper.Map<CreateUserCommandResponse>(newUser), 201);
        }
    }
}
