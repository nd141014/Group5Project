using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5Project.Models
{
    public class Recognition
    {
        [Key]
        public int recognitionId { get; set; }

        [Display(Name = "Recognized Employee")]
        [Required(ErrorMessage = "Employee Name is Required")]
        
        public Guid employeeID { get; set; }
        [ForeignKey("employeeID")]
        public virtual Employee Awardee { get; set; }
        
        public enum CoreValue
        {
            [Display(Name = "Please Select")] Select = 0,
            [Display(Name = "Commit to Delivery Excellence")] Excellence = 1,
            [Display(Name = "Embrace Integrity and Openness")] Integrity = 2,
            [Display(Name = "Practice Responsible Stewardship")] Stewardship = 3,
            [Display(Name = "Ignite Passion for the Greater Good")] Good = 4,
            [Display(Name = "Invest in an Exceptional Culture")] Culture = 5,
            [Display(Name = "Strive to Innovate")] Innovate = 6,
            [Display(Name = "Live a Balanced Life")] Balance = 7

        }
        [Display(Name = "Core Value")]
        [Range(1,7, ErrorMessage = "A core value is required")]
        public CoreValue RecognitionValue { get; set; }


        [Display(Name = "Recognition Message")]
        [Required(ErrorMessage = "Description is Required")]
        [StringLength(500)]
        public string recognitionDescription { get; set; }

        
        [Display(Name = "Submitting Employee")]
        [Required(ErrorMessage = "Submitting Employee is Required")]


        public Guid RecognizeeEmployeeID { get; set; }
        [ForeignKey("RecognizeeEmployeeID")]
        public virtual Employee RecognizingEmployee { get; set; }
    }
}