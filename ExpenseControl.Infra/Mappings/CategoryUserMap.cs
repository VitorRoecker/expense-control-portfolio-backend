using ExpenseControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControl.Infra.Mappings
{
    public class CategoryUserMap : IEntityTypeConfiguration<CategoryUser>
    {
        public void Configure(EntityTypeBuilder<CategoryUser> builder)
        {
            builder.ToTable("CategoriesUsers");

            builder.HasKey(cu => cu.Id);

            builder.Property(cu => cu.CategoryId);


            builder.HasOne(cu => cu.User)
                .WithMany(u => u.CategoriesUsers)
                .HasForeignKey(cu => cu.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cu => cu.Category)
                .WithMany(c => c.CategoriesUsers)
                .HasForeignKey(cu => cu.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(cu => new { cu.UserId, cu.CategoryId }).IsUnique();
        }
    }
}
