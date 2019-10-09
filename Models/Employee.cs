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

        [Display (Name="Employee First Name")]
        [Required (ErrorMessage ="Employee First Name is Required")]
        [StringLength(50)]
        public  string  employeeFirstName { get; set; }

        [Display(Name = "Employee Last Name")]
        [Required(ErrorMessage = "Employee Last Name is Required")]
        [StringLength(50)]
        public string employeeLastName { get; set; }

        [Display(Name = "Employee Business Unit")]
        [Required(ErrorMessage = "Employee Business Unit is Required")]
        [StringLength(50)]
        public string employeeBusinessUnit { get; set; }

        [Display(Name = "Employee Hire Date")]
        [Required(ErrorMessage = "Employee Hire Date is Required")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:d}",ApplyFormatInEditMode =true)]
        public DateTime employeeHireDate { get; set; }

        [Display(Name = "Employee Title")]
        [Required(ErrorMessage = "Employee Title is Required")]
        [StringLength(50)]
        public string employeeTitle{ get; set; }


    }
}