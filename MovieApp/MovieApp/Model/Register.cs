using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Model
{
    public class Register
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
