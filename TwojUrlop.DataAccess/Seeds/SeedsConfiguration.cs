using Microsoft.EntityFrameworkCore;
using TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DataAccess.Seeds;
public class SeedConfiguration
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gender>().HasData(GenderSeed.Seed());
        modelBuilder.Entity<Role>().HasData(RoleSeed.Seed());
    }
}

