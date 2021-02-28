using JDPI.Common.Domain;
using System;
using System.Collections.Generic;


namespace JDPI.Platform.Entity
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public List<User> Users { get; set; }
    }

    
}