namespace TwojUrlop.DomainModel.Vacation.Queries.GetVacations;
using Enums = TwojUrlop.Common.Enums;

public class VacationsResponseItem
{
    public int Id{get; set;}
    public int UserId{get; set;}
    public DateTime StartDate {get; set;}
    public DateTime EndDate {get; set;}
    public int DaysCount {get; set;}
    public Enums.VacationRequestStatus Status { get; set; }
    public int StatusId { get; set; }
}