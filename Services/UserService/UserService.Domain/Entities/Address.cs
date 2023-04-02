namespace UserService.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Name { get; set; }
        public string AddressLine { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        // Relations
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
