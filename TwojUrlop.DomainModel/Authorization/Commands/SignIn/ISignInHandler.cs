namespace TwojUrlop.DomainModel.Authorization.Commands.SignIn;
public interface ISignInHandler
{
    Task<SignInResponse> Handle(SignInRequest request);
}
