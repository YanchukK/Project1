using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration2._0
{
    class Registration
    {
        FileService fileService = new FileService();

        public bool IsUsernameDontExist(string username)
        {
            if (fileService.IsUsernameDontExist(username))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsEmailDontExist(string email)
        {
            if (fileService.IsEmailDontExist(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RegistrationUser(string username, string password, string email)
        {
            var user = new User(username, password, email);
            fileService.AddNewUser(user);
        }
    }
}
