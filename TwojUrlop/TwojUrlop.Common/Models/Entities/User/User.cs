using Microsoft.AspNetCore.Identity;

namespace TwojUrlop.Common.Models.Entities;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int PESEL { get; set; }
    public Role Role { get; set; }
    public int RoleId { get; set; }
}