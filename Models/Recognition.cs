using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Group5Project.Models
{
    public class Recognition
    {
        [Key]
        public int recognitionId { get; set; }

        [Display(Name = "Recognized Employee")]
        [Required(ErrorMessage = "Employee Name is Required")]
        
        public Guid employeeID { get; set; }
        public virtual Employee Employee { get; set; }

        public enum CoreValue
        { 
            [Display(Name = "Commit to Delivery Excellence")] Excellence = 1,
            [Display(Name = "Embrace Integrity and Openness")] Integrity = 2,
            [Display(Name = "Practice Responsible Stewardship")] Stewardship = 3,
            [Display(Name = "Ignite Passion for the Greater Good")] Good = 4,
            [Display(Name = "Invest in an Exceptional Culture")] Culture = 5,
            [Display(Name = "Strive to Innovate")] Innovate = 6
        }
        public CoreValue RecognitionValue { get; set; }


        [Display(Name = "Recognition Description")]
        [Required(ErrorMessage = "Description is Required")]
        [StringLength(500)]
        public string recognitionDescription { get; set; }

        [Display(Name = "Recognition Points")]
        [Required(ErrorMessage = "Points are Required and value must be 1-10")]
        
        public int recognitionPoints { get; set; }
        [Display(Name = "Submitting Employee")]
        [Required(ErrorMessage = "Submitting Employee is Required")]
        
        public Guid RecognizeeEmployeeID { get; set; }
        
    }
}