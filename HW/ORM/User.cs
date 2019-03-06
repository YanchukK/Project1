using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithDB
{
    public class User : Entity
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id} Name: {this.Name}";
        }
    }
}
