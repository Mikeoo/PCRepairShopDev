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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public Customer Customer { get; set; }
        public string Description { get; set; }
        public RepairGuy RepairGuy { get; set; }
        public Part UsedPart { get; set; }
    }
}