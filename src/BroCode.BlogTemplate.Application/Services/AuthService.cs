using BroCode.BlogTemplate.Application.Contracts;
using BroCode.BlogTemplate.DTO;
using BroCode.BlogTemplate.Infrastructure.Security;
using BroCode.BlogTemplate.Persistence.Repositories;
using Microsoft.Extensions.Options;
using System;

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
            if (user == null)
                throw new ArgumentException();

            var encryptedPassword = SecurityManager.GenerateMD5Hash(credentialsDTO.Password);
            if (user.Password != encryptedPassword)
                throw new ArgumentException();

            var token = JwtHandler.GenerateToken(_tokenOptions.Value.SecretKey, user.Name, user.Id, user.IsAdmin);
            return new LoginResultDTO(token);
        }
    }
}
