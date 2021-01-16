using FluentValidation;
using Life_Balance.DAL.Models;

namespace Life_Balance.BLL.Extensions
{
    public class Validator : AbstractValidator<User>
    {
        public Validator()
        {
            RuleFor(user => user.Email).EmailAddress();
            RuleFor(user => user.PasswordHash)
                .Must(x => x.Length >= 6)
                .WithMessage("Password need > 6");
        }
    }
}