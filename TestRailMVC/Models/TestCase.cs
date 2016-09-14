using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace TestRailMVC.Models
{
    public class TestCase
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Priority")]
        public Priority Priority { get; set; }

        [Display(Name = "Preconditions")]
        [DataType(DataType.MultilineText)]
        public string Precondition { get; set; }

        [Display(Name = "Steps")]
        [DataType(DataType.MultilineText)]
        public string Step { get; set; }

        [Display(Name = "Status")]
        public Status Status { get; set; }

        [Display(Name = "Comment")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        // One to many relationship with Project
        public virtual Project Project { get; set; }
    }
    
    public enum Status
    { 
        Pass = 1, 
        Fail = 2, 
        Blocked = 3,
        Invalid = 4
    }

    public enum Priority
    {
        High = 1,
        Normal = 2,
        Low = 3,
    }
}