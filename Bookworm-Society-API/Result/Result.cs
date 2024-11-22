namespace Bookworm_Society_API.Result
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; } // Nullable data
        public ErrorType ErrorType { get; set; }

        public static Result<T> SuccessResult(T data)
        {
            return new Result<T>
            {
                Success = true,
                Message = "Success", 
                Data = data,
                ErrorType = ErrorType.None
            };
        }

        public static Result<T> FailureResult(string message, ErrorType errorType)
        {
            return new Result<T>
            {
                Success = false,
                Message = message,
                Data = default, // No data for failure
                ErrorType = errorType
            };
        }
    }
    public enum ErrorType
    {
        None,
        NotFound,
        ValidationError,
        Unauthorized,
        Conflict
    }
}
