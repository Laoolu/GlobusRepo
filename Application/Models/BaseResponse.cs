using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public abstract class BaseResponse<T>
    {
        public string statusCode { get; set; }
        public string description { get; set; }
        public T data { get; set; }

        protected BaseResponse(T resource)
        {
            statusCode = "00";
            description = "success";
            data = resource;
        }

        protected BaseResponse(string message)
        {
            statusCode = "96";
            description = message;
            data = default;
        }

        protected BaseResponse(string rspCode, string descriptn)
        {
            statusCode = rspCode;
            description = descriptn;
            data = default;
        }
    }
}
