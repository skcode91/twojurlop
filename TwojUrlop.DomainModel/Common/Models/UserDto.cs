using TwojUrlop.Common.Enums;

namespace TwojUrlop.DomainModel.Common;
public class UserDto
{
    public required string Email { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int RoleId { get; set; }
    public int PESEL { get; set; }
    public DateTime HiringDate { get; set; }
    public int NumberOfYearsWorkedOnHiringDate { get; set; }
    public int GenderId { get; set; }
}