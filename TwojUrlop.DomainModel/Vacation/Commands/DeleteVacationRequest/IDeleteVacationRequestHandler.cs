namespace TwojUrlop.DomainModel.Vacation.Commands.DeleteVacationRequest;
public interface IDeleteVacationRequestHandler
{
    Task Handle(DeleteVacationRequestRequest request);
}