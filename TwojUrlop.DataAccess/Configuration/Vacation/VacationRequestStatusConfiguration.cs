using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DataAcess.Configuration;
public class VacationRequestStatusConfiguration : IEntityTypeConfiguration<VacationRequestStatus>
{
    public void Configure(EntityTypeBuilder<VacationRequestStatus> builder)
    {
        builder.ToTable("VacationRequestStatus");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Value).IsRequired(true);

        builder.HasMany(x => x.VacationRequests)
            .WithOne(y => y.Status)
            .HasForeignKey(y => y.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}