using BroCode.BlogTemplate.Model.Shared;

namespace BroCode.BlogTemplate.Model
{
    public class Comment : BaseDateTrackerEntity
    {
        #region Constructors
        public Comment(string name, string content, string? email = null, string? website = null)
        {
            this.Name = name;
            this.Content = content;
            this.Email = email;
            this.Website = website;
        }

        protected Comment()
        {

        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Content { get; set; }
        public string? Website { get; set; }
        #endregion
    }
}
