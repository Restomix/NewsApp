using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NewsApp.ViewModels
{
    public class UserViewModel : BaseModel
    {
        private User user = new User();

        public UserViewModel(User user)
        {
            this.user.Email = user.Email;
            this.user.Password = user.Password;
            this.user.IsLoggedIn = user.IsLoggedIn;
        }
        public string Email
        {
            get { return user.Email; }
            set
            {
                if (value != user.Email)
                {
                    user.Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string Password
        {
            get { return user.Password; }
            set
            {
                if (value != user.Password)
                {
                    user.Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        public bool IsLoggedIn
        {
            get { return user.IsLoggedIn; }
            set
            {
                if (value != user.IsLoggedIn)
                {
                    user.IsLoggedIn = value;
                    OnPropertyChanged("IsLoggedIn");
                }
            }
        }

    }
}
