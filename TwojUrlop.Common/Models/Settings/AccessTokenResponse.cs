namespace TwojUrlop.Common.Models.Settings;
public class AccessTokenResponse
{
    public required string AccessToken { get; set; }
    public DateTime ExpiresIn { get; set; }
}

