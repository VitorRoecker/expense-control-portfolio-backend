using ExpenseControl.Domain.Entities.Base;
using ExpenseControl.Domain.Entities.Identity;
using ExpenseControl.Domain.Enumerables;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseControl.Domain.Entities
{
    public class Category : EntityBase 
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public CategoryTypeEnum Type { get; set; }
        [Column(TypeName = "nvarchar(450)")]
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}