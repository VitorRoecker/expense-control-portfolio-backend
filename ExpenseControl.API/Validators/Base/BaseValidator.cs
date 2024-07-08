using DocumentValidator;
using FluentValidation;

namespace ExpenseControl.API.Validators.Base
{
    public class BaseValidator<T> : AbstractValidator<T> where T : class
    {
        protected static bool BeAValidCnpj(string cnpj)
            => CnpjValidation.Validate(cnpj);

        protected static bool BeAValidCpf(string cpf)
            => CpfValidation.Validate(cpf);
    }
}
