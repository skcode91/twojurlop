namespace TwojUrlop.DomainModel.Authorization.Commands.SignUp;
public interface ISignUpHandler
{
    public Task Handle(SignUpRequest request);
}
