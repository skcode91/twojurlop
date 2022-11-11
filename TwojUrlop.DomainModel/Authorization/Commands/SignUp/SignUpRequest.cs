namespace TwojUrlop.DomainModel.Authorization.Commands.SignUp;
public class SignUpRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public int GenderId { get; set; }
    public int PESEL { get; set; }
}
