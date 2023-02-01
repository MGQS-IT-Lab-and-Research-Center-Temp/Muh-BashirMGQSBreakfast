using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGQSBreakfast.Models
{
    public class BreakfastViewModel
    {
        public int Id {get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}