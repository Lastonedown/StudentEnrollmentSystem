using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentEnrollmentSystem.Models
{
    public class CourseRegistrationModel
    {
        [Display(Name = "Student Id")]
        public string StudentId { get; set; }
        
        [Display(Name = "Course Id")]
        [Required(ErrorMessage = "Course selection is required")]
        public string CourseId { get; set; }


        public string Semester { get; set; }
        
        
    }
}