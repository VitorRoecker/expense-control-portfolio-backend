using ExpenseControl.Domain.Entities.Base;

namespace ExpenseControl.Domain.Entities
{
    public class Expense : Transaction
    {
        public DateTime? ExpirationDate { get; set; }
    }
}
