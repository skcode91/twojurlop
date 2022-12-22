namespace TwojUrlop.DomainModel.Vacation.Commands.SendVacationRequest;

public class SendVacationRequestRequest
{
    public int UserId {get; set;}
    public DateTime StartDate {get; set;}
    public DateTime EndDate {get; set;}
    public int DaysCount {get; set;}
}