using System.Text;

namespace ShopManager.Core.Domain;

public class AuthConfig
{
    public string JwtIssuer { get; set; } = "ZWH";
    public string JwtAudience { get; set; } = "ZWH";
    public byte[] SecretKey { get; set; } = Encoding.UTF8.GetBytes("SparklingWaterInc");
}