using DataLibrary.Models;
using DataLibrary.BusinessLogic;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class StudentValidator
    {
        public static bool ValidateStudentLogin(string studentId, string password)
        {
            List<StudentModel> student = StudentOperations.GetListOfStudents();
            StudentModel foundStudent = new StudentModel();

            bool isPasswordValid = false;

            foreach (var t in student)
            {
                string trimmedStudentId = t.StudentId.Trim();

                if (trimmedStudentId.Equals(studentId.Trim()))
                {
                    foundStudent = t;
                  
                    string savedPasswordHash = foundStudent.Password;

                    isPasswordValid = PasswordEncryptDecrypt.DecrpytPassword(savedPasswordHash, password);
                }
            }

            if (!isPasswordValid)
            {
                return false;
            }

            return true;
        }
    }
}
