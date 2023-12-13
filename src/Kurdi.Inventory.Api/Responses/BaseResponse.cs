using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurdi.Inventory.Api.Responses
{
    public class BaseResponse<T>
    {
        public BaseResponse(T data, bool succeeded = true, string message = "", string[]? errors = null)
        {
            Succeeded = succeeded;
            Message = message;
            Errors = errors;
            Data = data;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[]? Errors { get; set; }
        public string Message { get; set; }
    }
}