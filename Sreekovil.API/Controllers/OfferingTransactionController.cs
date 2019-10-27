using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sreekovil.API.Resources;
using Sreekovil.Business.Abstractions;
using Sreekovil.Models.Models;
using System;
using System.Collections.Generic;
using Sreekovil.Models.Common;
using System.Security.Claims;

namespace Sreekovil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OfferingTransactionController : ControllerBase
    {

        #region Private members

        /// <summary>
        /// The branch service for busines methods.
        /// </summary>
        private IOfferingTransactionService _offeringTransactionService { get; set; }

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
        public OfferingTransactionController(IOfferingTransactionService offeringTransactionService, ICommonResource commonResource)
        {
            _offeringTransactionService = offeringTransactionService;
            _commonResource = commonResource;
        }


        /// <summary>
        /// Gets all the temple entities.
        /// </summary>
        /// <returns>A list of temple entity.</returns>
        [HttpGet]
        public ResponseDto<List<OfferingTransaction>> GetAll()
        {
            ResponseDto<List<OfferingTransaction>> response = new ResponseDto<List<OfferingTransaction>>(_commonResource);
            try
            {
                response.Data = _offeringTransactionService.GetAll();
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
        public ResponseDto<OfferingTransaction> Get([FromRoute] int id)
        {
            ResponseDto<OfferingTransaction> response = new ResponseDto<OfferingTransaction>(_commonResource);
            try
            {
                response.Data = _offeringTransactionService.Get(id);
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
        public ResponseDto<OfferingTransaction> Save([FromBody]OfferingTransaction offeringTransaction)
        {
            ResponseDto<OfferingTransaction> response = new ResponseDto<OfferingTransaction>(_commonResource);
            try
            {
                response.Data = _offeringTransactionService.Save(offeringTransaction);
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
        public ResponseDto<bool> Delete([FromBody] OfferingTransaction offeringTransaction)
        {
            ResponseDto<bool> response = new ResponseDto<bool>(_commonResource);
            try
            {
                _offeringTransactionService.Delete(offeringTransaction);
                return response;
            }
            catch (Exception ex)
            {
                return response.HandleDeleteException(response, ex);
            }
        }

        /// <summary>
        /// Gets all the temple entities.
        /// </summary>
        /// <returns>A list of temple entity.</returns>
        [HttpPost]
        [Route("filter")]
        public ResponseDto<List<OfferingTransaction>> GetOfferingTransactionByFilters(Filters filter)
        {
            ResponseDto<List<OfferingTransaction>> response = new ResponseDto<List<OfferingTransaction>>(_commonResource);
            try
            {
                filter.templeId = GetTempleId();
                response.Data = _offeringTransactionService.GetOfferingTransactionByFilters(filter);
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }
        }

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
    }
}
