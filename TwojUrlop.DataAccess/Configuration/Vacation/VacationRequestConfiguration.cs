using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DataAcess.Configuration;
public class VacationRequestConfiguration : IEntityTypeConfiguration<VacationRequest>
{
    public void Configure(EntityTypeBuilder<VacationRequest> builder)
    {
        builder.ToTable("VacationRequest");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.StartDate).IsRequired(true);
        builder.Property(x => x.EndDate).IsRequired(true);
        builder.Property(x => x.DaysCount).IsRequired(true);

        builder.HasOne(x => x.User)
            .WithMany(y => y.VacationRequests)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Status)
            .WithMany(y => y.VacationRequests)
            .HasForeignKey(x => x.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}