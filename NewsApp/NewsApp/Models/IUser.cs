using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Models
{
    public interface IUser
    {
        string Email { get; set; }
        string Password { get; set; }
        bool IsLoggedIn { get; set; }
    }
}
