using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DataLibrary.BusinessLogic;
using DataLibrary.Models;
using NPOI.HSSF.Util;
using StudentEnrollmentSystem.Models;
using static DataLibrary.BusinessLogic.StudentOperations;
using Timer = System.Timers.Timer;
namespace StudentEnrollmentSystem.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult StudentRegistrationView()
        {
            ViewBag.Message = "Student Registration";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentRegistrationView(StudentRegistrationModel model)
        {
            TempData.Clear();
            if (ModelState.IsValid)
            {
                var studentList = LoadStudentDatabase();
                Random random = new Random();
                string studentId = model.FirstName.Substring(0, 2) + model.LastName.Substring(0, 4) +
                                   random.Next(00000, 99999);
                for (int i = 0; i < studentList.Count;i++)
                {
                    if(model.EmailAddress == studentList[i].EmailAddress)
                    {
                        TempData.Add("EmailExistsAlert",studentList[i].EmailAddress); 
                        return View();
                    }

                    if (studentId == studentList[i].StudentId)
                    {
                         studentId = model.FirstName.Substring(0, 2) + model.LastName.Substring(0, 4) +
                                           random.Next(00000, 99999);
                    }
                }
                string encryptedPassword = PasswordEncryptDecrypt.EncryptPassword(model.Password);
                CreateStudent(studentId, model.FirstName, model.LastName, model.DateOfBirth, model.EmailAddress, model.PhoneNumber, encryptedPassword);
                TempData.Add("RegistrationSuccessAlert", studentId);
                return RedirectToAction("StudentRegistrationView");
            }
            return View();
        }
    }
}