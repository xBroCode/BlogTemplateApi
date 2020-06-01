using BroCode.BlogTemplate.Model.Shared;
using Kinvo.Utilities.Validations;
using System;
using System.Collections.Generic;

namespace BroCode.BlogTemplate.Model
{
    public class Article : BaseDateTrackerEntity
    {
        #region Constructors
        public Article(string title, string content, bool isPublished)
        {
            this.SetTitle(title);
            this.SetContent(content);
            this.UpdatePublishStatus(isPublished);

            base.CreatedAt = DateTime.Now;
        }

        protected Article()
        {

        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public string Title { get; private set; }
        public string Content { get; private set; }
        public bool IsPublished { get; private set; }

        public ICollection<ArticleCategory> ArticleCategories { get; set; }
        public ICollection<Comment> Comments { get; set; }
        #endregion

        #region Public Methods
        public void SetTitle(string title)
        {
            Validate.LessOrEqualThan(title.Length, 100);
            this.Title = title;
        }

        public void SetContent(string content)
        {
            Validate.LessOrEqualThan(content.Length, 100);
            this.Content = content;
        }

        public void UpdatePublishStatus(bool isPublished)
        {
            this.IsPublished = isPublished;
        }
        #endregion
    }
}
