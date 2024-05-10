using ExpenseControl.Domain.Entities.Identity;
using ExpenseControl.Domain.Exceptions;
using ExpenseControl.Domain.Services.Base;
using ExpenseControl.Domain.Services.Interfaces.Services;
using ExpenseControl.Domain.Services.Interfaces.Services.Identity;
using ExpenseControl.Domain.Services.Requests;
using ExpenseControl.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace ExpenseControl.Domain.Services.Services
{
    public class UserService(UserManager<User> _userManager, IJwtService _jwtService) : IUserService
    {
        public async Task<UserToken> CreateUser(CreateUserRequest userRequest)
        {
            if (!Util.ValidaDocumento(userRequest.DocumentoFederal))
                throw new ExpenseControlException("O documento federal informado não é válido. Revise as informações e tente novamente");

            userRequest.DocumentoFederal = Util.DeixaNumeros(userRequest.DocumentoFederal);

            User? entity;

            entity = await _userManager.FindByEmailAsync(userRequest.Email);
            if (entity is not null)
                throw new ExpenseControlException("O email informado já está sendo utilizado por outro usuário");

            entity = await _userManager.FindByNameAsync(userRequest.DocumentoFederal);
            if (entity is not null)
                throw new ExpenseControlException("O documento federal informado já está sendo utilizado por outro usuário");

            var user = new User
            {
                UserName = userRequest.DocumentoFederal,
                Email = userRequest.Email,
                PhoneNumber = userRequest.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, userRequest.Password);

            if (!result.Succeeded)
                throw new ExpenseControlException($"Erro ao registrar usuário: {result.Errors}");

            return _jwtService.BuildToken(user);
        }
    }
}
