namespace UserService.Application.Commands.Address.UpdateAddress
{
    public class UpdateAddressCommandResponse
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
    }
}
