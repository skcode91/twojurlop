namespace TwojUrlop.Common.Models.Entities;
public class Vacation
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DaysCount { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public virtual IList<VacationYear> VacationYears { get; set; } = default!;
}