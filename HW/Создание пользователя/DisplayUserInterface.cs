using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration
{
    class DisplayUserInterface
    {
        public void Display()
        {
            Console.Write("Enter nickname: ");
            string nickname = Console.ReadLine();

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter surname: ");
            string surname = Console.ReadLine();

            Console.Write("Enter birthday: ");
            DateTime birthday = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            CustomerValidator validator = new CustomerValidator();

            var user = Registration.CreateUser(nickname, name, surname, birthday, email, password);

            ValidationResult result = validator.Validate(user);

            result.

        }

    }
}
