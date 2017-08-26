using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace ch_hello_world.Models
{
    public class Name 
    {
        public int ID { get; set; }
        [StringLength(255, MinimumLength = 2)]
        [Display(Name="First Name")]
        [Required]
        [RegularExpression(@"^([A-Z][a-z]*)")]
        public string firstName { get; set; }
        [StringLength(255, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        [Required]
        [RegularExpression(@"^([A-Z][a-z]*)")]
        public string lastName { get; set;  }
    }
}