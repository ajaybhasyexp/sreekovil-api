using Sreekovil.Models.Models;
using System.Collections.Generic;

namespace Sreekovil.Business.Abstractions
{
    public interface IGenericService<T> where T : Base
    {
        /// <summary>
        /// Saves the entity.
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns></returns>
        T Save(T entity);

        /// <summary>
        /// Gets the list of all entities.
        /// </summary>
        /// <returns>A list of entities</returns>
        List<T> GetAll();

        /// <summary>
        /// Gets the entity with specified Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An entity.</returns>
        T Get(int id);

        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        void Delete(T entity);
    }
}
