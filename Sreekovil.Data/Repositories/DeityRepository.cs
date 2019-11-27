using Microsoft.Extensions.Configuration;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Sreekovil.Models.DataContext;

namespace Sreekovil.Data.Repositories
{
    public class DeityRepository : GenericRepository<Deity>, IDeityRepository
    {
        public DeityRepository(EFDataContext context) : base(context)
        {

        }

        /// <summary>
        /// Get offerings by temple id.
        /// </summary>
        /// <param name="templeId">The temple identifier.</param>
        /// <returns>A list of offerings based on the temple</returns>
        public List<Deity> GetDietyById(int templeId)
        {
            var deities = dbSet.Where(p => p.TempleId == templeId);
            if (deities.Any())
            {
                return deities.ToList();
            }
            return null;

        }
    }
}
