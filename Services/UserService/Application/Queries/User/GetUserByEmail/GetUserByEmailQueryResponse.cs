using UserService.Domain.Enums;

namespace UserService.Application.Queries.User.GetUserByEmail
{
    public class GetUserByEmailQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public UserType UserType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public IEnumerable<GetUserByEmailQueryAddressModel>? Addresses { get; set; }
    }

    public class GetUserByEmailQueryAddressModel
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
