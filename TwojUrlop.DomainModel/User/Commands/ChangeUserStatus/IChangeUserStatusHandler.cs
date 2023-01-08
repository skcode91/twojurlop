namespace TwojUrlop.DomainModel.User.Commands.ChangeUserStatus;
public interface IChangeUserStatusHandler
{
    Task Handle(ChangeUserStatusRequest request);
}