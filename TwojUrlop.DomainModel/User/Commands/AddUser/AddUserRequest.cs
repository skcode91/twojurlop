namespace TwojUrlop.DomainModel.User.Commands.AddUser;

public class AddUserRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public int GenderId { get; set; }
    public int pESEL { get; set; }
    public int NumberOfYearsWorkedOnHiringDate {get; set;}
    public DateTime HiringDate {get; set;}
    public required int CurrentUserId {get; set;}
}