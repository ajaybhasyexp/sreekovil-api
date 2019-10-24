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

        #region Public Methods

        /// <summary>
        /// The method to get offerings based on temple id.
        /// </summary>
        /// <param name="templeId">the temple identifier.</param>
        /// <returns>A list of offering</returns>
        public List<Offering> GetOfferingsByTempleId(int templeId)
        {
            return _offeringRepository.GetOfferingsByTempleId(templeId);
        }

        #endregion
    }
}
