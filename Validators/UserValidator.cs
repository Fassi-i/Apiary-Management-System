using ApiaryManagementSystem.Models;
using FluentValidation;

namespace ApiaryManagementSystem.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Фамилия обязательна для заполнения")
                .MaximumLength(50).WithMessage("Фамилия не должна превышать 50 символов")
                .Matches(@"^[a-zA-Zа-яА-ЯёЁ\s\-]+$").WithMessage("Фамилия содержит недопустимые символы");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Имя обязательно для заполнения")
                .MaximumLength(50).WithMessage("Имя не должно превышать 50 символов")
                .Matches(@"^[a-zA-Zа-яА-ЯёЁ\s\-]+$").WithMessage("Имя содержит недопустимые символы");

            RuleFor(x => x.MiddleName)
                .MaximumLength(50).WithMessage("Отчество не должно превышать 50 символов")
                .Matches(@"^[a-zA-Zа-яА-ЯёЁ\s\-]*$").WithMessage("Отчество содержит недопустимые символы")
                .When(x => !string.IsNullOrEmpty(x.MiddleName));

            RuleFor(x => x.BirthDate)
                .Must(date => date != default(DateTime)).WithMessage("Введите корректную дату в формате дд.мм.гггг")
                .LessThan(DateTime.Now.AddYears(-14)).WithMessage("Возраст должен быть не менее 14 лет")
                .GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Возраст должен быть не более 100 лет");

            RuleFor(x => x.Location)
                .MaximumLength(200).WithMessage("Место проживания не должно превышать 200 символов");

            RuleFor(x => x.PositionId)
                .GreaterThan(0).WithMessage("Должность обязательна для заполнения");
        }
    }
}
