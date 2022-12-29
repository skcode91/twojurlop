namespace TwojUrlop.Common.Models.Entities;
public class VacationYear
{
    public virtual Vacation Vacation { get; set; } = default!;
    public int VacationId { get; set; }
    public virtual Year Year { get; set; } = default!;
    public int YearId { get; set; }
}