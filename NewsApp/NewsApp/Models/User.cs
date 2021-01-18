using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Models
{
    public class User : IUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
