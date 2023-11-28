using ExpenseControl.Domain.Entities.Identity;
using ExpenseControl.Domain.Enumerables;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseControl.Domain.Entities.Base
{
    public abstract class Transaction : EntityBase
    {
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionTypeEnum Type { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        public string? UserId { get; set; }
        public Guid CategoryId { get; set; }
        public User? User { get; set; }
    }
}
