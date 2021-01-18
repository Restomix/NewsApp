using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Service
{
    public class LoginService
    {
        public LoginService()
        {

        }
        public async Task<User> GetUserByEmail(string Email)
        {
            return await Task.Run<User>(() =>
            {
                return DbUsers.Users.Find(x => { return ((Email == x?.Email) ? true : false); });
            });

        }
        public async Task<User> GetUserByEmailAndPassword(string Email, string Password)
        {
            return await GetUserByEmail(Email).ContinueWith<User>((x) =>
            {
                if (x?.Result?.Password == Password)
                {
                    return x.Result;
                }
                return null;
            });
        }
    }
}
