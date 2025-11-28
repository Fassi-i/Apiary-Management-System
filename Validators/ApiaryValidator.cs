using ApiaryManagementSystem.Models;
using FluentValidation;

namespace ApiaryManagementSystem.Validators
{
    public class ApiaryValidator : AbstractValidator<Apiary>
    {
        public ApiaryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Название обязательна для заполнения")
                .MaximumLength(50).WithMessage("Название не должно превышать 50 символов")
                .Matches(@"^[a-zA-Zа-яА-ЯёЁ0-9\s\-\.,!?()@#$&*+=]+$").WithMessage("Название содержит недопустимые символы");

            RuleFor(x => x.OwnerId)
                .GreaterThan(0).WithMessage("Заведующий обязателен для заполнения");
        }
    }
}
