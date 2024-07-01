using Microsoft.AspNetCore.Identity;

namespace ExpenseControl.Domain.Entities.Identity
{
    public class User : IdentityUser
    {
        public ICollection<Expense>? Expenses { get; set; }
        public ICollection<Income>? Incomes { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
