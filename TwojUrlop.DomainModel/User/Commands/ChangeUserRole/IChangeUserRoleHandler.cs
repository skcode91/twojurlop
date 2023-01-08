namespace TwojUrlop.DomainModel.User.Commands.ChangeUserRole;
public interface IChangeUserRoleHandler
{
    Task Handle(ChangeUserRoleRequest request);
}