using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business.Abstractions
{
    public interface IBatchService
    {
        /// <summary>
        /// The save method for branch.
        /// </summary>
        /// <param name="branch">The entity to save or update</param>
        /// <returns>The saved or updated entity.</returns>
        Batch Save(Batch branch);

        /// <summary>
        /// Gets all the branch entities.
        /// </summary>
        /// <returns>A list of branch entities.</returns>
        List<Batch> GetAll();

        /// <summary>
        /// Gets the branch entity based on the id.
        /// </summary>
        /// <param name="id">The id to get the branch.</param>
        /// <returns>A branch entity</returns>
        Batch Get(int id);

        List<Batch> GetAssigned(int branchId, int courseId);

        void Delete(Batch batch);
    }
}
