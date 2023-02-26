using UserService.Domain.Enums;

namespace UserService.Application.Queries.User.GetUserById
{
    public class GetUserByIdQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public UserType UserType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public IEnumerable<GetUserByIdQueryAddressModel>? Addresses { get; set; }
    }

    public class GetUserByIdQueryAddressModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AddressLine { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
