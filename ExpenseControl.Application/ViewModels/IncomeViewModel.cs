using ExpenseControl.Application.ViewModels.Base;
using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Enumerables;

namespace ExpenseControl.Application.ViewModels
{
    public class IncomeViewModel : BaseViewModel<IncomeViewModel, Income>
    {
        public Guid Id { get; set; }
        public DateTime InclusionDate { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionTypeEnum Type { get; set; }
        public string? UserId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime EntryDate { get; set; }

        public override Income ConvertToDomain()
            => new()
            {
                Id = Id,
                InclusionDate = InclusionDate,
                Description = Description,
                Amount = Amount,
                Type = Type,
                UserId = UserId,
                EntryDate = EntryDate,
                CategoryId = CategoryId,
            };

        public override IncomeViewModel ConvertToViewModel(Income domain)
            => new()
            {
                Id = domain.Id,
                InclusionDate = domain.InclusionDate,
                Description = domain.Description,
                Amount = domain.Amount,
                Type = domain.Type,
                UserId = domain.UserId,
                EntryDate = domain.EntryDate,
                CategoryId = domain.CategoryId,
            };

        public override Income CreateDomain()
            => new()
            {
                Description = Description,
                Amount = Amount,
                Type = Type,
                UserId = UserId,
                EntryDate = EntryDate,
                CategoryId = CategoryId,
            };
    }
}
