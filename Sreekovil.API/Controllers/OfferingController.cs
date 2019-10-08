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
    public class OfferingController : ControllerBase
    {

        #region Private members

        /// <summary>
        /// The branch service for busines methods.
        /// </summary>
        private IOfferingService _offeringService { get; set; }

        /// <summary>
        /// The common resource file.
        /// </summary>
        private ICommonResource _commonResource { get; set; }

        #endregion

        /// <summary>
        /// Constructor for temple controller.
        /// </summary>
        /// <param name="templeService">The service for temple.</param>
        /// <param name="commonResource"></param>
        public OfferingController(IOfferingService offeringService, ICommonResource commonResource)
        {
            _offeringService = offeringService;
            _commonResource = commonResource;
        }


        /// <summary>
        /// Gets all the temple entities.
        /// </summary>
        /// <returns>A list of temple entity.</returns>
        [HttpGet]
        public ResponseDto<List<Offering>> GetAll()
        {
            ResponseDto<List<Offering>> response = new ResponseDto<List<Offering>>(_commonResource);
            try
            {
                response.Data = _offeringService.GetAll();
                return response;

            }
            catch
            {
                return response.HandleException(response);
            }
        }

        /// <summary>
        /// Get the temple entity based on the id.
        /// </summary>
        /// <param name="id">The identfier.</param>
        /// <returns>A temple entity.</returns>
        [HttpGet]
        [Route("{id}")]
        public ResponseDto<Offering> Get([FromRoute] int id)
        {
            ResponseDto<Offering> response = new ResponseDto<Offering>(_commonResource);
            try
            {
                response.Data = _offeringService.Get(id);
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }

        }

        /// <summary>
        /// Saves or updates the temple.
        /// </summary>
        /// <param name="temple">Temple entity to save.</param>
        /// <returns>Saved temple entity.</returns>
        [HttpPost]
        public ResponseDto<Offering> Save([FromBody]Offering offering)
        {
            ResponseDto<Offering> response = new ResponseDto<Offering>(_commonResource);
            try
            {
                response.Data = _offeringService.Save(offering);
                return response;
            }
            catch(Exception ex)
            {
                return response.HandleException(response);
            }
        }

        /// <summary>
        /// Deletes the temple entity.
        /// </summary>
        /// <param name="temple">The temple entity to delete.</param>
        /// <returns>A boolean result based on deletion.</returns>
        [HttpDelete]
        public ResponseDto<bool> Delete([FromBody] Offering offering)
        {
            ResponseDto<bool> response = new ResponseDto<bool>(_commonResource);
            try
            {
                _offeringService.Delete(offering);
                return response;
            }
            catch (Exception ex)
            {
                return response.HandleDeleteException(response, ex);
            }
        }
    }
}
