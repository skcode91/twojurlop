using Microsoft.AspNetCore.Identity;

namespace TwojUrlop.Common.Models.Entities;
public class User : IdentityUser<int>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int PESEL { get; set; }
    public int YearsOfWork { get; set; }
    public DateTime CreateDateTime { get; set; }
    public int GenderId { get; set; }
    public virtual Gender Gender { get; set; } = default!;
    public int RoleId { get; set; }
    public virtual Role Role { get; set; } = default!;
    public virtual IList<UserVacation> UserVacations { get; set; } = default!;
    public virtual IList<VacationRequest> VacationRequests { get; set; } = default!;
    public virtual IList<UserVacationInfo> UserVacationInfos { get; set; } = default!;
}