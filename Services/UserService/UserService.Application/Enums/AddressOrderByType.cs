using System.ComponentModel;

namespace UserService.Application.Enums
{
    public enum AddressOrderByType
    {
        [Description("CreatedOn")]
        CreatedOn = 1,
        [Description("ModifiedOn")]
        ModifiedOn = 2,
        [Description("Name")]
        Name = 3,
        [Description("AddressLine")]
        AddressLine = 4,
        [Description("District")]
        District = 5,
        [Description("City")]
        City = 6,
        [Description("PostalCode")]
        PostalCode = 7
    }
}
