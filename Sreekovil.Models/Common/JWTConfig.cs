namespace Sreekovil.Models.Common
{
    public class JWTConfig
    {
        public string Secret { get; set; }

        public int ExpiryDays { get; set; }
    }
}
