using System;
using FluentValidation;

namespace Registration
{
    class DisplayUserInterface
    {
        Registration registration = new Registration(new FileService());

        Validator validator = new Validator();

        User user = new User();

        public void Display()
        {

            Method("Username", InputUsername);

            //NewMethod();

            //var result = validator.Validate(user, ruleSet: "Username");

            //while (result.Errors.Count != 0)
            //{
            //    foreach (var failure in result.Errors)
            //    {
            //        Console.WriteLine(failure.PropertyName + ": " + failure.ErrorMessage);
            //    }

            //    NewMethod();

            //    result = validator.Validate(user, ruleSet: "Username");
            //}

            //registration.RegistrationUser(user.Username, user.Password, user.Email);

            Console.WriteLine("Registration completed successfully");
        }

        private void InputUsername()
        {
            Console.Write("Input username: ");
            user.Username = Console.ReadLine();
        }


        private void Method(string property, Action op)
        {
            op();

            var result = validator.Validate(user, ruleSet: property);

            while (result.Errors.Count != 0)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine(failure.PropertyName + ": " + failure.ErrorMessage);
                }

                op();

                result = validator.Validate(user, ruleSet: property);
            }
        }

    }
}
