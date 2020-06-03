using BroCode.BlogTemplate.DTO;

namespace BroCode.BlogTemplate.Application.Contracts
{
    public interface IAuthService
    {
        LoginResultDTO Login(LoginCredentialsDTO credentialsDTO);
        string GenerateEncryptedPassword(string password);
    }
}
