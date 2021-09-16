using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{ 
    public class CourseModel
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int EnrollmentLimit { get; set; }
        public int TotalRegisteredStudents { get; set; }
    }
}
