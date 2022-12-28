namespace TwojUrlop.DomainModel.Vacation.Commands.HandleVacationRequest;

public interface IHandleVacationRequestHandler
{
    Task Handle(HandleVacationRequestRequest request);
}