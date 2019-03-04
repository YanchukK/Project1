using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration2._0
{
    interface IFileService
    {
        List<User> GetAllUsers();

        void AddNewUser(User user);
    }
}
