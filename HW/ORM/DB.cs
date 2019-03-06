using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithDB
{
    public class DB
    {
        protected string ConnectionString { get; set; }

        public DB(string connectionString)
        {
            this.ConnectionString = connectionString;

            this.Users = new DBList<User>(this.ConnectionString);
            this.Managers = new DBList<Manager>(this.ConnectionString);
        }

        public DBList<User> Users { get; set; }

        public DBList<Manager> Managers { get; set; }
    }
}
