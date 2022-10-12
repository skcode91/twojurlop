using Microsoft.AspNetCore.Identity;

namespace TwojUrlop.Common.Models.Entities;
public class Role : IdentityRole<int>
{
    public ICollection<UserRole> UserRoles { get; set; }
    public IEnumerable<User> Users { get; set; }
}