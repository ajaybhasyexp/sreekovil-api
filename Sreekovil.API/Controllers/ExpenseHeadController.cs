using Sreekovil.API.Resources;
using COSMO.Business.Abstractions;
using COSMO.Models.Exceptions;
using COSMO.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Sreekovil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseHeadController : ControllerBase
    {
        #region Private members

        /// <summary>
        /// The branch service for busines methods.
        /// </summary>
        private IExpenseHeadService _expenseHeadService { get; set; }

        /// <summary>
        /// The common resource file.
        /// </summary>
        private ICommonResource _commonResource { get; set; }

        #endregion

        /// <summary>
        /// Constructor for injection.
        /// </summary>
        /// <param name="branchServive">The branch service to inject.</param>
        public ExpenseHeadController(IExpenseHeadService expenseHeadService, ICommonResource commonResource)
        {
            _expenseHeadService = expenseHeadService;
            _commonResource = commonResource;
        }

        /// <summary>
        /// The save/update method for BatchAssignment
        /// </summary>
        /// <param name="BatchAssignment"></param>
        /// <returns>A saved or updated BatchAssignment entity.</returns>
        [HttpPost]
        public ResponseDto<ExpenseHead> Save([FromBody]ExpenseHead expenseHead)
        {
            ResponseDto<ExpenseHead> response = new ResponseDto<ExpenseHead>(_commonResource);
            try
            {
                response.Data = _expenseHeadService.Save(expenseHead);
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
        /// Gets a branch entity by id.
        /// </summary>
        /// <param name="id">The id for BatchAssignment</param>
        /// <returns>A BatchAssignment entity.</returns>
        [HttpGet]
        public ResponseDto<List<ExpenseHead>> Get()
        {
            ResponseDto<List<ExpenseHead>> response = new ResponseDto<List<ExpenseHead>>(_commonResource);
            try
            {
                response.Data = _expenseHeadService.GetAll();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                return response.HandleException(response);
            }
            return response;
        }

        [HttpGet]
        [Route("{expenseHeadId}")]
        public ResponseDto<ExpenseHead> Get(int expenseHeadId)
        {
            ResponseDto<ExpenseHead> response = new ResponseDto<ExpenseHead>(_commonResource);
            try
            {
                response.Data = _expenseHeadService.Get(expenseHeadId);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                return response.HandleException(response);
            }
            return response;
        }

        [HttpDelete]
        public ResponseDto<bool> Delete([FromBody] ExpenseHead incomeHead)
        {
            ResponseDto<bool> response = new ResponseDto<bool>(_commonResource);
            try
            {
                _expenseHeadService.Delete(incomeHead);
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {
                return response.HandleDeleteException(response, ex);
            }
        }


    }
}