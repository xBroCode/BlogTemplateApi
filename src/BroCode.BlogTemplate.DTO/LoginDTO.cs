namespace BroCode.BlogTemplate.DTO
{
    public class LoginCredentialsDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class ChangeCredentialsDTO
    {
        public string CurrentPassword { get; set; }

        public string? NewPassword { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
    }

    public class LoginResultDTO
    {
        public LoginResultDTO(string token)
        {
            this.AuthToken = token;
        }

        public string AuthToken { get; set; }
    }
}
