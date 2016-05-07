using System;

namespace Mark.ApiResult
{
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
        /// <param name="typeCode">大于0且小于1000，全局唯一</param>
        /// <param name="message"></param>
        public ApiResult(int error, string message, object data = null)
            : base(error, message, data)
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
            Message = message;
            Data = data;
        }

        /// <summary>
        /// 操作失败
        /// </summary>
        /// <param name="typeCode">大于0且小于1000，全局唯一</param>
        /// <param name="message"></param>
        public ApiResult(int error, string message, TData data = null)
        {
            Code = error;
            Message = message;
            Data = data;
        }

        public int Code { get; set; }

        public string Message { get; set; }

        public TData Data { get; set; }
    }
}
