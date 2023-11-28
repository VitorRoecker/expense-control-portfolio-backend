using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ExpenseControl.Domain.Entities;

namespace ExpenseControl.Infra.Mappings
{
    public class ExpenseMap : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description).HasMaxLength(255).IsRequired();
            builder.Property(e => e.Amount).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(e => e.CategoryId).IsRequired();
            builder.Property(e => e.ExpirationDate).IsRequired();
            builder.Property(e => e.InclusionDate).IsRequired();

            builder.HasOne(e => e.User)
                   .WithMany(u => u.Expenses)
                   .HasForeignKey(e => e.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
