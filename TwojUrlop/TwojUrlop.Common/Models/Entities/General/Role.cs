using Microsoft.AspNetCore.Identity;

namespace TwojUrlop.Common.Models.Entities;
public class Role : IdentityRole<int>
{
    public virtual ICollection<UserRole> UserRoles { get; set; } = default!;
    public virtual IEnumerable<User> Users { get; set; } = default!;
}