using System;
using FluentValidation;

namespace Registration
{
    class CustomerValidator : AbstractValidator<User>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Nickname).Length(1, 10);
            RuleFor(x => x.Name).Length(1, 20);
            RuleFor(x => x.Surname).Length(1, 20);
            RuleFor(x => x.Birthday).NotEmpty().Must(BeAValidDate).WithMessage("Must be date").LessThan(p => DateTime.Now)
                .Must(BeMoreThan).WithMessage("Must be more than 1990");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email address is required") // regex (?) подходит ли
                     .EmailAddress().WithMessage("A valid email is required");
            RuleFor(x => x.Password).Length(1, 6); // одна большая, одна маленькая
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }

        private bool BeMoreThan(DateTime date)
        {
            DateTime dateTime = new DateTime(1990, 1, 1);

            if(date < dateTime)
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
