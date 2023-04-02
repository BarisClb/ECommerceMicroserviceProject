using FluentValidation;
using SharedLibrary.Helpers;
using UserService.Application.Commands.User.CreateUser;
using UserService.Application.Commands.User.DeleteUserById;
using UserService.Application.Commands.User.UpdateUser;
using UserService.Application.Queries.User.GetUserById;
using UserService.Application.Queries.User.GetUsers;

namespace UserService.Infrastructure.FluentValidation
{
    public class UserValidators
    {
        public class GetUsersRequestValidator : CustomAbstractValidator<GetUsersQueryRequest>
        {
            public GetUsersRequestValidator()
            { }
        }

        public class GetUserByIdRequestValidator : CustomAbstractValidator<GetUserByIdQueryRequest>
        {
            public GetUserByIdRequestValidator()
            {
                RuleFor(user => user.Id).NotEmpty().WithMessage("User: Id is empty.");
            }
        }

        public class CreateUserRequestValidator : CustomAbstractValidator<CreateUserCommandRequest>
        {
            public CreateUserRequestValidator()
            {
                RuleFor(user => user.Name).NotEmpty().WithMessage("User: Name is empty.");
                RuleFor(user => user.Username).NotEmpty().WithMessage("User: Username is empty.")
                                                        .Must(userName => !userName.Any(c => char.IsWhiteSpace(c))).WithMessage("User: No empty spaces allowed in Username.");
                RuleFor(user => user.Email).NotEmpty().WithMessage("User: Email is empty.")
                                                     .Matches(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*").WithMessage("User: Invalid Email format.")
                                                     .Must(email => !email.Any(c => char.IsWhiteSpace(c))).WithMessage("User: No empty spaces allowed in Email.");
                RuleFor(user => user.Password).NotEmpty().WithMessage("User: Password is empty.")
                                                        .MinimumLength(8).WithMessage("User: Password must be longer than 8 Characters.")
                                                        .Must(password => !password.Any(c => char.IsWhiteSpace(c))).WithMessage("User: No empty spaces allowed in Password.")
                                                        .Matches(@"[A-Z]").WithMessage("User: Password must contain one or more Capital Letters.")
                                                        .Matches(@"[a-z]").WithMessage("User: Password must contain one or more Lowercase Letters.")
                                                        .Matches(@"\d").WithMessage("User: Password must contain one or more Digits.");
                RuleFor(user => user.UserType).NotEmpty().WithMessage("User: UserType is empty.");
            }
        }

        public class UpdateUserRequestValidator : CustomAbstractValidator<UpdateUserCommandRequest>
        {
            public UpdateUserRequestValidator()
            {
                RuleFor(user => user.Id).NotEmpty().WithMessage("User: Id is empty.");
                When(user => !string.IsNullOrEmpty(user.Username), () =>
                {
                    RuleFor(user => user.Username).MinimumLength(8)
                                                            .Must(username => !username.Any(c => char.IsWhiteSpace(c))).WithMessage("User: No empty spaces allowed in Username.");
                });
                When(user => !string.IsNullOrEmpty(user.Email), () =>
                {
                    RuleFor(user => user.Email).MinimumLength(8)
                                                         .Matches(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*").WithMessage("User: Invalid Email format.")
                                                         .Must(email => !email.Any(c => char.IsWhiteSpace(c))).WithMessage("User: No empty spaces allowed in Email.");
                });
                When(user => !string.IsNullOrEmpty(user.Password), () =>
                {
                    RuleFor(user => user.Password).MinimumLength(8).WithMessage("User: Password must be longer than 8 Characters.")
                                                            .Must(password => !password.Any(c => char.IsWhiteSpace(c))).WithMessage("User: No empty spaces allowed in Password.")
                                                            .Matches(@"[A-Z]").WithMessage("User: Password must contain one or more Capital Letters.")
                                                            .Matches(@"[a-z]").WithMessage("User: Password must contain one or more Lowercase Letters.")
                                                            .Matches(@"\d").WithMessage("User: Password must contain one or more Digits.");
                });
            }
        }

        public class DeleteUserByIdRequestValidator : CustomAbstractValidator<DeleteUserByIdCommandRequest>
        {
            public DeleteUserByIdRequestValidator()
            {
                RuleFor(user => user.Id).NotEmpty().WithMessage("User: Id is empty.");
            }
        }
    }
}
