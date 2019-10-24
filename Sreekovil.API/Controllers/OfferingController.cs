using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sreekovil.API.Resources;
using Sreekovil.Business.Abstractions;
using Sreekovil.Models.Common;
using Sreekovil.Models.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Sreekovil.API.Controllers
{
    /// <summary>
    /// The controller that contains methods for offering.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        #region Private Methods

        /// <summary>
        /// Gets the temple id from token.
        /// </summary>
        /// <returns>The temple id</returns>
        private int GetTempleId()
        {
            var claimsIDentity = HttpContext.User.Identity as ClaimsIdentity;
            var templeId = claimsIDentity.FindFirst(CustomClaims.TempleId).Value;
            return Convert.ToInt32(templeId);
        }

        #endregion

        #region Constructor

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

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all the Offering entities.
        /// </summary>
        /// <returns>A list of Offering entity.</returns>
        [HttpGet]
        public ResponseDto<List<Offering>> GetAll()
        {
            ResponseDto<List<Offering>> response = new ResponseDto<List<Offering>>(_commonResource);
            try
            {
                var templeId = GetTempleId();
                response.Data = _offeringService.GetOfferingsByTempleId(templeId);
                return response;

            }
            catch
            {
                return response.HandleException(response);
            }
        }

        /// <summary>
        /// Get the offering entity based on the id.
        /// </summary>
        /// <param name="id">The identfier.</param>
        /// <returns>An offering entity.</returns>
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
        /// Saves or updates the Offering.
        /// </summary>
        /// <param name="offering">Offering entity to save.</param>
        /// <returns>Saved Offering entity.</returns>
        [HttpPost]
        public ResponseDto<Offering> Save([FromBody]Offering offering)
        {
            ResponseDto<Offering> response = new ResponseDto<Offering>(_commonResource);
            try
            {
                response.Data = _offeringService.Save(offering);
                return response;
            }
            catch (Exception ex)
            {
                return response.HandleException(response);
            }
        }

        /// <summary>
        /// Deletes the offering entity.
        /// </summary>
        /// <param name="offering">The offering entity to delete.</param>
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

        #endregion
    }
}
