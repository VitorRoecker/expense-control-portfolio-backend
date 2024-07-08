using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Entities.Identity;
using ExpenseControl.Domain.Exceptions;
using ExpenseControl.Domain.Services.Base;
using ExpenseControl.Domain.Services.Interfaces.Services;
using ExpenseControl.Domain.Services.Interfaces.Services.Identity;
using Microsoft.AspNetCore.Identity;

namespace ExpenseControl.Domain.Services.Services
{
    public class UserService(UserManager<User> _userManager, IJwtService _jwtService) : IUserService
    {
        public async Task<UserToken> CreateUser(Requests.CreateUser request)
        {
            if (!Util.ValidaDocumento(request.DocumentoFederal))
                throw new ExpenseControlException("O documento federal informado não é válido. Revise as informações e tente novamente");

            User? entity;

            entity = await _userManager.FindByEmailAsync(request.Email);
            if (entity is not null)
                throw new ExpenseControlException("Email já cadastrado");

            entity = await _userManager.FindByNameAsync(request.DocumentoFederal);
            if (entity is not null)
                throw new ExpenseControlException("O documento já cadastrado.");

            var user = new User
            {
                UserName = Util.DeixaNumeros(request.DocumentoFederal),
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new ExpenseControlException($"Erro ao registrar usuário: {result.Errors}");

            return _jwtService.BuildToken(user);
        }

        public async Task DeleteUser(Requests.DeleteUser request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId) ?? throw new ExpenseControlException("Usuário não encontrado.");

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
                throw new ExpenseControlException("Erro ao excluir usuário");
        }
    }
}
