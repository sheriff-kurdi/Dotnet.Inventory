using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurdi.Inventory.Api.Responses
{
    public class PaginatedResponse<T> : BaseResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public PaginatedResponse(T data, int pageNumber, int pageSize, int totalRecords) : base(data)
        {

            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.Message = string.Empty;
            this.Succeeded = true;
            this.Errors = null;
            this.TotalRecords = totalRecords;
            this.TotalPages = totalRecords / pageSize;
        }
    }
}