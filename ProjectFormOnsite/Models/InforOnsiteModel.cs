using ProjectFormOnsite.Data;

namespace ProjectFormOnsite.Models
{
    public class InforOnsiteModel
    {
        public int OnsiteID { get; set; }
        public int EmployeeID { get; set; }
        public int ApproverID { get; set; }
        public string? Destination { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int Status { get; set; }
        public string? Detail { get; set; }
<<<<<<< HEAD
        public string? Reason { get; set; }       
        public virtual Employee? Employee { get; set; }
        public virtual Employee? Approver { get; set; }
        
=======
        public string? Reason { get; set; }
        public int DepartmentID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        //public virtual Employee? Employee { get; set; }
        //public virtual Employee? Approver { get; set; }
>>>>>>> d044544857ee7f92a98cede580844aeaa1d15e28
    }
}
