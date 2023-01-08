namespace TwojUrlop.DomainModel.User.Queries.GetUserVacationYearInfo;
public interface IGetUserVacationYearInfoHandler
{
    Task<GetUserVacationYearInfoResponse> Handle(GetUserVacationYearInfoRequest request);
}