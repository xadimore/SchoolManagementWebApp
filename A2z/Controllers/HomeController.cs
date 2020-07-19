using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using A2z.Models;
using A2z.Services;
using Microsoft.AspNetCore.Authorization;

namespace A2z.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Istudent rep;

        public DatabaseConn Db { get; }

        public HomeController(ILogger<HomeController> logger, DatabaseConn db, Istudent rep)
        {
            _logger = logger;
            Db = db;
            this.rep = rep;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            var StundentsCount = Db.Students.Count();
            var CourseCount = Db.Courses.Count();
            var epc = Db.Employees.Count();
            var registeredCourse = Db.StudentCourses.ToList();
            var rc = Db.StudentCourses.Count();


            ViewBag.registeredCourse = registeredCourse;
            var studentd = rep.GetStudents().OrderByDescending(v => v.Id).Take(5);
            ViewBag.Rc = rc;
            ViewBag.StudentsList = studentd;
            ViewBag.StudentCount = StundentsCount;
            ViewBag.Employee = epc;
            ViewBag.Course = CourseCount;
            return View();
        }


        public IActionResult StudentDetails()
        {
            return View();
        }


        public IActionResult AddStudent()
        {
            return View();
        }
    }
}
