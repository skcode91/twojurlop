namespace TwojUrlop.Common.Models.Entities;
public class UserVacationInfo
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public int YearId { get; set; } = default!;
    public virtual Year Year { get; set; } = default!;
    public int DaysLeft { get; set; }
    public int VacationSizeId { get; set; }
    public virtual VacationSize VacationSize { get; set; } = default!;
}