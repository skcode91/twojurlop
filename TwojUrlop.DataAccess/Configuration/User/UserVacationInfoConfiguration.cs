using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DataAcess.Configuration;
public class UserVacationInfoConfiguration : IEntityTypeConfiguration<UserVacationInfo>
{
    public void Configure(EntityTypeBuilder<UserVacationInfo> builder)
    {
        builder.ToTable("UserVacationInfo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.VacationSizeId).IsRequired(true);
        builder.Property(x => x.YearId).IsRequired(true);
        builder.Property(x => x.DaysLeft).IsRequired(true);

        builder.HasOne(x => x.User)
            .WithMany(y => y.UserVacationInfos)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Year)
            .WithMany(y => y.UserVacationInfos)
            .HasForeignKey(x => x.YearId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.VacationSize)
            .WithMany(y => y.VacationInfos)
            .HasForeignKey(x => x.VacationSizeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}