using Sreekovil.Business.Abstractions;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;

namespace Sreekovil.Business
{
    public class DeityService : GenericService<Deity>, IDeityService
    {

        public DeityService(IDeityRepository deityRepository) : base(deityRepository)
        {

        }
    }
}
