using Enums = TwojUrlop.Common.Enums;

namespace TwojUrlop.DomainModel.Vacation.Commands.HandleVacationRequest;

public class HandleVacationRequestRequest
{
    public int UserId {get; set;}
    public int VacationRequestId {get; set;}
    public Enums.VacationRequestStatus newRequestStatus {get; set;}
}