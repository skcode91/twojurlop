namespace TwojUrlop.DomainModel.Authorization.Queries;
public interface IGetUsersFullnameHandler
{
    public Task<List<string>> Handle();
}
