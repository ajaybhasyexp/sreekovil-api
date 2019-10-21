namespace Sreekovil.Models.Common
{
    public class JWTConfig
    {
        public string Secret { get; set; }

        public int ExpiryInMinutes { get; set; }
    }
}
