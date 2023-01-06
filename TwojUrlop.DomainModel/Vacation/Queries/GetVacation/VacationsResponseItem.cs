namespace TwojUrlop.DomainModel.Vacation.Queries.GetVacations;

public class VacationsResponseItem
{
    public int Id{get; set;}
    public int UserId{get; set;}
    public DateTime StartDate {get; set;}
    public DateTime EndDate {get; set;}
    public int DaysCount {get; set;}
    
}