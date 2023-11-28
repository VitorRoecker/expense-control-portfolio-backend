using ExpenseControl.Application.ViewModels.Base;
using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Enumerables;

namespace ExpenseControl.Application.ViewModels
{
    public class ExpenseViewModel : BaseViewModel<ExpenseViewModel, Expense>
    {
        public Guid Id { get; set; }
        public DateTime InclusionDate { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionTypeEnum Type { get; set; }
        public string? UserId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public override Expense ConvertToDomain()
            => new()
            {
                Id = Id,
                InclusionDate = InclusionDate,
                Description = Description,
                Amount = Amount,
                Type = Type,
                UserId = UserId,
                CategoryId = CategoryId,
                ExpirationDate = ExpirationDate,
            };

        public override ExpenseViewModel ConvertToViewModel(Expense domain)
            => new()
            {
                Id = domain.Id,
                InclusionDate = domain.InclusionDate,
                Description = domain.Description,
                Amount = domain.Amount,
                Type = domain.Type,
                UserId = domain.UserId,
                CategoryId = domain.CategoryId,
                ExpirationDate = domain.ExpirationDate,
            };

        public override Expense CreateDomain()
            => new()
            {
                Description = Description,
                Amount = Amount,
                Type = Type,
                UserId = UserId,
                CategoryId = CategoryId,
                ExpirationDate = ExpirationDate,
            };
    }
}
