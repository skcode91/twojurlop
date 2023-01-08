namespace TwojUrlop.DomainModel.Vacation.Queries.GetVacationRequests;
using Enums = TwojUrlop.Common.Enums;
public class VacationRequestResponseItem
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public required string UserFullName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DaysCount { get; set; }
    public int StatusId { get; set; }
    public Enums.VacationRequestStatus Status { get; set; }
}