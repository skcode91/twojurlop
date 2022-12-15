namespace TwojUrlop.Common.Models.Entities;
public class VacationRequestStatus
{
    public int Id { get; set; }
    public required string Value { get; set; }
    public virtual IList<VacationRequest> VacationRequests { get; set; } = default!;
}