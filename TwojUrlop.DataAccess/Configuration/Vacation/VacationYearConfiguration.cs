using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwojUrlop.Common.Models.Entities;

public class VacationRequestYearConfiguration : IEntityTypeConfiguration<VacationYear>
{
    public void Configure(EntityTypeBuilder<VacationYear> builder)
    {
        builder.ToTable("VacationYear");

        builder.HasKey(x => new { x.VacationId, x.YearId });

        builder.HasOne(x => x.Vacation)
            .WithMany(y => y.VacationYears)
            .HasForeignKey(x => x.VacationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Year)
            .WithMany(y => y.VacationYears)
            .HasForeignKey(x => x.YearId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}