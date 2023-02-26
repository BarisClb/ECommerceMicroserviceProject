namespace UserService.Application.Helpers
{
    public static class UserHelpers
    {
        public static async Task<bool> CheckAdminPassword(string adminPassword)
        {
            return adminPassword == "123";
        }
    }
}
