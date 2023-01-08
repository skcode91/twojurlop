namespace TwojUrlop.DomainModel.User.Queries.GetUserBaseInfo;
public interface IGetUserBaseInfoHandler
{
    Task<GetUserBaseInfoResponse> Handle(GetUserBaseInfoRequest request);
}