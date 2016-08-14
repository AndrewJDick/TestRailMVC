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
    }
}