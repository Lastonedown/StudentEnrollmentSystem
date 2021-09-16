using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class CourseOperations
    {
        public static void CreateCourse(string courseId, string courseName, string courseDescription,
            int enrollmentLimit, int totalRegisteredStudents)
        {
            CourseModel data = new CourseModel()
            {
                CourseId = courseId,
                CourseName = courseName,
                CourseDescription = courseDescription,
                EnrollmentLimit = enrollmentLimit,
                TotalRegisteredStudents = totalRegisteredStudents
            };
            string sql =
                @"insert into dbo.CourseTable (CourseId,CourseName,CourseDescription,EnrollmentLimit,TotalRegisteredStudents ) values (@CourseId, @CourseName,@EnrollmentLimit,@TotalRegisteredStudents);";
            SqlDataAccess.SaveData(sql, data);
        }

        public static List<CourseModel> LoadCourseDatabase()
        {
            string sql =
                @"select CourseId, CourseName, CourseDescription, EnrollmentLimit, TotalRegisteredStudents from dbo.CourseTable;";
            return SqlDataAccess.LoadData<CourseModel>(sql);
        }




    }
}

