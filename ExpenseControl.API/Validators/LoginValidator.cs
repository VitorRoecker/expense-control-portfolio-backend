﻿using ExpenseControl.API.Validators.Base;
using ExpenseControl.Application;
using FluentValidation;

namespace ExpenseControl.API.Validators
{
    public class LoginValidator : BaseValidator<Requests.Login>
    {
        public LoginValidator()
        {
            RuleFor(x => x.DocumentoFederal)
                .NotNull()
                .NotEmpty()
                .Must(BeAValidCpf).WithMessage("CPF inválido.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres.")
                .Matches("[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
                .Matches("[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula.")
                .Matches("[0-9]").WithMessage("A senha deve conter pelo menos um número.")
                .Matches("[^a-zA-Z0-9]").WithMessage("A senha deve conter pelo menos um caractere especial.");
        }
    }
}
