using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestRailMVC.Models
{
    // User inherits from ApplicationUser then adds Forename and Surname fields
    public class User : ApplicationUser
    {
        [Display(Name = "Forename")]
        [DataType(DataType.Text)]
        [Required]
        public string Forename { get; set; }

        [Display(Name = "Surname")]
        [DataType(DataType.Text)]
        [Required]
        public string Surname { get; set; }
    }
}