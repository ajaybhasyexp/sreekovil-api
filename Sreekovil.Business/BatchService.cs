using COSMO.Business.Abstractions;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business
{
    public class BatchService : IBatchService
    {
        #region Private Members

        /// <summary>
        /// The repository for branch entity.
        /// </summary>
        public IBatchRepository _branchRepository { get; set; }

        #endregion

        public BatchService(IBatchRepository batchRepository)
        {
            _branchRepository = batchRepository;

        }

        public Batch Get(int id)
        {
            return _branchRepository.Get(id);
        }

        public List<Batch> GetAll()
        {
            return _branchRepository.GetAll();
        }

        public Batch Save(Batch branch)
        {
            return _branchRepository.Save(branch);
        }

        public List<Batch> GetAssigned(int branchId, int courseId)
        {
            return _branchRepository.GetAssignedBatches(branchId, courseId);
        }

        public void Delete(Batch batch)
        {
            _branchRepository.Delete(batch);
        }
    }
}
