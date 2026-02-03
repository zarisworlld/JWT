namespace JWT.Api.ViewModels.Security
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public long UserId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class TestLoginViewModel
    {
        public string userName { get; set; }
        public string password { get; set; }
    }

    public class SumResponse
    {
        public double Sum { get; set; }
    }
}
