using TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DomainModel.Vacation.Interfaces;

public interface IVacationRequestHandler
{
    Task<string> Handle(VacationRequest request);
}