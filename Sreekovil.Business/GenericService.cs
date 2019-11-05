using Sreekovil.Business.Abstractions;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sreekovil.Business
{
    public class GenericService<T> : IGenericService<T> where T : Base
    {
        public IGenericRepository<T> _repository { get; set; }

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Saves the entity.
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns></returns>
        public T Save(T entity)
        {
            return _repository.Save(entity);
        }

        /// <summary>
        /// Gets the list of all entities.
        /// </summary>
        /// <returns>A list of entities</returns>
        public List<T> GetAll()
        {
            return _repository.GetAll();
        }

        /// <summary>
        /// Gets the entity with specified Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An entity.</returns>
        public T Get(int id)
        {
            return _repository.Get(id);
        }

        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public void Delete(int id)
        {
            var entity = _repository.Get(id);
            if (entity != null)
            {
                _repository.Delete(entity);
            }
        }
    }
}
