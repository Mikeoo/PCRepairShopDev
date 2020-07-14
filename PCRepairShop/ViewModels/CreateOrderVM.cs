using PCRepairShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCRepairShop.ViewModels
{
    public class CreateOrderVM
    {
        public RepairOrder RepairOrder { get; set; }
        public List<Customer> customers { get; set; }
    }
}