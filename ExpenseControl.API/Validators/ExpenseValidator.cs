using ExpenseControl.API.Validators.Base;
using ExpenseControl.Application;
using FluentValidation;

namespace ExpenseControl.API.Validators
{
    public class ExpenseValidator : BaseValidator<Requests.Expense>
    {
        public ExpenseValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Amount)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0).WithMessage("Valor deve ser maior que zero");

            RuleFor(x => x.Type)
                .NotEmpty()
                .NotNull()
                .Must(type => new List<int> { 1, 2 }.Any(x => x == type)).WithMessage("Tipo deve ser (1)Fixo ou (2)Variavel");

            RuleFor(x => x.ExpirationDate)
                .NotEmpty()
                .NotNull();
        }
    }
}
