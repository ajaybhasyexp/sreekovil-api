namespace Sreekovil.Models.Models
{
    public class User : Base
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public int TempleId { get; set; }

        //[Write(false)]
        public string Token { get; set; }

        //[Write(false)]
        public Temple Temple { get; set; }
    }
}
