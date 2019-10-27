using System;
using Dapper.Contrib.Extensions;

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

        /// <summary>
        /// The name of the Offering in this Offering Transaction.
        /// </summary>
        [Write(false)]
        public string OfferingName { get; set; }

        /// <summary>
        /// The name of the StarSign in this Offering Transaction.
        /// </summary>
        [Write(false)]
        public string StarSignName { get; set; }

        /// <summary>
        /// The name of the Deity in this Offering Transaction.
        /// </summary>
        [Write(false)]
        public string DeityName { get; set; }
    }
}
