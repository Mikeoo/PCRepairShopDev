using PCRepairShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PCRepairShop.ViewModels
{
    [NotMapped]
    public class RepairOrderVM
    {
        public List<RepairOrder> RepairOrders { get; set; }
        public Dictionary<string, int> StatusCounter { get; set; }
    }
}