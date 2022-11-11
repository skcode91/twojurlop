using Microsoft.AspNetCore.Identity;
using TwojUrlop.Common.Enums;

namespace TwojUrlop.Common.Models.Entities;
public class User : IdentityUser<int>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int PESEL { get; set; } = default!;
    public virtual Role Role { get; set; } = default!;
    public DateTime CreateDateTime { get; set; }
    public int GenderId { get; set; }
    public virtual Gender Gender { get; set; } = default!;
    public int RoleId { get; set; }
}