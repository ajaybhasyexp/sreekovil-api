using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.DataContext;
using Sreekovil.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sreekovil.Data.Repositories
{
    public class GenericRepository<T> where T : Base
    {
        /// <summary>
        /// The Dbset.
        /// </summary>
        public DbSet<T> dbSet;

        /// <summary>
        /// The Db context.
        /// </summary>
        public EFDataContext _context;

        public GenericRepository(EFDataContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        #region Public Methods

        /// <summary>
        /// Gets the branch entity based on id.
        /// </summary>
        /// <param name="id">The id to get the branch entity.</param>
        /// <returns>A single branch entity.</returns>
        public T Get(int id)
        {
            return dbSet.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Gets all the branch entities.
        /// </summary>
        /// <returns>A list of branch entity.</returns>
        public List<T> GetAll()
        {
            return dbSet.AsEnumerable().ToList();
        }

        /// <summary>
        /// Saves the branch entity.
        /// </summary>
        /// <param name="branch">Entity to save.</param>
        /// <returns>The saved entity.</returns>
        public T Save(T entity)
        {
            if (entity != null)
            {
                if (entity.Id == 0)
                    dbSet.Add(entity);
                else
                    dbSet.Attach(entity);
                _context.SaveChanges();
            }
            return entity;
        }

        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <param name="entity">the entity to delete.</param>
        public void Delete(T entity)
        {
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }

        #endregion
    }
}
