using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCRepairShop.Models
{
    public class PartListItem
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}