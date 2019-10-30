using Sreekovil.Business.Abstractions;
using Sreekovil.Data.Abstractions.Repositories;
using System.Collections.Generic;
using Sreekovil.Models.Models;

namespace Sreekovil.Business
{
    public class DeityService : GenericService<Deity>, IDeityService
    {
        /// <summary>
        /// The repository for offering entity.
        /// </summary>
        public IDeityRepository _deityRepository { get; set; }

        public DeityService(IDeityRepository deityRepository) : base(deityRepository)
        {
            _deityRepository = deityRepository;
        }
        public List<Deity> GetDietyById(int DeityId)
        {
            return _deityRepository.GetDietyById(DeityId);
        }
    }
}
