namespace Sreekovil.Models.Models
{
    public class Deity : Base
    {
        public int DeityName { get; set; }

        public bool IsMain { get; set; }

        public string Description { get; set; }

        public int TempleId { get; set; }
    }
}
