using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Registration2._0
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }

        public User() { }

        public User(string username, string password, string email)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }
    }
}