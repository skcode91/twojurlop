using TwojUrlop.DomainModel.Common;

namespace TwojUrlop.DomainModel.User.Queries.GetUsers;
public interface IGetUsersHandler
{
    Task<IEnumerable<UserDto>> Handle(GetUsersRequest request);
}