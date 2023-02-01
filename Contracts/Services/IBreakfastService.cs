using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGQSBreakfast.Models;
using MGQSBreakfast.Entities;
using MGQSBreakfast.Models.Response;

namespace MGQSBreakfast.Contracts.Services
{
    public interface IBreakfastService
    {
        BreakfastResponseModel RegisterBreakfast(CreateBreakfastViewModel request);
        BreakfastResponseModel GetBreakfast(int id);
        BreakfastResponseModel DeleteBreakfast(int id);
        BreakfastResponseModel UpdateBreakfast(int id, UpdateBreakfastViewModel request);
        BreakfastResponseModel GetAllBreakfast(BreakfastViewModel breakFast);
    }
}