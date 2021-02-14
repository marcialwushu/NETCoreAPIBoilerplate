using System;

namespace JDPI.Application.API.Models
{
    public class UserResponse
    {
        private object p;

        public UserResponse()
        {
            
        }

        public UserResponse(object p)
        {
            this.p = p;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CrationDate { get; set; }
    }
}