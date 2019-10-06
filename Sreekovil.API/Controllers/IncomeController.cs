using Sreekovil.API.Resources;
using COSMO.Business.Abstractions;
using COSMO.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Sreekovil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        #region Private members

        /// <summary>
        /// The branch service for busines methods.
        /// </summary>
        private IIncomeService _incomeService { get; set; }

        /// <summary>
        /// The common resource file.
        /// </summary>
        private ICommonResource _commonResource { get; set; }

        #endregion

        /// <summary>
        /// Constructor for injection.
        /// </summary>
        /// <param name="branchServive">The branch service to inject.</param>
        public IncomeController(IIncomeService incomeService, ICommonResource commonResource)
        {
            _incomeService = incomeService;
            _commonResource = commonResource;
        }

        /// <summary>
        /// The save/update method for BatchAssignment
        /// </summary>
        /// <param name="BatchAssignment"></param>
        /// <returns>A saved or updated BatchAssignment entity.</returns>
        [HttpPost]
        public ResponseDto<Income> Save([FromBody]Income income)
        {
            ResponseDto<Income> response = new ResponseDto<Income>(_commonResource);
            try
            {
                response.Data = _incomeService.Save(income);
                return response;
            }            
            catch
            {
                return response.HandleException(response);
            }
        }

        [HttpGet]
        public ResponseDto<List<Income>> GetAll()
        {
            ResponseDto<List<Income>> response = new ResponseDto<List<Income>>(_commonResource);
            try
            {
                response.Data = _incomeService.GetAll();
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }
        }
    }
}