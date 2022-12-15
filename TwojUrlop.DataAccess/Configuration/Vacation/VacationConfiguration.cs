using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DataAcess.Configuration;
public class VacationConfiguration : IEntityTypeConfiguration<Vacation>
{
    public void Configure(EntityTypeBuilder<Vacation> builder)
    {
        builder.ToTable("Vacation");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.StartDate).IsRequired(true);
        builder.Property(x => x.EndDate).IsRequired(true);
        builder.Property(x => x.DaysCount).IsRequired(true);

        builder.HasMany(x => x.UserVacations)
            .WithOne(y => y.Vacation)
            .HasForeignKey(y => y.VacationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Year)
            .WithMany(y => y.Vacations)
            .HasForeignKey(x => x.YearId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}