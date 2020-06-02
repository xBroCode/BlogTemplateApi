using BroCode.BlogTemplate.Model;
using BroCode.BlogTemplate.Persistence.Contexts;
using System.Linq;

namespace BroCode.BlogTemplate.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public User? GetByEmail(string email)
        {
            return base.dbSet.FirstOrDefault(user => user.Email == email);
        }
    }
}
