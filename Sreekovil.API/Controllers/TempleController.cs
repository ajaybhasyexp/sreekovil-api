using Microsoft.AspNetCore.Mvc;
using Sreekovil.API.Resources;
using Sreekovil.Business.Abstractions;
using Sreekovil.Models.Models;
using System;
using System.Collections.Generic;

namespace Sreekovil.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TempleController : ControllerBase
    {
        #region Private members

        /// <summary>
        /// The branch service for busines methods.
        /// </summary>
        private ITempleService _templeService { get; set; }

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
        public TempleController(ITempleService templeService, ICommonResource commonResource)
        {
            _templeService = templeService;
            _commonResource = commonResource;
        }


        /// <summary>
        /// Gets all the temple entities.
        /// </summary>
        /// <returns>A list of temple entity.</returns>
        [HttpGet]
        public ResponseDto<List<Temple>> GetAll()
        {
            ResponseDto<List<Temple>> response = new ResponseDto<List<Temple>>(_commonResource);
            try
            {
                response.Data = _templeService.GetAll();
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
        public ResponseDto<Temple> Get([FromRoute] int id)
        {
            ResponseDto<Temple> response = new ResponseDto<Temple>(_commonResource);
            try
            {
                response.Data = _templeService.Get(id);
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
        public ResponseDto<Temple> Save([FromBody]Temple temple)
        {
            ResponseDto<Temple> response = new ResponseDto<Temple>(_commonResource);
            try
            {
                response.Data = _templeService.Save(temple);
                return response;
            }
            catch
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
        public ResponseDto<bool> Delete([FromBody] Temple temple)
        {
            ResponseDto<bool> response = new ResponseDto<bool>(_commonResource);
            try
            {
                _templeService.Delete(temple);
                return response;
            }
            catch (Exception ex)
            {
                return response.HandleDeleteException(response, ex);
            }
        }
    }
}
