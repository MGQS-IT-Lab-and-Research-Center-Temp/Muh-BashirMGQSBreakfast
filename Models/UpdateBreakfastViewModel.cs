using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGQSBreakfast.Models
{
    public class UpdateBreakfastViewModel
    {
        public int Id {get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}