namespace TwojUrlop.DomainModel.Vacation.Queries.GetVacationRequests;
public interface IGetVacationRequestsHandler
{
    Task<GetVacationRequestsResponse> Handle(GetVacationRequestsRequest request);
}