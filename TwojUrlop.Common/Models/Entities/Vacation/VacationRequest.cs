namespace TwojUrlop.Common.Models.Entities;
public class VacationRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DaysCount { get; set; }
    public int StatusId { get; set; }
    public virtual VacationRequestStatus Status { get; set; } = default!;
    public virtual IList<VacationRequestYear> VacationRequestYears { get; set; } = default!;
}