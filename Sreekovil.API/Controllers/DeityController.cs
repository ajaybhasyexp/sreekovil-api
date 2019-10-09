using Microsoft.AspNetCore.Mvc;
using Sreekovil.API.Resources;
using Sreekovil.Business.Abstractions;
using Sreekovil.Models.Models;
using System;
using System.Collections.Generic;

namespace Sreekovil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeityController : ControllerBase
    {
        #region Private Properties

        /// <summary>
        /// The common resource property.
        /// </summary>
        private ICommonResource _commonResource { get; set; }

        /// <summary>
        /// The service for deity model.
        /// </summary>
        private IDeityService _deityService { get; set; }

        #endregion

        #region Constructor

        public DeityController(ICommonResource commonResource, IDeityService deityService)
        {
            _commonResource = commonResource;
            _deityService = deityService;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Gets all the Deity entities.
        /// </summary>
        /// <returns>A list of Deity entity.</returns>
        [HttpGet]
        public ResponseDto<List<Deity>> GetAll()
        {
            ResponseDto<List<Deity>> response = new ResponseDto<List<Deity>>(_commonResource);
            try
            {
                response.Data = _deityService.GetAll();
                return response;

            }
            catch (Exception ex)
            {
                return response.HandleException(response);
            }
        }

        /// <summary>
        /// Get the Deity entity based on the id.
        /// </summary>
        /// <param name="id">The identfier.</param>
        /// <returns>An Deity entity.</returns>
        [HttpGet]
        [Route("{id}")]
        public ResponseDto<Deity> Get([FromRoute] int id)
        {
            ResponseDto<Deity> response = new ResponseDto<Deity>(_commonResource);
            try
            {
                response.Data = _deityService.Get(id);
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }

        }

        /// <summary>
        /// Saves or updates the Deity.
        /// </summary>
        /// <param name="Deity">Deity entity to save.</param>
        /// <returns>Saved Deity entity.</returns>
        [HttpPost]
        public ResponseDto<Deity> Save([FromBody]Deity deity)
        {
            ResponseDto<Deity> response = new ResponseDto<Deity>(_commonResource);
            try
            {
                response.Data = _deityService.Save(deity);
                return response;
            }
            catch (Exception ex)
            {
                return response.HandleException(response);
            }
        }

        /// <summary>
        /// Deletes the Deity entity.
        /// </summary>
        /// <param name="Deity">The Deity entity to delete.</param>
        /// <returns>A boolean result based on deletion.</returns>
        [HttpDelete]
        public ResponseDto<bool> Delete([FromBody] Deity deity)
        {
            ResponseDto<bool> response = new ResponseDto<bool>(_commonResource);
            try
            {
                _deityService.Delete(deity);
                return response;
            }
            catch (Exception ex)
            {
                return response.HandleDeleteException(response, ex);
            }
        }

        #endregion
    }
}