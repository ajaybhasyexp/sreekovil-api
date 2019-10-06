using Sreekovil.API.Resources;
using COSMO.Business.Abstractions;
using COSMO.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Sreekovil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseFeeController : ControllerBase
    {
        #region Private members

        /// <summary>
        /// The branch service for busines methods.
        /// </summary>
        private ICourseFeeService _courseFeeService { get; set; }

        /// <summary>
        /// The common resource file.
        /// </summary>
        private ICommonResource _commonResource { get; set; }

        #endregion

        /// <summary>
        /// Constructor for injection.
        /// </summary>
        /// <param name="branchServive">The branch service to inject.</param>
        public CourseFeeController(ICourseFeeService courseFeeService, ICommonResource commonResource)
        {
            _courseFeeService = courseFeeService;
            _commonResource = commonResource;
        }


        /// <summary>
        /// Gets a branch entity by id.
        /// </summary>
        /// <param name="id">The id for BatchAssignment</param>
        /// <returns>A BatchAssignment entity.</returns>
        [HttpGet]
        [Route("{id}")]
        public ResponseDto<CourseFee> Get([FromRoute] int id)
        {
            ResponseDto<CourseFee> response = new ResponseDto<CourseFee>(_commonResource);
            try
            {
                response.Data = _courseFeeService.Get(id);
                response.IsSuccess = true;
            }
            catch
            {
                return response.HandleException(response);
            }
            return response;
        }

        [HttpGet]
        [Route("all/{branchId}")]
        public ResponseDto<List<CourseFee>> CourseFees(int branchId)
        {
            ResponseDto<List<CourseFee>> response = new ResponseDto<List<CourseFee>>(_commonResource);
            try
            {
                response.Data = _courseFeeService.GetAll(branchId);
            }
            catch (Exception ex)
            {
                return response.HandleException(response);
            }
            return response;
        }

        [HttpGet]
        [Route("{branchId}/course/{courseId}")]
        public ResponseDto<List<CourseFee>> CourseFees(int branchId, int courseId)
        {
            ResponseDto<List<CourseFee>> response = new ResponseDto<List<CourseFee>>(_commonResource);
            try
            {
                response.Data = _courseFeeService.GetCourseFee(branchId, courseId);
            }
            catch (Exception ex)
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
        public ResponseDto<CourseFee> Save([FromBody]CourseFee assignment)
        {
            ResponseDto<CourseFee> response = new ResponseDto<CourseFee>(_commonResource);
            try
            {
                response.Data = _courseFeeService.Save(assignment);
                return response;
            }
            catch (Exception ex)
            {
                return response.HandleException(response);
            }
        }

        /// <summary>
        /// Deletes the BatchAssignment entity.
        /// </summary>
        /// <param name="courseFee">The entity to delete.</param>
        [HttpDelete]
        public ResponseDto<bool> Delete([FromBody] CourseFee courseFee)
        {
            ResponseDto<bool> response = new ResponseDto<bool>(_commonResource);
            try
            {
                _courseFeeService.Delete(courseFee);
                response.Data = true;

            }
            catch (Exception ex)
            {
                return response.HandleDeleteException(response, ex);
            }
            return response;
        }        
    }
}