using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGQSBreakfast.Models.Response
{
    public class BaseResponseModel
    {
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}