using System.Collections.Generic;

namespace BroCode.BlogTemplate.Model
{
    public class User
    {
        #region Constructors
        public User(string name, string email, string password, bool isAdmin)
        {
            Name = name;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Article> Articles { get; set; }
        #endregion
    }
}
