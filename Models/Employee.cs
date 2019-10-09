using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group5Project.Models
{
    public class Employee
    {
        public int employeeID { get; set; }
        public  string  employeeFirstName { get; set; }
        public string employeeLastName { get; set; }
        public string employeeBusinessUnit { get; set; }
        public DateTime employeeHireDate { get; set; }
        public string employeeTitle{ get; set; }


    }
}