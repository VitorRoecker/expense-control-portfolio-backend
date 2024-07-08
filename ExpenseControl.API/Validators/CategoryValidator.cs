using ExpenseControl.API.Validators.Base;
using ExpenseControl.Application;
using FluentValidation;

namespace ExpenseControl.API.Validators
{
    public class CategoryValidator : BaseValidator<Requests.Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Type)
                .NotEmpty()
                .NotNull()
                .Must(type => new List<int> { 1, 2 }.Any(x => x == type)).WithMessage("Tipo deve ser (1)Gasto ou (2)Renda");
        }
    }
}
