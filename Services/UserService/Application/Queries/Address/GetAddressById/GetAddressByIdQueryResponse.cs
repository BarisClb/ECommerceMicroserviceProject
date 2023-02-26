using UserService.Domain.Enums;

namespace UserService.Application.Queries.Address.GetAddressById
{
    public class GetAddressByIdQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AddressLine { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        // Relations
        public Guid UserId { get; set; }
        public GetAddressByIdQueryUserModel? User { get; set; }
    }

    public class GetAddressByIdQueryUserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public UserType UserType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
