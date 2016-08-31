using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestRailMVC.Models
{
    public class Project
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Project Code")]
        [DataType(DataType.Text)]
        [Required]
        public string Code { get; set; }    

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        // Many to Many relationship with Users
        public virtual List<ApplicationUser> Users { get; set; }

        // One to Many relationship with TestCases
        public virtual List<TestCase> TestCases { get; set; }
    }
}