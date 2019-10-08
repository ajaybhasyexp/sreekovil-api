using Sreekovil.Business.Abstractions;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sreekovil.Business
{
    public class OfferingService : GenericService<Offering>, IOfferingService
    {
        #region Private Members

        /// <summary>
        /// The repository for offering entity.
        /// </summary>
        public IOfferingRepository _offeringRepository { get; set; }

        #endregion

        /// <summary>
        /// The constructor for offering service.
        /// </summary>
        /// <param name="offeringRepository">The repository for injection</param>
        public OfferingService(IOfferingRepository offeringRepository) : base(offeringRepository)
        {
            _offeringRepository = offeringRepository;

        }

        //#region Public Methods

        ///// <summary>
        ///// A method to get the offering by its Id.
        ///// </summary>
        ///// <param name="id">The offering id</param>
        ///// <returns>An offering object.</returns>
        //public Offering Get(int id)
        //{
        //    return _offeringRepository.Get(id);
        //}

        ///// <summary>
        ///// Gets a list of all the Offerings.
        ///// </summary>
        ///// <returns>A list of Offering entity.</returns>
        //public List<Offering> GetAll()
        //{
        //    return _offeringRepository.GetAll();
        //}

        ///// <summary>
        ///// The method to save/update the Offering entity.
        ///// </summary>
        ///// <param name="temple">The Offering entity to save or update</param>
        ///// <returns>An updated or saved entity.</returns>
        //public Offering Save(Offering offering)
        //{
        //    return _offeringRepository.Save(offering);
        //}

        ///// <summary>
        ///// Deletes the Offering entity.
        ///// </summary>
        ///// <param name="Offering">The entity to delete.</param>
        //public void Delete(Offering offering)
        //{
        //    _offeringRepository.Delete(offering);
        //}

        //#endregion
    }
}
