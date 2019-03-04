using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Registration2._0
{
    class Validator : AbstractValidator<User>
    {
        public Validator()
        {
            RuleSet("Username", () =>
            {
                RuleFor(user => user.Username).NotEmpty().Must(UniqueUsername)
                .WithMessage("Username already exists");
            });

            RuleSet("Password", () =>
            {
                RuleFor(user => user.Password).NotEmpty().MinimumLength(6).WithMessage("Minimum 6 characters")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,15}$")
                .WithMessage("Password must be correct");
            });
            
            RuleSet("ConfirmPassword", () =>
            {
                RuleFor(x => x.ConfirmPassword).Equal(x => x.Password)
                .WithMessage("Passwords do not match");
            });

            RuleSet("Email", () =>
            {
                RuleFor(user => user.Email).NotEmpty()
                .EmailAddress().WithMessage("A valid email is required")
                .Must(UniqueEmail).WithMessage("Email already exists");
            });
        }
        
        private bool UniqueUsername(string username)
        {
            Registration registration = new Registration();
            if(registration.IsUsernameDontExist(username))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool UniqueEmail(string email)
        {
            Registration registration = new Registration();
            if (registration.IsEmailDontExist(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
