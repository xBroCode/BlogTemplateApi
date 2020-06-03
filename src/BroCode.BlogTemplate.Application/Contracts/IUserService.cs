using BroCode.BlogTemplate.DTO;

namespace BroCode.BlogTemplate.Application.Contracts
{
    public interface IUserService
    {
        void Create(CreateUserDTO createUserDTO);
        void Update(int userId, ChangeCredentialsDTO changeCredentialsDTO);
    }
}
