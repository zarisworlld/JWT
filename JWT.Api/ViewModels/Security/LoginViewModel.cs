namespace JWT.Api.ViewModels.Security
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public long UserId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
