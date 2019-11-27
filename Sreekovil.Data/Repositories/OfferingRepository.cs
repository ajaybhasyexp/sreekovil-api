using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.DataContext;
using Sreekovil.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sreekovil.Data.Repositories
{
    public class OfferingRepository : GenericRepository<Offering>, IOfferingRepository
    {
        #region Constructor

        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public OfferingRepository(EFDataContext context) : base(context)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get offerings by temple id.
        /// </summary>
        /// <param name="templeId">The temple identifier.</param>
        /// <returns>A list of offerings based on the temple</returns>
        public List<Offering> GetOfferingsByTempleId(int templeId)
        {
            var offerings = dbSet.Where(p => p.TempleId == templeId);
            if(offerings.Any())
            {
                return offerings.ToList();
            }
            return null;
        }

        #endregion

    }
}
