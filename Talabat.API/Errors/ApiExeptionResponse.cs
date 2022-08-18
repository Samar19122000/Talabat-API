namespace Talabat.API.Errors
{
    public class ApiExeptionResponse:ApiResponse
    {

        public string Details  { get; set; }

        public ApiExeptionResponse(int statusCode , string message = null, string Details = null):base(statusCode , message)
        {
            this.Details = Details;
        }


    }
}
