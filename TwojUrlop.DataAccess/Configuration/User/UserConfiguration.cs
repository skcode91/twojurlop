using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DataAcess.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.PESEL).IsRequired();

        builder.HasMany(x => x.Vacations)
            .WithOne(y => y.User)
            .HasForeignKey(y => y.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.VacationRequests)
            .WithOne(y => y.User)
            .HasForeignKey(y => y.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.UserVacationInfos)
            .WithOne(y => y.User)
            .HasForeignKey(y => y.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}