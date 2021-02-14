using System;
using JDPI.Common.Domain;

namespace JDPI.Platform.Entity
{
    public class User : BaseEntity, IEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}