namespace TwojUrlop.Common.Models.Settings;
public class SecuritySettings
{
    public required string XCSRFHeader { get; set; }
    public required string CORSOrigin { get; set; }
    public required string CookieAllowCredentials { get; set; }
}
