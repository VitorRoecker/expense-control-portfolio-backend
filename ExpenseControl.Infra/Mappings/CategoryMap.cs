using ExpenseControl.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.Infra.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => new { c.Id });

            builder.Property(c => c.Name).HasMaxLength(255);
            builder.Property(c => c.Description).HasMaxLength(255);
            builder.Property(c => c.Type).IsRequired();

            builder.HasMany(c => c.CategoriesUsers)
                   .WithOne(cu => cu.Category)
                   .HasForeignKey(cu => cu.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(c => c.CategoryUserId);
        }
    }
}
