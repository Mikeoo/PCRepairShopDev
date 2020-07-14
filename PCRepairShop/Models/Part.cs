using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCRepairShop.Models
{
    public class Part
    {
        public int Id { get; set; }
        public bool InStock { get; set; }
        public PartListItem PartListItem { get; set; }
    }
}