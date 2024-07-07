using ExpenseControl.Domain.Enumerables;
using DomainRequest = ExpenseControl.Domain.Services.Requests;

namespace ExpenseControl.Application
{
    public static class Requests
    {
        public record Category(string UserId, string Name, string Description, int Type)
        {
            public static implicit operator Domain.Entities.Category(Category request)
                => new()
                {
                    UserId = request.UserId,
                    Name = request.Name,
                    Description = request.Description,
                    Type = (CategoryTypeEnum)request.Type
                };
        }

        public record Expense(string UserId, Guid CategoryId, string Description, decimal Amount, int Type, DateTime ExpirationDate)
        {
            public static implicit operator Domain.Entities.Expense(Expense request)
                => new()
                {
                    UserId = request.UserId,
                    CategoryId = request.CategoryId,
                    Description = request.Description,
                    Amount = request.Amount,
                    Type = (TransactionTypeEnum)request.Type,
                    ExpirationDate = request.ExpirationDate
                };
        }

        public record Income(string UserId, Guid CategoryId, string Description, decimal Amount, int Type, DateTime EntryDate)
        {
            public static implicit operator Domain.Entities.Income(Income request)
                => new()
                {
                    UserId = request.UserId,
                    CategoryId = request.CategoryId,
                    Description = request.Description,
                    Amount = request.Amount,
                    Type = (TransactionTypeEnum)request.Type,
                    EntryDate = request.EntryDate
                };
        }

        public record Register(string DocumentoFederal, string Email, string PhoneNumber, string Password)
        {
            public static implicit operator DomainRequest.CreateUser(Register request)
                => new(request.DocumentoFederal, request.Email, request.PhoneNumber, request.Password);
        }

        public record DeleteUser(string UserId)
        {
            public static implicit operator DomainRequest.DeleteUser(DeleteUser request)
                => new(request.UserId);
        }

        public record Login(string DocumentoFederal, string Password)
        {
            public static implicit operator DomainRequest.Login(Login request)
                => new(request.DocumentoFederal, request.Password);
        }
    }
}
