using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Group5Project.Models
{
    public class Employee
    {
        public int employeeID { get; set; }

        [Display (Name="First Name")]
        [Required (ErrorMessage ="First Name is Required")]
        [StringLength(50)]
        public  string  employeeFirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        [StringLength(50)]
        public string employeeLastName { get; set; }

        

        public enum BusinessUnit
        {
            Marketing = 1,
            IT = 2,
            HR = 3
        }

        [Display(Name = "Business Unit")]
        [Required(ErrorMessage = "Business Unit is Required")]
        [StringLength(50)]
        public BusinessUnit employeeBusinessUnit { get; set; }

        [Display(Name = "Hire Date")]
        [Required(ErrorMessage = "Hire Date is Required. Please enter date as dd/mm/yyyy.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:d}",ApplyFormatInEditMode =true)]
        public DateTime employeeHireDate { get; set; }

        [Display(Name = "Job Title")]
        [Required(ErrorMessage = "Job Title is Required")]
        [StringLength(50)]
        public string employeeTitle{ get; set; }

        public ICollection<Recognition> Recognition { get; set; }

    }
}