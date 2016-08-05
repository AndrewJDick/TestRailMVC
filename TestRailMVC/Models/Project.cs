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
        [Required]
        public int Id { get; set; }

        [Display(Name = "Project Code")]
        [DataType(DataType.Text)]
        public string Code { get; set; }

        [Display(Name = "Project Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        public virtual List<User> Users { get; set; }
    }
}