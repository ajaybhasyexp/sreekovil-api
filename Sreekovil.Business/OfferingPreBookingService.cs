using Sreekovil.Business.Abstractions;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;

namespace Sreekovil.Business
{
    public class OfferingPreBookingService : GenericService<OfferingPreBooking>, IOfferingPreBookingService
    {

        public OfferingPreBookingService(IOfferingPreBookingRepository offeringPreBookingRepository) : base(offeringPreBookingRepository)
        {

        }
    }
}
