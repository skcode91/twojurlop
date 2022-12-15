namespace TwojUrlop.Common.Models.Entities;
public class UserVacation
{
    public int UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public int VacationId { get; set; }
    public virtual Vacation Vacation { get; set; } = default!;
}