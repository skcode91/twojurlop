using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DataAcess.Configuration;

public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.ToTable("Gender");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasMaxLength(32)
            .IsRequired();

        builder.HasMany(x => x.Users)
            .WithOne(y => y.Gender)
            .HasForeignKey(y => y.GenderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}