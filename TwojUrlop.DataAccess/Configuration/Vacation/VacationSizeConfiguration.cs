using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DataAcess.Configuration;
public class VacationSizeConfiguration : IEntityTypeConfiguration<VacationSize>
{
    public void Configure(EntityTypeBuilder<VacationSize> builder)
    {
        builder.ToTable("VacationSize");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Value).IsRequired(true);

        builder.HasMany(x => x.VacationInfos)
            .WithOne(x => x.VacationSize)
            .HasForeignKey(y => y.VacationSizeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}