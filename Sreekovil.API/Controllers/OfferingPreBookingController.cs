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
    public class OfferingPreBookingController : ControllerBase
    {
        #region Private Properties

        /// <summary>
        /// The common resource property.
        /// </summary>
        private ICommonResource _commonResource { get; set; }

        /// <summary>
        /// The service for OfferingPreBooking model.
        /// </summary>
        private IOfferingPreBookingService _offeringPreBookingService { get; set; }

        #endregion

        #region Constructor

        public OfferingPreBookingController(ICommonResource commonResource, IOfferingPreBookingService offeringPreBookingService)
        {
            _commonResource = commonResource;
            _offeringPreBookingService = offeringPreBookingService;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Gets all the OfferingPreBooking entities.
        /// </summary>
        /// <returns>A list of OfferingPreBooking entity.</returns>
        [HttpGet]
        public ResponseDto<List<OfferingPreBooking>> GetAll()
        {
            ResponseDto<List<OfferingPreBooking>> response = new ResponseDto<List<OfferingPreBooking>>(_commonResource);
            try
            {
                response.Data = _offeringPreBookingService.GetAll();
                return response;

            }
            catch (Exception ex)
            {
                return response.HandleException(response);
            }
        }

        /// <summary>
        /// Get the OfferingPreBooking entity based on the id.
        /// </summary>
        /// <param name="id">The identfier.</param>
        /// <returns>An OfferingPreBooking entity.</returns>
        [HttpGet]
        [Route("{id}")]
        public ResponseDto<OfferingPreBooking> Get([FromRoute] int id)
        {
            ResponseDto<OfferingPreBooking> response = new ResponseDto<OfferingPreBooking>(_commonResource);
            try
            {
                response.Data = _offeringPreBookingService.Get(id);
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }

        }

        /// <summary>
        /// Saves or updates the OfferingPreBooking.
        /// </summary>
        /// <param name="OfferingPreBooking">OfferingPreBooking entity to save.</param>
        /// <returns>Saved OfferingPreBooking entity.</returns>
        [HttpPost]
        public ResponseDto<OfferingPreBooking> Save([FromBody]OfferingPreBooking offeringPreBooking)
        {
            ResponseDto<OfferingPreBooking> response = new ResponseDto<OfferingPreBooking>(_commonResource);
            try
            {
                response.Data = _offeringPreBookingService.Save(offeringPreBooking);
                return response;
            }
            catch (Exception ex)
            {
                return response.HandleException(response);
            }
        }

        /// <summary>
        /// Deletes the OfferingPreBooking entity.
        /// </summary>
        /// <param name="OfferingPreBooking">The OfferingPreBooking entity to delete.</param>
        /// <returns>A boolean result based on deletion.</returns>
        [HttpDelete]
        public ResponseDto<bool> Delete([FromBody] OfferingPreBooking offeringPreBooking)
        {
            ResponseDto<bool> response = new ResponseDto<bool>(_commonResource);
            try
            {
                _offeringPreBookingService.Delete(offeringPreBooking);
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