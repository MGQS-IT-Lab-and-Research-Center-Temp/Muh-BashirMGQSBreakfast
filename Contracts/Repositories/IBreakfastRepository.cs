using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGQSBreakfast.Models;
using MGQSBreakfast.Entities;

namespace MGQSBreakfast.Contracts.Repositories
{
    public interface IBreakfastRepository
    {
        Breakfast Create(Breakfast breakfast);
        Breakfast GetById(int id);
        List<Breakfast> GetAll();
        Breakfast FindBreakFast(int id);
        Breakfast Update(int id);
        bool Delete(int id);
        bool BreakFastExist(int id);
        bool BreakFastExist(string name);
    }
}