using System;

namespace Talabat.API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCode, string message = null)
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefultStatusCodeMessage(statusCode);
        }

        private string GetDefultStatusCodeMessage(int statusCode)
          => statusCode switch
          {
              400 => "a bad Requset You have Made",
              401 => "Authorized , You are not ",
              404 => "Resource  was not found",
              500 => "Errore are the path to the dark side. Errors lead to Anger. Anger leads to hate. Hate leads to career change.",
              _ => null

          };
    }
}
