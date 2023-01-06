namespace TwojUrlop.DomainModel.Vacation.Queries.GetVacations;

public interface IGetVacationsHandler
{
    Task<GetVacationsResponse> Handle(GetVacationsRequest request);
}