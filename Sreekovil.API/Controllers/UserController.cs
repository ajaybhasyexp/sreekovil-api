using Microsoft.AspNetCore.Authorization;
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
    public class UserController : ControllerBase
    {
        #region Private Members

        private IUserService _userService { get; set; }

        /// <summary>
        /// The common resource file.
        /// </summary>
        private ICommonResource _commonResource { get; set; }

        #endregion

        public UserController(IUserService userService, ICommonResource commonResource)
        {
            _userService = userService;
            _commonResource = commonResource;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ResponseDto<User> Authenticate([FromBody]User userParam)
        {
            ResponseDto<User> response = new ResponseDto<User>(_commonResource);
            try
            {
                response.Data = _userService.Authenticate(userParam.Email, userParam.Password);
                if (response.Data == null)
                {
                    response.IsSuccess = false;
                    response.Message = _commonResource.InvalidUser;
                }
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }

        }

        //[HttpGet("roles")]
        //public ResponseDto<List<UserRole>> GetUserRoles()
        //{
        //    ResponseDto<List<UserRole>> response = new ResponseDto<List<UserRole>>(_commonResource);
        //    try
        //    {
        //        response.Data = _userRoleService.GetAll();
        //        return response;
        //    }
        //    catch
        //    {
        //        return response.HandleException(response);
        //    }

        //}

        [HttpGet]
        public ResponseDto<List<User>> GetAll()
        {
            ResponseDto<List<User>> response = new ResponseDto<List<User>>(_commonResource);
            try
            {
                response.Data = _userService.GetAll();
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }
        }

        [HttpGet]
        [Route("{templeId}/all")]
        public ResponseDto<List<User>> GetAll(int templeId)
        {
            ResponseDto<List<User>> response = new ResponseDto<List<User>>(_commonResource);
            try
            {
                response.Data = _userService.GetAll(templeId);
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseDto<User> Get([FromRoute] int id)
        {
            ResponseDto<User> response = new ResponseDto<User>(_commonResource);
            try
            {
                response.Data = _userService.Get(id);
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }

        }

        [HttpPost]
        public ResponseDto<User> Save([FromBody] User user)
        {
            ResponseDto<User> response = new ResponseDto<User>(_commonResource);
            try
            {
                response.Data = _userService.Save(user);
                return response;
            }
            catch(Exception ex)
            {
                return response.HandleException(response);
            }
        }

        [HttpDelete]
        public ResponseDto<bool> Delete([FromBody] User user)
        {
            ResponseDto<bool> response = new ResponseDto<bool>(_commonResource);
            try
            {
                _userService.Delete(user);
                return response;
            }
            catch (Exception ex)
            {
                return response.HandleDeleteException(response, ex);
            }
        }
    }
}
