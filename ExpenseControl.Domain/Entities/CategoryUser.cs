using ExpenseControl.Domain.Entities.Base;
using ExpenseControl.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseControl.Domain.Entities
{
    public class CategoryUser : EntityBase
    {
        [Column(TypeName = "nvarchar(450)")]
        public string? UserId { get; set; }
        public Guid CategoryId { get; set; }

        public Category? Category { get; set; }
        public User? User { get; set; }
    }
}