using AutoMapper;
using MediatR;
using SharedLibrary.Models;
using UserService.Application.Interfaces;

namespace UserService.Application.Commands.User.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, BaseResponse<UpdateUserCommandResponse>>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IMapper mapper)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse<UpdateUserCommandResponse>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.User oldUser = await _userReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (oldUser == null)
                return BaseResponse<UpdateUserCommandResponse>.Fail($"User not found for Update User. Id: '{request.Id}'.", 404);

            if (!string.IsNullOrEmpty(request.Name))
                oldUser.Name = request.Name;
            if (!string.IsNullOrEmpty(request.Username))
                oldUser.Username = request.Username;
            if (!string.IsNullOrEmpty(request.Email))
                oldUser.Email = request.Email;
            if (!string.IsNullOrEmpty(request.Password))
                oldUser.Password = request.Password;
            if (request.IsAdmin != null)
                oldUser.IsAdmin = request.IsAdmin ?? oldUser.IsAdmin;
            if (request.UserType != null)
                oldUser.UserType = request.UserType ?? oldUser.UserType;

            var updatedUser = await _userWriteRepository.UpdateAsync(oldUser);

            if (updatedUser == null)
                return BaseResponse<UpdateUserCommandResponse>.Fail($"Failed to Update User. Id: '{request.Id}'.", 500);

            return BaseResponse<UpdateUserCommandResponse>.Success(_mapper.Map<UpdateUserCommandResponse>(updatedUser), 200);
        }
    }
}
