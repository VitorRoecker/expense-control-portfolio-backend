using ExpenseControl.Domain.Entities.Base;

namespace ExpenseControl.Domain.Entities
{
    public class Income : Transaction
    {
        public DateTime EntryDate { get; set; }
    }
}
