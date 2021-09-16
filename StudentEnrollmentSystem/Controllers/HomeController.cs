using StudentEnrollmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

using DataLibrary.BusinessLogic;
using NPOI.SS.Formula.Functions;
using System.Collections;
using System.Linq;

namespace StudentEnrollmentSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Home Page";
            return View();
        }

    }
}