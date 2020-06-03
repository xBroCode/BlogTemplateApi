using BroCode.BlogTemplate.Application.Contracts;
using BroCode.BlogTemplate.DTO;
using BroCode.BlogTemplate.Infrastructure.Security;
using BroCode.BlogTemplate.Persistence.Repositories;
using Kinvo.Utilities.Validations;
using Microsoft.Extensions.Options;

namespace BroCode.BlogTemplate.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOptions<JwtConfig> _tokenOptions;

        public AuthService(IUserRepository userRepository, IOptions<JwtConfig> options)
        {
            this._userRepository = userRepository;
            this._tokenOptions = options;
        }

        public LoginResultDTO Login(LoginCredentialsDTO credentialsDTO)
        {
            var user = _userRepository.GetByEmail(credentialsDTO.Email);
            Validate.NotNull(user);

            var encryptedPassword = this.GenerateEncryptedPassword(credentialsDTO.Password);
            Validate.EqualThan(user.Password, encryptedPassword);

            var token = JwtHandler.GenerateToken(_tokenOptions.Value.SecretKey, user.Name, user.Id, user.IsAdmin);
            return new LoginResultDTO(token);
        }

        public string GenerateEncryptedPassword(string password)
        {
            Validate.NotNullOrEmpty(password, "The password is required");
            Validate.GreaterOrEqualThan(password.Length, 5, "The password must be at least 5 characters");

            return SecurityManager.GenerateMD5Hash(password);
        }
    }
}
