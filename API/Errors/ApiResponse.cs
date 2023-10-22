namespace API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int statusCode, string? message = null)
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request",
                401 => "Unauthorized",
                404 => "Resource not found",
                500 => "Server Error",
                _ => "Unexpected Error"
            };
        }       
    }
}
