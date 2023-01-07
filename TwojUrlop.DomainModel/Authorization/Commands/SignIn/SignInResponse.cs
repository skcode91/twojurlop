
using TwojUrlop.Common.Models.Settings;
using Enums = TwojUrlop.Common.Enums;

namespace TwojUrlop.DomainModel.Authorization.Commands.SignIn;
public class SignInResponse : AccessTokenResponse
{
    public int RoleId { get; set; }
    public int UserId { get; set; }
}