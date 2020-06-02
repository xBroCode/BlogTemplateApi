using BroCode.BlogTemplate.Model;

namespace BroCode.BlogTemplate.Persistence.Repositories
{
    public interface IUserRepository
    {
        User? GetByEmail(string email);
    }
}
