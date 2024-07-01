using ExpenseControl.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.Infra.Mappings
{
    public class IncomeMap : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Description).HasMaxLength(255).IsRequired();
            builder.Property(i => i.Amount).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(i => i.CategoryId).IsRequired();
            builder.Property(i => i.InclusionDate).IsRequired();
            builder.Property(i => i.EntryDate).IsRequired();

            builder.HasOne(i => i.User)
                   .WithMany(u => u.Incomes)
                   .HasForeignKey(i => i.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
