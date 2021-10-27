using Information_Center.Models;
using Information_Center.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Information_Center.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var viewModel = new HomePageViewModel
            {
                instructors = _db.Users.Where(u => u.UserType == "Instructor").Count(),
                student = _db.Users.Where(u => u.UserType == "Student").Count(),
                Courses = _db.Courses.Include(c=> c.Instructor).ToList()
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}