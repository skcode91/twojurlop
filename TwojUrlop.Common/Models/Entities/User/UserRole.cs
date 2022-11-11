using Microsoft.AspNetCore.Identity;

namespace TwojUrlop.Common.Models.Entities;
public class UserRole : IdentityUserRole<int>
{
    public User User { get; set; } = default!;
    public Role Role { get; set; } = default!;
}