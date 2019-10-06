using System;

namespace Sreekovil.Models.Models
{
    public class OfferingPreBooking : Base
    {
        public int OfferingId { get; set; }

        public int TempleId { get; set; }

        public string ContactName { get; set; }

        public string ContactNumber { get; set; }

        public string Remarks { get; set; }

        public DateTime DateOfBooking { get; set; }

        public DateTime DateOfOffering { get; set; }
    }
}
