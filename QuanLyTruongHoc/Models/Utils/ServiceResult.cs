

namespace QuanLyTruongHoc.Models.Utils
{
    public class ServiceResult
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public int? TotalRecords { get; set; }
        public int? TotalPages { get; set; }
        public object Data { get; set; }

        public ServiceResult()
        {

        }
        public ServiceResult(string Message)
        {
            this.Message = Message;
        }
    }

    public class ServiceResultSuccess : ServiceResult
    {
        public ServiceResultSuccess()
        {
            Code = CommonConst.Success;
        }
        public ServiceResultSuccess(string msg)
        {
            Code = CommonConst.Success;
            Message = msg;
        }
        public ServiceResultSuccess(string msg, object data)
        {
            Code = CommonConst.Success;
            Message = msg;
            Data = data;
        }
        public ServiceResultSuccess(object data)
        {
            Code = CommonConst.Success;
            Data = data;
        }
    }

    public class ServiceResultError : ServiceResult
    {
        public ServiceResultError()
        {
            Code = CommonConst.Error;
        }
        public ServiceResultError(string msg)
        {
            Code = CommonConst.Error;
            Message = msg;
        }
        /// <summary>
        /// Show error inline
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="field"></param>
        public ServiceResultError(string msg, string field)
        {
            Code = CommonConst.Error;
            Message = msg;
            Data = new[] { new { Field = field, Mss = msg } };
        }

        public ServiceResultError(string msg, object data)
        {
            Code = CommonConst.Error;
            Message = msg;
            Data = data;
        }
    }
    public class ServiceResultPostMessage : ServiceResult
    {
        public ServiceResultPostMessage(string msg, string code)
        {
            Code = code;
            Message = msg;
        }
    }

    #region Mobile

    public class ServiceResultMobile
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public int? TotalRecords { get; set; }
        public int? TotalPages { get; set; }
        public int? CurrentPage { get; set; }
        public object Data { get; set; }
    }
    public class ServiceResultSuccessMobile : ServiceResultMobile
    {
        public ServiceResultSuccessMobile()
        {
            Code = CommonConst.Success;
        }
        public ServiceResultSuccessMobile(string msg)
        {
            Code = CommonConst.Success;
            Message = msg;
        }
        public ServiceResultSuccessMobile(string msg, object data)
        {
            Code = CommonConst.Success;
            Message = msg;
            Data = data;
        }
        public ServiceResultSuccessMobile(object data)
        {
            Code = CommonConst.Success;
            Data = data;
        }
    }
    public class ServiceResultErrorMobile : ServiceResultMobile
    {
        public ServiceResultErrorMobile()
        {
            Code = CommonConst.Error;
        }
        public ServiceResultErrorMobile(string msg)
        {
            Code = CommonConst.Error;
            Message = msg;
        }
        /// <summary>
        /// Show error inline
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="field"></param>
        public ServiceResultErrorMobile(string msg, string field)
        {
            Code = CommonConst.Error;
            Message = msg;
            Data = new[] { new { Field = field, Mss = msg } };
        }

        public ServiceResultErrorMobile(string msg, object data)
        {
            Code = CommonConst.Error;
            Message = msg;
            Data = data;
        }
    }

    #endregion

}