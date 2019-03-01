using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration
{
    static class Registration
    {
        private static List<User> users = new List<User>();

        // Должна быть возможность посмотреть список всех имеющихся пользователей.
        public static List<User> GetUsers()
        {
            return users;
        }

        // добавления пользователя
        public static void AddUser(string nickname, string name, string surname, DateTime birthday, string email, string password)
        {
            var user = CreateUser(nickname, name, surname, birthday, email, password);
            if (!IsUserExist(user.Nickname))
            {
                users.Add(user);
                FileServer.AddUserToFile(user);
            }
        }

        public static User CreateUser(string nickname, string name, string surname, DateTime birthday, string email, string password)
        {
            var user = new User(nickname, name, surname, birthday, email, password);

            return user;
        }
        
        private static bool IsUserExist(string nickname)
        {
            foreach(var user in users)
            {
                if(user.Nickname == nickname)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
