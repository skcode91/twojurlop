namespace TwojUrlop.Common.Models.Entities;
public class Vacation
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DaysCount { get; set; }
    public virtual IList<UserVacation> UserVacations { get; set; } = default!;
    public virtual IList<VacationYear> VacationYears { get; set; } = default!;
}