using ApiaryManagementSystem.Models;
using FluentValidation;

namespace ApiaryManagementSystem.Validators
{
    public class BeeColonyValidator : AbstractValidator<BeeColony>
    {
        public BeeColonyValidator()
        {
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Номер обязателен для заполнения")
                .MaximumLength(8).WithMessage("Фамилия не должна превышать 8 символов");

            RuleFor(x => x.ApiaryId)
                .GreaterThan(0).WithMessage("Пасека обязательна для заполнения");
        }
    }
}
