using System;

namespace Mark.ApiResult
{

    public class ApiResult<TData>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; }

        public static implicit operator ApiResult(ApiResult<TData> result)
        {
            return new ApiResult()
            {
                Code = result.Code,
                Message = result.Message,
                Data = result.Data
            };
        }

        public static explicit operator ApiResult<TData>(ApiResult result)
        {
            return new ApiResult<TData>()
            {
                Code = result.Code,
                Message = result.Message,
                Data = (TData)result.Data
            };
        }
    }

    public class ApiResult: ApiResult<object>
    {
        public static ApiResult Error(int errorCode, string errorMessage)
        {
            if (errorCode == 0) throw new ArgumentException("errorCode != 0");

            return new ApiResult()
            {
                Code = errorCode,
                Message = errorMessage
            };
        }

        public static ApiResult<T> Error<T>(int errorCode, string errorMessage,
            T data = default(T))
        {
            if (errorCode == 0) throw new ArgumentException("errorCode");

            return new ApiResult<T>()
            {
                Code = errorCode,
                Message = errorMessage,
                Data = data
            };
        }
        
        public static ApiResult Success()
        {
            return new ApiResult()
            {
                Code = 0,
                Message = "OK"
            };
        }

        public static ApiResult<T> Success<T>(T data, string message = "OK")
        {
            return new ApiResult<T>()
            {
                Code = 0,
                Message = message,
                Data = data
            };
        }
    }
}
