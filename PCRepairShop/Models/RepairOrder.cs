using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PCRepairShop.Models
{
    public class RepairOrder
    {
        public int Id { get; set; }
        [Display(Name = "Planned Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public int Counter { get; set; }
        public Customer Customer { get; set; }
    }
}