namespace Insurance.Models
{

    public partial class OutputResult
    {
        public byte StatusCode { get; set; }
        public string StatusResult { get; set; }
        public OutputResult Success(string status)
        {
            OutputResult Result = new OutputResult()
            {
                StatusCode = 1,
                StatusResult = status,
            };
            return Result;
        }
        public OutputResult Warning(string status)
        {
            OutputResult Result = new OutputResult()
            {
                StatusCode = 0,
                StatusResult = status,
            };
            return Result;
        }
        public OutputResult Error(string status)
        {
            OutputResult Result = new OutputResult()
            {
                StatusCode = 204,
                StatusResult = status,
            };
            return Result;
        }
    }
}
