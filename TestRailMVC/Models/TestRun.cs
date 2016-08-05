using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestRailMVC.Models
{
    public class TestRun
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required]
        public int TestRunId { get; set; }

        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Created By")]
        [DataType(DataType.Text)]
        public User User { get; set; }

        [Display(Name = "Assigned To")]
        [DataType(DataType.Text)]
        public User AssignedTo { get; set; }

        [Display(Name = "Milestone")]
        [DataType(DataType.Text)]
        public Milestone Milestone { get; set; }

        

        
    }
}