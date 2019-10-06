using Sreekovil.API.Resources;
using System;
namespace Sreekovil.API
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }

        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; }

        private ICommonResource _commonResource { get; set; }

        public ResponseDto(ICommonResource commonResource)
        {
            _commonResource = commonResource;
            this.Message = _commonResource.SaveSuccess;
        }

        public ResponseDto<T> HandleException(ResponseDto<T> response)
        {
            response.IsSuccess = false;
            response.Message = _commonResource.UnExpectedError;
            return response;
        }

        public ResponseDto<T> HandleCustomException(ResponseDto<T> response, Exception ex)
        {
            response.IsSuccess = false;
            response.Message = _commonResource.GetString(ex.Message);
            return response;
        }

        public ResponseDto<T> HandleDeleteException(ResponseDto<T> response, Exception ex)
        {
            response.IsSuccess = false;
            response.Message = _commonResource.EntityAssignmentExists;
            return response;
        }
    }
}