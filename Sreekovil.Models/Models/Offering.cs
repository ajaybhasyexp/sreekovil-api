namespace Sreekovil.Models.Models
{
    public class Offering : Base
    {
        /// <summary>
        /// Name of the offering.
        /// </summary>
        public string OfferingName { get; set; }

        /// <summary>
        /// The identifier for temple.
        /// </summary>
        public int TempleId { get; set; }

        public decimal Price { get; set; }

        public int DeityId { get; set; }

        public string OfferingCode { get; set; }

        public int MaxPerDay { get; set; }

        public bool IsBookable { get; set; }

    }
}
