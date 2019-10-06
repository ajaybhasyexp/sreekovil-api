using Sreekovil.API.Resources;
using COSMO.Business.Abstractions;
using COSMO.Models.Exceptions;
using COSMO.Models.Models;
using COSMO.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Sreekovil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchAssignmentController : ControllerBase
    {
        #region Private members

        /// <summary>
        /// The branch service for busines methods.
        /// </summary>
        private IBatchAssignmentService _batchAssignmentService { get; set; }

        /// <summary>
        /// The common resource file.
        /// </summary>
        private ICommonResource _commonResource { get; set; }

        #endregion

        /// <summary>
        /// Constructor for injection.
        /// </summary>
        /// <param name="branchServive">The branch service to inject.</param>
        public BatchAssignmentController(IBatchAssignmentService batchAssignmentService, ICommonResource commonResource)
        {
            _batchAssignmentService = batchAssignmentService;
            _commonResource = commonResource;
        }

        /// <summary>
        /// Gets all the BatchAssignment entities.
        /// </summary>
        /// <returns>A list of BatchAssignment entity.</returns>
        [HttpGet]
        public ResponseDto<List<BatchAssignment>> GetAll()
        {
            ResponseDto<List<BatchAssignment>> response = new ResponseDto<List<BatchAssignment>>(_commonResource);
            try
            {
                response.Data = _batchAssignmentService.GetAll();
                response.IsSuccess = true;
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }


        }

        /// <summary>
        /// Gets a branch entity by id.
        /// </summary>
        /// <param name="id">The id for BatchAssignment</param>
        /// <returns>A BatchAssignment entity.</returns>
        [HttpGet]
        [Route("{id}")]
        public ResponseDto<BatchAssignment> Get([FromRoute] int id)
        {
            ResponseDto<BatchAssignment> response = new ResponseDto<BatchAssignment>(_commonResource);
            try
            {
                response.Data = _batchAssignmentService.Get(id);
                response.IsSuccess = true;
            }
            catch
            {
                return response.HandleException(response);
            }
            return response;
        }

        /// <summary>
        /// The save/update method for BatchAssignment
        /// </summary>
        /// <param name="BatchAssignment"></param>
        /// <returns>A saved or updated BatchAssignment entity.</returns>
        [HttpPost]
        public ResponseDto<List<BatchAssignVM>> Save([FromBody]BatchAssignment assignment)
        {
            ResponseDto<List<BatchAssignVM>> response = new ResponseDto<List<BatchAssignVM>>(_commonResource);
            try
            {
                response.Data = _batchAssignmentService.Save(assignment);
                return response;
            }
            catch (CosmoBusinessException ex)
            {
                return response.HandleCustomException(response, ex);
            }
            catch
            {
                return response.HandleException(response);
            }
        }

        /// <summary>
        /// Deletes the BatchAssignment entity.
        /// </summary>
        /// <param name="BatchAssignment">The entity to delete.</param>
        [HttpDelete]
        public ResponseDto<bool> Delete([FromBody] BatchAssignment batchAssign)
        {
            ResponseDto<bool> response = new ResponseDto<bool>(_commonResource);
            try
            {
                _batchAssignmentService.Delete(batchAssign);
                response.Data = true;

            }
            catch
            {
                return response.HandleException(response);
            }
            return response;
        }

        [HttpGet]
        [Route("all/{branchId}")]
        public ResponseDto<List<BatchAssignVM>> BatchAssigns(int branchId)
        {
            ResponseDto<List<BatchAssignVM>> response = new ResponseDto<List<BatchAssignVM>>(_commonResource);
            try
            {
                response.Data = _batchAssignmentService.GetVMs(branchId);
            }
            catch
            {
                return response.HandleException(response);
            }
            return response;
        }
    }
}