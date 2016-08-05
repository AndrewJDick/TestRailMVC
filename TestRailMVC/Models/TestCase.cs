using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [RegularExpression("^[1-5]{1}$")]
        public int Priority { get; set; }

        [Display(Name = "Preconditions")]
        [DataType(DataType.MultilineText)]
        public string Precondition { get; set; }

        [Display(Name = "Steps")]
        [DataType(DataType.MultilineText)]
        public string Step { get; set; }

        [Display(Name = "Status")]
        [DataType(DataType.Text)]
        public string Status { get; set; }

        [Display(Name = "Comment")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        [Display(Name = "Test Run")]
        [DataType(DataType.Text)]
        public TestRun TestRun { get; set; }
    }
}