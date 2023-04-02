using System.ComponentModel;

namespace UserService.Application.Helpers
{
    public enum UserOrderByType
    {
        [Description("CreatedOn")]
        CreatedOn = 1,
        [Description("ModifiedOn")]
        ModifiedOn = 2,
        [Description("Name")]
        Name = 3,
        [Description("Username")]
        Username = 4,
        [Description("IsAdmin")]
        IsAdmin = 5,
        [Description("UserType")]
        UserType = 6
    }
}
