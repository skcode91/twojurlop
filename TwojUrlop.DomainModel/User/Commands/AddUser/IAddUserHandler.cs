namespace TwojUrlop.DomainModel.User.Commands.AddUser;

public interface IAddUserHandler
{
    Task Handle(AddUserRequest request);
}