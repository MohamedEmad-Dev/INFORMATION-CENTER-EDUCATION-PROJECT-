using Information_Center.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Information_Center.Controllers
{
    [Authorize(Roles ="Instructor")]
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Course
         [Authorize(Roles = "Instructor")]
        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();
            var courses = _db.Courses.Include(c=> c.Instructor).Where(c=> c.InstructorId == userId).ToList();
            return View(courses);
        }

         [Authorize(Roles = "Instructor")]
        public ActionResult CreateCourse()
        {
            //var coure = new Course();
            return View();
        }


        public string AddImge(HttpPostedFileBase ImageFile, string Title)
        {
            string ImagePath = "";
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Server.MapPath("~/images/courses/" + Title);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    ImagePath = "~/images/courses/" + Title + "/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/images/courses/" + Title), fileName);
                    ImageFile.SaveAs(fileName);
                }
            }
            return ImagePath;
        }
         [Authorize(Roles = "Instructor")]
        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
            if (course == null) return HttpNotFound();
           
            course.ImagePath = AddImge(course.ImageFile, course.Title);
            course.InstructorId = User.Identity.GetUserId();
            _db.Courses.Add(course);
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = course.Id });
        }
        public ActionResult Details(int? id)
        {
            if (id == null) return HttpNotFound();
            var course = _db.Courses.Where(c => c.Id == id).SingleOrDefault();
            if (course == null) return HttpNotFound();
            Session["Course_Id"] = id;
            return View(course);
        }
         [Authorize(Roles = "Instructor")]
        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound();
            var course = _db.Courses.Where(c => c.Id == id).SingleOrDefault();
            if (course == null) return HttpNotFound();
            deleteImage(course);
            _db.Courses.Remove(course);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public void deleteImage(Course course)
        {
            if (Directory.Exists(Server.MapPath("~/images/courses/" + course.Title)) && System.IO.File.Exists(Server.MapPath("~/images/courses/" + course.Title + "/" + course.ImagePath.Split('/').Last())))
            {


                System.IO.File.Delete(Server.MapPath("~/images/courses/" + course.Title + "/" + course.ImagePath.Split('/').Last()));
                Directory.Delete(Server.MapPath("~/images/courses/" + course.Title));

            }
        }

         [Authorize(Roles = "Instructor")]
        public ActionResult EditForm()
        {
            return View();
        }
         [Authorize(Roles = "Instructor")]
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();
            var course = _db.Courses.Where(c => c.Id == id).SingleOrDefault();
            if (course == null) return HttpNotFound();
            
            return View("EditForm",course);

        }
         [Authorize(Roles = "Instructor")]
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (course == null) return HttpNotFound();

            var courseInDb = _db.Courses.Where(c => c.Id == course.Id).SingleOrDefault();
            if (courseInDb == null) return HttpNotFound();
            string oldImgPath = Request.MapPath(courseInDb.ImagePath);
            string oldDirPath = Request.MapPath("~/images/courses/" + courseInDb.Title);
            
            courseInDb.Title = course.Title;
            courseInDb.Description = course.Description;
            if (course.ImageFile != null && course.ImageFile.ContentLength > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(course.ImageFile.FileName);
                string extension = Path.GetExtension(course.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //string newDirPath = Server.MapPath("~/images/courses/" + courseInDb.Title);
                //if (!Directory.Exists(newDirPath))
                //{
                //    Directory.CreateDirectory(newDirPath);
                //    //string oldDirPath = Server.MapPath("~/images/courses/" + OldPath.Split('/').Last());
                //    if(Directory.Exists(oldDirPath))
                //    Directory.Move(oldDirPath, newDirPath);
                //    //Directory.Delete(oldDirPath);
                //    courseInDb.ImagePath = "~/images/courses/" + courseInDb.Title + "/" + fileName;
                //    fileName = Path.Combine(Server.MapPath("~/images/courses/" + courseInDb.Title), fileName);
                //    course.ImageFile.SaveAs(fileName);
                //}
                courseInDb.ImagePath = "~/images/courses/" + courseInDb.Title + "/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/images/courses/" + courseInDb.Title), fileName);
                course.ImageFile.SaveAs(fileName);

                if (System.IO.File.Exists(oldImgPath))
                {
                    //System.IO.File.Move("")
                    System.IO.File.Delete(oldImgPath);

                }
                //string newDirPath = Request.MapPath("~/images/courses/" + courseInDb.Title);
                //Directory.Move(oldDirPath, newDirPath);

            }
           
            //courseInDb.ImagePath = course.ImagePath;
            _db.SaveChanges();


            return RedirectToAction("Details", new { id = course.Id});

        }
        
        //[HttpPost]
        public ActionResult Enroll()
        {
            var userId = User.Identity.GetUserId();
            var courseId = (int)Session["Course_Id"];
            var check = _db.Enrollments.Where(e => e.CourseId == courseId && e.StudentId == userId).ToList();
            if(check.Count < 1)
            {
                var enroll = new Enrollment();
                enroll.StudentId = userId;
                enroll.CourseId = courseId;
                enroll.EnrollDate = DateTime.Now;
                _db.Enrollments.Add(enroll);
                ViewBag.Result = "تمت";
            }
            else
            {
                ViewBag.Result = "انت مسجل فيه";

            }
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = courseId });
        }


    }
}