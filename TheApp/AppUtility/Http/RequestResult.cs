using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUtility.Http
{
    public class RequestResult
    {
        protected string success { get; set; }
        protected string error { get; set; }

        protected object result { get; set; }

        //public Config config { get; set; }

        public ResultType ResultType
        {
            get
            {
                if (!string.IsNullOrEmpty(success) && !string.IsNullOrWhiteSpace(success)) return ResultType.success;
                if (!string.IsNullOrEmpty(error) && !string.IsNullOrWhiteSpace(error)) return ResultType.error;
                return ResultType.unknow;
            }
        }

        public string Message
        {
            get
            {
                if (ResultType == ResultType.success)
                    return success;
                if (ResultType == ResultType.error)
                    return error;
                else
                    return null;
            }
        }


    }

    public enum ResultType
    {
        success,
        error,
        unknow
    }
}
