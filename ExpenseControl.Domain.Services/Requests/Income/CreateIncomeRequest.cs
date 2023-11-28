using ExpenseControl.Domain.Enumerables;

namespace ExpenseControl.Domain.Services.Requests.Income
{
    public record CreateIncomeRequest
    {
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionTypeEnum Type { get; set; }
        public string? UserId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
