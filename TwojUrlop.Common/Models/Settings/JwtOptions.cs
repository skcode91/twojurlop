namespace TwojUrlop.Common.Models.Settings;
public class JwtOptions
{
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public string SecretKey { get; set; } = default!;
    public int TokenExpirationMinutes { get; set; }
}
