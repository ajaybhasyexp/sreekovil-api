using Sreekovil.API.Resources;
using COSMO.Business.Abstractions;
using COSMO.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Sreekovil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BatchController : ControllerBase
    {
        #region Private members

        /// <summary>
        /// The branch service for busines methods.
        /// </summary>
        private IBatchService _batchService { get; set; }

        /// <summary>
        /// The common resource file.
        /// </summary>
        private ICommonResource _commonResource { get; set; }

        #endregion

        /// <summary>
        /// Constructor for injection.
        /// </summary>
        /// <param name="branchServive">The branch service to inject.</param>
        public BatchController(IBatchService batchService, ICommonResource commonResource)
        {
            _batchService = batchService;
            _commonResource = commonResource;
        }

        /// <summary>
        /// Gets all the branch entities.
        /// </summary>
        /// <returns>A list of branch entity.</returns>
        [HttpGet]
        public ResponseDto<List<Batch>> GetAll()
        {
            ResponseDto<List<Batch>> response = new ResponseDto<List<Batch>>(_commonResource);
            try
            {
                response.Data = _batchService.GetAll();
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }

        }

        [HttpGet]
        [Route("{branchId}/assigned/{courseId}")]
        public ResponseDto<List<Batch>> GetAssignedBatches(int branchId, int courseId)
        {
            ResponseDto<List<Batch>> response = new ResponseDto<List<Batch>>(_commonResource);

            try
            {
                response.Data = _batchService.GetAssigned(branchId, courseId);
                return response;
            }
            catch (Exception ex)
            {
                return response.HandleException(response);
            }

        }

        /// <summary>
        /// Gets a branch entity by id.
        /// </summary>
        /// <param name="id">The id for branch</param>
        /// <returns>A branch entity.</returns>
        [HttpGet]
        [Route("{id}")]
        public ResponseDto<Batch> Get([FromRoute] int id)
        {
            ResponseDto<Batch> response = new ResponseDto<Batch>(_commonResource);
            try
            {
                response.Data = _batchService.Get(id);
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }
        }

        /// <summary>
        /// The save/update method for branch
        /// </summary>
        /// <param name="branch"></param>
        /// <returns>A saved or updated branch entity.</returns>
        [HttpPost]
        [AllowAnonymous]
        public ResponseDto<Batch> Save([FromBody]Batch branch)
        {
            ResponseDto<Batch> response = new ResponseDto<Batch>(_commonResource);
            try
            {
                response.Data = _batchService.Save(branch);
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }
        }

        [HttpDelete]
        public ResponseDto<bool> Delete([FromBody] Batch batch)
        {
            ResponseDto<bool> response = new ResponseDto<bool>(_commonResource);
            try
            {
                _batchService.Delete(batch);
                return response;
            }
            catch (Exception ex)
            {
                return response.HandleDeleteException(response, ex);
            }
        }
    }
}