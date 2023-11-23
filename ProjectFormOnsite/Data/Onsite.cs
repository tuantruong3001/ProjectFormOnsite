﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectFormOnsite.Data
{
    [Table("Onsite")]
    public class Onsite
    {
        [Key]
        public int OnsiteID { get; set; }
        public int EmployeeID { get; set;}
        public int ApproverID { get; set; }
        public string? Destination { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int Status { get; set; }
        public string? Detail {  get; set; }
        public string? Reason { get; set; }
    }
}