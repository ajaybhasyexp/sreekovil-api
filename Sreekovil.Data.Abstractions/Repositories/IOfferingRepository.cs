using Sreekovil.Models.Models;
using System.Collections.Generic;

namespace Sreekovil.Data.Abstractions.Repositories
{
    public interface IOfferingRepository : IGenericRepository<Offering>
    {
        /// <summary>
        /// Get offerings by temple id.
        /// </summary>
        /// <param name="templeId">The temple identifier.</param>
        /// <returns>A list of offerings based on the temple</returns>
        List<Offering> GetOfferingsByTempleId(int templeId);
    }
}
