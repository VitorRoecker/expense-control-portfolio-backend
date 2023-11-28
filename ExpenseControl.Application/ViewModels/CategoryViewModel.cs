using ExpenseControl.Application.ViewModels.Base;
using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Enumerables;

namespace ExpenseControl.Application.ViewModels
{
    public class CategoryViewModel : BaseViewModel<CategoryViewModel, Category>
    {
        public Guid Id { get; set; }
        public DateTime InclusionDate { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public CategoryTypeEnum Type { get; set; }
        public Guid CategoryUserId { get; set; }

        public override Category ConvertToDomain()
            => new()
            {
                Id = Id,
                InclusionDate = InclusionDate,
                Name = Name,
                Description = Description,
                Type = Type,
                CategoryUserId = CategoryUserId,
            };

        public override CategoryViewModel ConvertToViewModel(Category domain)
            => new()
            {
                Id = domain.Id,
                InclusionDate = domain.InclusionDate,
                Name = domain.Name,
                Description = domain.Description,
                Type = domain.Type,
                CategoryUserId = domain.CategoryUserId,
            };

        public override Category CreateDomain()
            => new()
            {
                Name = Name,
                Description = Description,
                Type = Type,
                CategoryUserId = CategoryUserId,
            };
    }
}
