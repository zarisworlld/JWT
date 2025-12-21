namespace JWT.Api.ViewModels
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public long UserId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
