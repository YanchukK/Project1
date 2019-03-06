using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithDB
{
    class Program
    {
        static void Main(string[] args)
        {
            DB dB = new DB(@"Data Source=.\SQLEXPRESS;Initial Catalog=VCPhoneBook;Integrated Security=True");

            foreach (var t in dB.Users.GetAll())
            {
                Console.WriteLine(t);
            }

            foreach (var t in dB.Managers.GetAll())
            {
                Console.WriteLine(t);
            }

            Console.WriteLine(dB.Managers.GetById(2));

            //Console.ReadKey();
        }
    }
}
