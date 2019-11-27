using System.Collections.Generic;

namespace Sreekovil.Models.Models
{
    public class Temple : Base
    {
        public int AdminId { get; set; }

        public string TempleName { get; set; }

        public string ContactPerson { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }

        public string Image { get; set; }

        public IEnumerable<Deity> Deities { get; set; }

        public IEnumerable<Offering> Offerings { get; set; }

        public IEnumerable<OfferingTransaction> OfferingTransactions { get; set; }

        public IEnumerable<OfferingPreBooking> OfferingPreBookings { get; set; }
    }
}
