using System;

namespace BroCode.BlogTemplate.Model.Shared
{
    public abstract class BaseDateTrackerEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
