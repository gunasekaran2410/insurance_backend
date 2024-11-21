namespace Insurance.Models
{
    public class ErrorModel
    {
        public string? error_status { get; set; }
        public string? error_message { get; set; }

        public static async Task<ErrorModel> ErrorMessage(string status, string message)
        {

            ErrorModel error = new ErrorModel
            {
                error_status = status,
                error_message = message
            };
            return await Task.FromResult<ErrorModel>(error);
        }
    }
}
