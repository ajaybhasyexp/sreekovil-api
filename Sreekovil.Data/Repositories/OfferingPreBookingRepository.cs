using Microsoft.Extensions.Configuration;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sreekovil.Data.Repositories
{
    public class OfferingPreBookingRepository : GenericRepository<OfferingPreBooking>, IOfferingPreBookingRepository
    {
        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public OfferingPreBookingRepository(IConfiguration config) : base(config)
        {

        }
    }
}
