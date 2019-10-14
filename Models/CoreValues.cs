using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Group5Project.Models
{
    public class CoreValues
    {
        [Key]
        public int coreValueId { get; set; }

        [Display(Name = "Recognition Description")]
        [Required(ErrorMessage = "Description is Required")]
        [StringLength(500)]
        public string coreValueName { get; set; }
        public ICollection<Recognition> Recognition { get; set; }
    }
}