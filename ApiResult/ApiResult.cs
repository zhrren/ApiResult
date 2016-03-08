using System;

namespace Mark.ApiResult
{

    public enum ApiCode
    {
        Success = 0,
        Unauthorized = 1,
        NotFound = 2,
        InternalServerError = 3,
        UnsupportedMediaType = 4,
        BadRequest = 5,
        NotSupport = 6,
        ModelValidationError = 7,
        RequestWarn = 8,
        RequestReject = 9
    }

    public class ApiResult : ApiResult<object>
    {
        public ApiResult()
        {
        }

        /// <summary>
        /// 操作成功
        /// </summary>
        /// <param name="message"></param>
        public ApiResult(string message = null) : base(message) { }

        /// <summary>
        /// 操作成功
        /// </summary>
        public ApiResult(object data = null, string message = "OK") : base(data, message) { }

        /// <summary>
        /// 操作失败
        /// </summary>
        /// <param name="code">ref ApiCode</param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public ApiResult(ApiCode code, object data = null) : base(code, data) { }

        /// <summary>
        /// 操作失败
        /// </summary>
        /// <param name="typeCode">大于0且小于1000，全局唯一</param>
        /// <param name="errorCode">大于0且小于1000</param>
        /// <param name="message"></param>
        public ApiResult(int typeCode, int errorCode, string message, object data = null)
            : base(typeCode, errorCode, message, data)
        { }

        /// <summary>
        /// 操作失败
        /// </summary>
        /// <param name="typeCode">大于0且小于1000，全局唯一</param>
        /// <param name="message"></param>
        public ApiResult(int typeCode, string message, object data = null)
            : base(typeCode, message, data)
        { }
    }

    /// <summary>
    /// 用于WebAPI，动作返回的结果
    /// 动作：
    /// POST 适用于修改数据
    /// GET  适用于查看数据
    /// </summary>
    public class ApiResult<TData> where TData : class
    {
        public ApiResult()
        {
        }

        /// <summary>
        /// 操作成功
        /// </summary>
        /// <param name="message"></param>
        public ApiResult(string message = null)
        {
            Message = message;
        }

        /// <summary>
        /// 操作成功
        /// </summary>
        public ApiResult(TData data = null, string message = "OK")
        {
            Code = (int)ApiCode.Success;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// 操作失败
        /// </summary>
        /// <param name="code">ref ApiCode</param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public ApiResult(ApiCode code, TData data = null)
        {
            Code = (int)code;
            Message = code.ToString();
            Data = data;
        }

        /// <summary>
        /// 操作失败
        /// </summary>
        /// <param name="typeCode">大于0且小于1000，全局唯一</param>
        /// <param name="errorCode">大于0且小于1000</param>
        /// <param name="message"></param>
        public ApiResult(int typeCode, int errorCode, string message, TData data = null)
        {
            if (typeCode <= 0 || typeCode >= 10000)
                throw new ArgumentOutOfRangeException("type", "必须大于0且小于1000");

            if (errorCode <= 0 || errorCode >= 10000)
                throw new ArgumentOutOfRangeException("code", "必须大于0且小于1000");

            Code = typeCode * 10000 + errorCode;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// 操作失败
        /// </summary>
        /// <param name="typeCode">大于0且小于1000，全局唯一</param>
        /// <param name="message"></param>
        public ApiResult(int typeCode, string message, TData data = null)
        {
            if (typeCode <= 0 || typeCode >= 10000)
                throw new ArgumentOutOfRangeException("type", "必须大于0且小于1000");

            Code = typeCode * 10000;
            Message = message;
            Data = data;
        }

        public int Code { get; set; }

        public string Message { get; set; }

        public TData Data { get; set; }
    }
}
