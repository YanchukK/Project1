using System;
using System.Text.RegularExpressions;

namespace Registration
{
    static class Validator
    {
        static string patternEmail = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

        public static string ValidateEmail()
        {
            string text = "Введите адрес электронной почты";
            return Validate(patternEmail, text);
        }

        static string patternName = @"^[a-zA-Z]+$";
        public static string ValidateUsername()
        {
            string text = "Введите имя пользователя";
            return Validate(patternName, text);
        }


        // The conditions are string must be between 6 and 10 characters long.
        // string must contain at least one number. string must contain at
        // least one uppercase letter. string must contain at least one
        // lowercase letter.
        static string patternPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$";
        public static string ValidatePassword()
        {
            string text = "Введите пароль";
            return Validate(patternPassword, text);
        }


        public static string Validate(string pattern, string text)
        {
            string property;
            while (true)
            {
                Console.WriteLine(text);
                property = Console.ReadLine();

                if (Regex.IsMatch(property, pattern, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("{0} подтвержден", property);
                    break;
                }
                else
                {
                    Console.WriteLine("Введено некорректно");
                }
            }
            return property;
        }
    }
}
