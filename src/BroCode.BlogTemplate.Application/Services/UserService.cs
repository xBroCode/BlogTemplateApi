using BroCode.BlogTemplate.Application.Contracts;
using BroCode.BlogTemplate.DTO;
using BroCode.BlogTemplate.Model;
using BroCode.BlogTemplate.Persistence.Repositories;
using Kinvo.Utilities.Validations;

namespace BroCode.BlogTemplate.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UserService(IUserRepository userRepository, IAuthService authService)
        {
            this._userRepository = userRepository;
            this._authService = authService;
        }

        public void Create(CreateUserDTO createUserDTO)
        {
            this.ValidateUserCreation(createUserDTO);

            var encryptedPassword = this._authService.GenerateEncryptedPassword(createUserDTO.Password);
            var user = new User(createUserDTO.Name, createUserDTO.Email, encryptedPassword, createUserDTO.IsAdmin);
            _userRepository.Create(user);
        }

        #region Private methods
        private void ValidateUserCreation(CreateUserDTO createUserDTO)
        {
            Validate.NotNullOrEmpty(createUserDTO.Email, "Email is required");
            var createdUser = this._userRepository.GetByEmail(createUserDTO.Email);
            Validate.IsTrue(createdUser == null, "There is already an user with this email on the database");
            Validate.NotNullOrEmpty(createUserDTO.Name, "Name is required");
            Validate.LessOrEqualThan(createUserDTO.Name.Length, 50, "Name must be 50 characters or less");
        }
        #endregion
    }
}
