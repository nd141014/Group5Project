﻿using System;
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
        [StringLength(50)]
        public string emloyeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [Display(Name = "Core Value")]
        [Required(ErrorMessage = "Core Value is Required")]
        [StringLength(50)]
        
        public string coreValueName { get; set; }
        public virtual CoreValues CoreValues { get; set; }
        [Display(Name = "Recognition Description")]
        [Required(ErrorMessage = "Description is Required")]
        [StringLength(500)]
        public string recognitionDescription { get; set; }

        [Display(Name = "Recognition Points")]
        [Required(ErrorMessage = "Points are Required and value must be 1-10")]
        
        public int recognitionPoints { get; set; }
        [Display(Name = "Submitting Employee")]
        [Required(ErrorMessage = "Submitting Employee is Required")]
        [StringLength(50)]
        public string employeeID { get; set; }
        
    }
}