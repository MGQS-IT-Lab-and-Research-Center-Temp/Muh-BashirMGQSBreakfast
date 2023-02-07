using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGQSBreakfast.Entities;

namespace MGQSBreakfast.Models.Response
{
    public class BreakfastResponseModels : BaseResponseModel
    {
        public List<Breakfast> Data { get; set; }
    }
}