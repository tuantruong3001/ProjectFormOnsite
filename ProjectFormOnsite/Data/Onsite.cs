using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectFormOnsite.Data
{
    [Table("Onsite")]
    public class Onsite
    {
        [Key]
        public int OnsiteID { get; set; }
<<<<<<< HEAD
        [ForeignKey("EmployeeID")]
        public int EmployeeID { get; set;}
        [ForeignKey("ApproverID")]
=======
        //[ForeignKey("EmployeeID")]
        public int EmployeeID { get; set;}
        //[ForeignKey("ApproverID")]
>>>>>>> d044544857ee7f92a98cede580844aeaa1d15e28
        public int ApproverID { get; set; }
        public string? Destination { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int Status { get; set; }
        public string? Detail {  get; set; }
        public string? Reason { get; set; }
<<<<<<< HEAD
        public virtual Employee? Employee { get; set; }
        public virtual Employee? Approver { get; set; }
=======
        /*public virtual Employee? Employee { get; set; }
        public virtual Employee? Approver { get; set; }*/
>>>>>>> d044544857ee7f92a98cede580844aeaa1d15e28

    }
}
