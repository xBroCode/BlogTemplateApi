using BroCode.BlogTemplate.Model;

namespace BroCode.BlogTemplate.Persistence.Repositories
{
    public interface IUserRepository
    {
        User? GetByEmail(string email);
        User? GetById(int id);
        void Create(User user);
        void Update(User currentUser);
    }
}
