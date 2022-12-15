using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DataAcess.Configuration;
public class UserVacationConfiguration : IEntityTypeConfiguration<UserVacation>
{
    public void Configure(EntityTypeBuilder<UserVacation> builder)
    {
        builder.ToTable("UserVacation");

        builder.HasKey(x => new { x.UserId, x.VacationId });

        builder.HasOne(x => x.User)
            .WithMany(y => y.UserVacations)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Vacation)
            .WithMany(y => y.UserVacations)
            .HasForeignKey(x => x.VacationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}