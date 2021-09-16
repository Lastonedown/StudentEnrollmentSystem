using DataLibrary.BusinessLogic;
using StudentEnrollmentSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.Models;
using CourseModel = StudentEnrollmentSystem.Models.CourseModel;
using StudentOperations = DataLibrary.BusinessLogic.StudentOperations;

namespace StudentEnrollmentSystem.Controllers
{
    public class ManageController : Controller
    {
        public ActionResult LoginView()
        {
            ViewBag.Message = "Student Login";

            return View();
        }


        [HttpPost]
        public ActionResult LoginView(StudentModel student1)
        {
            TempData.Clear();

            bool isStudentValid = StudentValidator.ValidateStudentLogin(student1.StudentId, student1.Password);

            if (isStudentValid == false)
            {
                TempData.Add("InvalidStudentAlert", null);
                return View();
            }

            TempData["studentId"] = student1.StudentId;

            return RedirectToAction("StudentLoginViewInfo");
        }

        public ActionResult StudentLoginViewInfo()
        {
            ViewBag.Message = "StudentInformation";

            string studentId = TempData["studentId"].ToString();
            var students = StudentOperations.GetListOfStudents();

            foreach (var student in students)
            {
                if (studentId.Equals(student.StudentId))
                {
                    List<StudentInfoModel> studentInfo = new List<StudentInfoModel>();

                    studentInfo.Add(new StudentInfoModel
                    {
                        StudentId = student.StudentId, FirstName = student.FirstName, LastName = student.LastName,
                        DateOfBirth = student.DateOfBirth, EmailAddress = student.EmailAddress,
                        PhoneNumber = student.PhoneNumber

                    });
                    TempData.Keep("StudentId");
                    return View(studentInfo);
                }
            }

            return View();
        }

        public ActionResult CourseRegistrationView()
        {
            var alertCleared = TempData.Remove("AlreadyRegisteredAlert");
            ViewBag.Message = "Student Registration";
            string studentId = TempData["studentId"].ToString();
            if (ModelState.IsValid)
            {
                var registeredStudentsList = StudentOperations.LoadRegisteredStudents();
                

                var courseList = CourseOperations.LoadCourseDatabase();

                for (int i = 0; i < registeredStudentsList.Count; i++)
                {
                    if (registeredStudentsList[i].StudentId == studentId &&
                        registeredStudentsList[i].CourseId == courseList[i].CourseId)
                    {
                        TempData.Add("AlreadyRegisteredAlert", registeredStudentsList[i].CourseId);
                        TempData.Keep("StudentId");
                        return View();
                    }

                    StudentOperations.RegisterStudent(studentId, courseList[i].CourseId);
                    TempData.Add("ClassRegistrationSuccessfulAlert", registeredStudentsList);
                    return View();
                }
            }return View();
        }
    }
}