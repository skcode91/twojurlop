namespace TwojUrlop.Common.Models.Entities;
public class VacationRequestYear
{
    public int VacationRequestId { get; set; }
    public virtual VacationRequest VacationRequest { get; set; } = default!;
    public int YearId { get; set; }
    public virtual Year Year { get; set; } = default!;
}