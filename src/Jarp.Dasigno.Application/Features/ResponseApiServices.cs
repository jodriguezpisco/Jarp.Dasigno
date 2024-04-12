using Jarp.Dasigno.Domain.Models;

namespace Jarp.Dasigno.Application.Features
{
    public static class ResponseApiServices
    {
        public static BaseResponseModel Response(int statusCode, Object Data = null, string message = null)
        {
            bool success = false;

            if (statusCode >= 200 && statusCode < 300)
                success = true;

                    var result = new BaseResponseModel
                    {
                        StatusCode = statusCode,
                        Success = success,
                        Message = message,
                        Data = Data
                    };
            return result;
        }
    }
}
