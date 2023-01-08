namespace TwojUrlop.DomainModel.User.Commands.ChangeUserRole;
public class ChangeUserRoleRequest
{
    public int CurrentUserId { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
}