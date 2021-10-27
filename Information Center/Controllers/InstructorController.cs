using Information_Center.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Information_Center.viewModel;

namespace Information_Center.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Instructor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetInstructorStudents()
        {   
            var userId = User.Identity.GetUserId();
            var enrolledStudents = 
                     from enroll in _db.Enrollments
                     join course in _db.Courses
                     on enroll.CourseId equals course.Id
                     where course.InstructorId ==userId
                     select enroll;
            return View(enrolledStudents.ToList());
        }
    }
}