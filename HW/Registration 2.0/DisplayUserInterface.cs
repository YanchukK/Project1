using System;
using FluentValidation;

namespace Registration2._0
{
    class DisplayUserInterface
    {
        Registration registration = new Registration();

        public void Display()
        {
            var validator = new Validator();

            var user = new User();

            Console.Write("Input username: ");
            user.Username = Console.ReadLine();

            var result = validator.Validate(user, ruleSet: "Username");

            while (result.Errors.Count != 0)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine(failure.PropertyName + ": " + failure.ErrorMessage);
                }

                Console.Write("Input username: ");
                user.Username = Console.ReadLine();

                result = validator.Validate(user);
            }


            Console.Write("Input password: ");
            user.Password = Console.ReadLine();

            result = validator.Validate(user, ruleSet: "Password");

            while (result.Errors.Count != 0)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine(failure.PropertyName + ": " + failure.ErrorMessage);
                }

                Console.Write("Input password: ");
                user.Password = Console.ReadLine();

                result = validator.Validate(user);
            }
            

            Console.Write("Confirm the password: ");
            user.ConfirmPassword = Console.ReadLine();

            while (result.Errors.Count != 0)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine(failure.PropertyName + ": " + failure.ErrorMessage);
                }

                Console.Write("Confirm the password: ");
                user.ConfirmPassword = Console.ReadLine();

                result = validator.Validate(user);
            }


            Console.Write("Input email: ");
            user.Email = Console.ReadLine();

            result = validator.Validate(user, ruleSet: "Email");

            while (result.Errors.Count != 0)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine(failure.PropertyName + ": " + failure.ErrorMessage);
                }

                Console.Write("Input email: ");
                user.Email = Console.ReadLine();

                result = validator.Validate(user);
            }


            registration.RegistrationUser(user.Username, user.Password, user.Email);
            Console.WriteLine("Registration completed successfully");
        }
    }
}
