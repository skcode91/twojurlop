using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DataAcess.Configuration.General;
public class YearConfiguration : IEntityTypeConfiguration<Year>
{
    public void Configure(EntityTypeBuilder<Year> builder)
    {
        builder.ToTable("Year");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Value).IsUnique();

        builder.HasMany(x => x.UserVacationInfos)
            .WithOne(y => y.Year)
            .HasForeignKey(y => y.YearId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.VacationRequestYears)
            .WithOne(y => y.Year)
            .HasForeignKey(y => y.YearId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Vacations)
            .WithOne(y => y.Year)
            .HasForeignKey(y => y.YearId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}