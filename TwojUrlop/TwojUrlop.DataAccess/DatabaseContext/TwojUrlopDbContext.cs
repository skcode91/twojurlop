using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TwojUrlop.Common.Models.Entities;
using TwojUrlop.Common.Models.Interfaces;
using TwojUrlop.DataAccess.Seeds;

namespace TwojUrlop.DataAccess.DatabaseContext;

public class TwojUrlopDbContext :
    IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>,
        IdentityUserToken<int>>, ITwojUrlopDbContext, IDataProtectionKeyContext
{
    public TwojUrlopDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<DataProtectionKey> DataProtectionKeys => Set<DataProtectionKey>();
    public DbSet<User> User => Set<User>();
    public DbSet<Role> Role => Set<Role>();
    public DbSet<Gender> Gender => Set<Gender>();


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasPostgresExtension("uuid-ossp");
        modelBuilder.HasPostgresExtension("pg_trgm");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TwojUrlopDbContext).Assembly);
        SeedConfiguration.Seed(modelBuilder);
    }

}