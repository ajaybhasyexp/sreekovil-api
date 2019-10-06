using Sreekovil.Models.Models;
using System.Collections.Generic;

namespace Sreekovil.Data.Abstractions.Repositories
{
    public interface IGenericRepository<T> where T : Base
    {
        /// <summary>
        /// Gets the entity based on id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The identified entity.</returns>
        T Get(int id);

        /// <summary>
        /// Gets all the entity of the type specified.
        /// </summary>
        /// <returns>A list of entities.</returns>
        List<T> GetAll();

        /// <summary>
        /// Saves the entity passed.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>The entity after saving.</returns>
        T Save(T entity);

        /// <summary>
        /// Deletes the entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}
