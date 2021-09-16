using DataLibrary.DataAccess;
using DataLibrary.Models;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLibrary.BusinessLogic
{
    public static class StudentOperations
    {
        public static void CreateStudent(string studentId, string firstName, string lastName,
            DateTime dateOfBirth, string emailAddress, string phoneNumber, string password)
        {
            IUserModel data = new StudentModel
            {
                StudentId = studentId,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth.Date,
                EmailAddress = emailAddress,
                PhoneNumber = phoneNumber,
                Password = password
            };
            string sql =
                @"insert into dbo.StudentTable (StudentId, FirstName,LastName,DateOfBirth,EmailAddress,PhoneNumber,Password) values (@StudentId, @FirstName, @LastName, @DateOfBirth, @EmailAddress, @PhoneNumber, @Password);";
            SqlDataAccess.SaveData(sql, data);
        }

        public static List<StudentModel> LoadStudentDatabase()
        {
            string sql =
                @"select StudentId, FirstName,LastName,DateOfBirth,EmailAddress,PhoneNumber,Password from dbo.StudentTable;";
            return SqlDataAccess.LoadData<StudentModel>(sql);
        }

        public static List<StudentCourseModel> LoadRegisteredStudents()
        {
            string sql =
                @"select StudentId, CourseId from dbo.RegisteredStudentCoursesTable;";
            return SqlDataAccess.LoadData<StudentCourseModel>(sql);
        }

        public static void RegisterStudent(string studentId, string courseId)
        {
            StudentCourseModel data = new StudentCourseModel()
            {
                StudentId = studentId,
                CourseId = courseId,
            };
            string sql =
                @"insert into dbo.RegisteredStudentCoursesTable(StudentId, CourseId) values (@StudentId, @CourseId);";
            SqlDataAccess.SaveData(sql, data);
        }

    
        public static List<StudentModel> GetListOfStudents()
        {
            var data = LoadStudentDatabase();
            List<StudentModel> output = new List<StudentModel>();

            foreach (var row in data)
            {
                output.Add(new StudentModel
                {
                    StudentId = row.StudentId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    DateOfBirth = row.DateOfBirth.Date,
                    EmailAddress = row.EmailAddress,
                    PhoneNumber = row.PhoneNumber,
                    Password = row.Password
                });
            }

            return output;
        }

    }
}