using TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DomainModel.Vacation.Commands.SendVacationRequest;

public interface ISendVacationRequestHandler
{
    Task Handle(SendVacationRequestRequest request);
}