namespace TwojUrlop.DomainModel.User.Commands.ChangeUserStatus;
public class ChangeUserStatusRequest
{
    public int CurrentUserId { get; set; }
    public int UserId { get; set; }
    public int StatusId { get; set; }
}