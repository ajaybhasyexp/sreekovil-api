using Sreekovil.Business.Abstractions;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;
using System.Collections.Generic;

namespace Sreekovil.Business
{
    public class TempleService : ITempleService
    {
        #region Private Members

        /// <summary>
        /// The repository for branch entity.
        /// </summary>
        public ITempleRepository _templeRepository { get; set; }

        #endregion

        /// <summary>
        /// The constructor for branch service.
        /// </summary>
        /// <param name="branchRepository">The repository for injection</param>
        public TempleService(ITempleRepository templeRepository)
        {
            _templeRepository = templeRepository;

        }

        #region Public Methods

        /// <summary>
        /// A method to get the temple by its Id.
        /// </summary>
        /// <param name="id">The temple id</param>
        /// <returns>A temple object.</returns>
        public Temple Get(int id)
        {
            return _templeRepository.Get(id);
        }

        /// <summary>
        /// Gets a list of all the temples.
        /// </summary>
        /// <returns>A list of temple entity.</returns>
        public List<Temple> GetAll()
        {
            return _templeRepository.GetAll();
        }

        /// <summary>
        /// The method to save/update the temple entity.
        /// </summary>
        /// <param name="temple">The temple entity to save or update</param>
        /// <returns>An updated or saved entity.</returns>
        public Temple Save(Temple temple)
        {
            return _templeRepository.Save(temple);
        }

        /// <summary>
        /// Deletes the temple entity.
        /// </summary>
        /// <param name="temple">The entity to delete.</param>
        public void Delete(Temple temple)
        {
            _templeRepository.Delete(temple);
        }

        #endregion
    }
}