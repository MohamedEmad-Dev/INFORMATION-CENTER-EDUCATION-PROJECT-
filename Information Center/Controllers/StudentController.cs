using Information_Center.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
namespace Information_Center.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Student
        public ActionResult Index()
        {
            var studentId = User.Identity.GetUserId();
            var courses = _db.Enrollments.Include(e=> e.Course.Instructor).Where(e=> e.StudentId == studentId).ToList();
                          
                          
            return View(courses);
        }
    }
}