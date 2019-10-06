using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sreekovil.API.Resources;
using COSMO.Business.Abstractions;
using COSMO.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sreekovil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        #region Private members

        /// <summary>
        /// The branch service for busines methods.
        /// </summary>
        private IExpenseService _expenseService { get; set; }

        /// <summary>
        /// The common resource file.
        /// </summary>
        private ICommonResource _commonResource { get; set; }

        #endregion

        public ExpenseController(IExpenseService expenseService, ICommonResource commonResource)
        {
            _expenseService = expenseService;
            _commonResource = commonResource;
        }

        /// <summary>
        /// The method to save the expense entity.
        /// </summary>
        /// <param name="expense"></param>
        /// <returns>The saved entity.</returns>
        [HttpPost]
        public ResponseDto<User> Save([FromBody]User income)
        {
            ResponseDto<User> response = new ResponseDto<User>(_commonResource);
            try
            {
                response.Data = _expenseService.Save(income);
                return response;
            }
            catch(Exception ex)
            {
                return response.HandleException(response);
            }
        }

        /// <summary>
        /// The method to save 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResponseDto<List<User>> GetAll()
        {
            ResponseDto<List<User>> response = new ResponseDto<List<User>>(_commonResource);
            try
            {
                response.Data = _expenseService.GetAll();
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }
        }
    }
}