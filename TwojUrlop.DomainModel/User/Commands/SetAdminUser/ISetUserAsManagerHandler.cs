namespace TwojUrlop.DomainModel.User.Commands.SetUserAsMenager;

public interface ISetUserAsMenagerHandler
{
    Task Handle(SetUserAsMenagerRequest request);
}