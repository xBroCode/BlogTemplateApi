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

        public void Update(int userId, ChangeCredentialsDTO changeCredentialsDTO)
        {
            var currentUser = _userRepository.GetById(userId);
            var currentEncryptedPassword = this._authService.GenerateEncryptedPassword(changeCredentialsDTO.CurrentPassword);
            Validate.EqualThan(currentUser.Password, currentEncryptedPassword, "Invalid credentials");

            if ((!string.IsNullOrWhiteSpace(changeCredentialsDTO.Email)) && (changeCredentialsDTO.Email != currentUser.Email))
            {
                this.ValidateUniqueEmail(changeCredentialsDTO.Email);
                currentUser.Email = changeCredentialsDTO.Email;
            }

            if (!string.IsNullOrWhiteSpace(changeCredentialsDTO.Name))
            {
                this.ValidateUserName(changeCredentialsDTO.Name);
                currentUser.Name = changeCredentialsDTO.Name;
            }

            if (!string.IsNullOrWhiteSpace(changeCredentialsDTO.NewPassword))
            {
                var newEncryptedPassword = this._authService.GenerateEncryptedPassword(changeCredentialsDTO.NewPassword);
                currentUser.Password = newEncryptedPassword;
            }

            _userRepository.Update(currentUser);
        }

        #region Private methods
        private void ValidateUserCreation(CreateUserDTO createUserDTO)
        {
            Validate.NotNullOrEmpty(createUserDTO.Email, "Email is required");
            this.ValidateUniqueEmail(createUserDTO.Email);
            this.ValidateUserName(createUserDTO.Name);
        }

        private void ValidateUserName(string name)
        {
            Validate.NotNullOrEmpty(name, "Name is required");
            Validate.LessOrEqualThan(name.Length, 50, "Name must be 50 characters or less");
        }

        private void ValidateUniqueEmail(string newEmail)
        {
            var createdUser = this._userRepository.GetByEmail(newEmail);
            Validate.IsTrue(createdUser == null, "There is already an user with this email on the database");
        }
        #endregion
    }
}
