using System.Text;

namespace ShopManager.Infrastructure.Data.Config;

public class AuthConfig
{
    public string JwtIssuer { get; set; } = "ZWH";
    public string JwtAudience { get; set; } = "ZWH";
    public byte[] SecretKey { get; set; } = Encoding.UTF8.GetBytes("SparklingWaterInc");
}
