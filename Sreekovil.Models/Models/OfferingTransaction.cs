using System;

namespace Sreekovil.Models.Models
{
    public class OfferingTransaction : Base
    {
        public int TempleId { get; set; }

        public int OfferingId { get; set; }

        public int StarSignId { get; set; }

        public string Name { get; set; }

        public string Remarks { get; set; }

        public DateTime Date { get; set; }

        public string OfferingName { get; set; }

        public string StarSignName { get; set; }

        public string DeityName { get; set; }

        public Temple Temple { get; set; }

        public Offering Offering { get; set; }
    }
}
