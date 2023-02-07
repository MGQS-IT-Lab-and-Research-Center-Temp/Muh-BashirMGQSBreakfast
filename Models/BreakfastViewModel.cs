using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGQSBreakfast.Entities;

namespace MGQSBreakfast.Models
{
    public class BreakfastViewModel
    {
        public int Id {get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public static implicit operator BreakfastViewModel(List<Breakfast> v)
        {
            throw new NotImplementedException();
        }
    }
}