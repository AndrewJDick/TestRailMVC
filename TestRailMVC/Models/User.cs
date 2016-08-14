using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestRailMVC.Models
{
    public class User
    {   
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Forename")]
        [DataType(DataType.Text)]
        public string Forename { get; set; }

        [Display(Name = "Surname")]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual List<Project> Projects { get; set; }
    }
}