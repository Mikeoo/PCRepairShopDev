using PCRepairShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCRepairShop.ViewModels
{
    public class RepairOrderVM
    {
        public List<RepairOrder> RepairOrders { get; set; }
        public Dictionary<string, int> StatusCounter { get; set; }
    }
}