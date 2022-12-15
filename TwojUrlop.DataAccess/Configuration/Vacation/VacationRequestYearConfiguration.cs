using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DataAcess.Configuration;
public class VacationRequestYearConfiguration : IEntityTypeConfiguration<VacationRequestYear>
{
    public void Configure(EntityTypeBuilder<VacationRequestYear> builder)
    {
        builder.ToTable("VacationRequestYear");

        builder.HasKey(x => new { x.VacationRequestId, x.YearId });

        builder.HasOne(x => x.VacationRequest)
            .WithMany(y => y.VacationRequestYears)
            .HasForeignKey(x => x.VacationRequestId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Year)
            .WithMany(y => y.VacationRequestYears)
            .HasForeignKey(x => x.YearId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}