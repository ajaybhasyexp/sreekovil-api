using Sreekovil.Models.Models;
using System.Collections.Generic;

namespace Sreekovil.Business.Abstractions
{
    /// <summary>
    /// The abstraction for temple business methods.
    /// </summary>
    public interface ITempleService
    {
        /// <summary>
        /// The save method for temple.
        /// </summary>
        /// <param name="temple">The temple entity to save</param>
        /// <returns>Saved temple entity.</returns>
        Temple Save(Temple temple);

        /// <summary>
        /// Gets a list of all the temples.
        /// </summary>
        /// <returns>A list of temples.</returns>
        List<Temple> GetAll();

        /// <summary>
        /// Gets a temple with the given Id.
        /// </summary>
        /// <param name="id">The id to fetch temple.</param>
        /// <returns>A temple entity.</returns>
        Temple Get(int id);

        /// <summary>
        /// Deletes the temple entity.
        /// </summary>
        /// <param name="temple"></param>
        void Delete(Temple temple);
    }
}
