﻿using App.Domain.Entities;

namespace App.API.Models
{
    public class InforOnsiteModel
    {
        public int OnsiteID { get; set; }
        public int EmployeeID { get; set; }
        public int ApproverID { get; set; }
        public string Destination { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public int Status { get; set; }
        public string Detail { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;       
        public virtual Employee? Employee { get; set; }
        public virtual Employee? Approver { get; set; }       
    
    }
}
