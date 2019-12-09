using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Group5Project.Models
{
   

    public class Employee
    {
        [Key]
        
        public Guid employeeID { get; set; }

        [Display (Name="First Name")]
        [Required (ErrorMessage ="First Name is Required")]
        [StringLength(50)]
        public  string  employeeFirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        [StringLength(50)]
        public string employeeLastName { get; set; }
        [Display(Name = "Employee Full Name")]

        public string fullEmployeeName { get { return employeeLastName + ", " + employeeFirstName; } }

        [Display(Name="Employee Email")]
        public string email { get; set; }


        public enum BusinessUnit
        {
            Boston = 1,
            Charlotte = 2,
            Chicago = 3,
            Cincinnati = 4,
            Cleveland = 5,
            Columbus = 6,
            India = 7,
            Indianapolis = 8,
            Louisville = 9,
            Miami = 10,
            Seattle = 11,
            StLouis = 12,
            Tampa = 13
        }

        [Display(Name = "Business Unit")]
        [Required(ErrorMessage = "Business Unit is Required")]
      
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