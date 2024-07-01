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

            builder.HasOne(e => e.User)
                   .WithMany(u => u.Categories)
                   .HasForeignKey(e => e.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
