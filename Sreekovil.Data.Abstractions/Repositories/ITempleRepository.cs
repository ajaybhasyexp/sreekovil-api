using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;

namespace Sreekovil.Data.Abstractions.Repositories
{
    /// <summary>
    /// The abstarction for branch entity.
    /// </summary>
    public interface ITempleRepository : IGenericRepository<Temple>
    {
        /// <summary>
        /// Gets the temple entity based on the user id.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>A temple object</returns>
        Temple GetTempleByUserId(int userId);
    }
}
