using Dapper.Contrib.Extensions;

namespace Sreekovil.Models.Models
{
    /// <summary>
    /// The offering entity.
    /// </summary>
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

        /// <summary>
        /// The price to be paid to avail the offering.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The id of the deity against which this offering is performed.
        /// </summary>
        public int DeityId { get; set; }

        /// <summary>
        /// The code that represents the offering.
        /// </summary>
        public string OfferingCode { get; set; }

        /// <summary>
        /// The maximum number of offerings per day. No restriction if value is 0.
        /// </summary>
        public int MaxPerDay { get; set; }

        /// <summary>
        /// Denotes if the offering is bookable.
        /// </summary>
        public bool IsBookable { get; set; }

        /// <summary>
        /// The name of the diety whom this offering is performed against.
        /// </summary>
        [Write(false)]
        public string DeityName { get; set; }

    }
}
