using System.ComponentModel;

namespace UserService.Domain.Enums
{
    public enum UserType
    {
        [Description("Customer")]
        Customer = 1,
        [Description("Merchant")]
        Merchant = 2
    }
}
