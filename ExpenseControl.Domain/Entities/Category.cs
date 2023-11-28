using ExpenseControl.Domain.Entities.Base;
using ExpenseControl.Domain.Enumerables;

namespace ExpenseControl.Domain.Entities
{
    public class Category : EntityBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public CategoryTypeEnum Type { get; set; }
        public Guid CategoryUserId { get; set; }

        public ICollection<CategoryUser>? CategoriesUsers { get; set; }
    }
}