using Information_Center.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_Center.Controllers
{
    [Authorize(Roles = "Admins")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllStudents()
        {
            var students = _db.Users.Where(u => u.UserType == "Student").ToList();
            return View(students);
        }
        public ActionResult GetAllInstructors()
        {
            var instructors = _db.Users.Where(u => u.UserType == "Instructor").ToList();
            return View(instructors);
        }
    }
}