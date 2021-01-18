using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Service
{
    public static class DbUsers
    {
        public static List<User> Users = new List<User>{
        new User(){ Email = "user@gmail.com", Password="12345678"},
        new User(){ Email = "user2@gmail.com", Password="12345678"},
        new User(){ Email = "user3@gmail.com", Password="12345678"}
        };
    }
}
