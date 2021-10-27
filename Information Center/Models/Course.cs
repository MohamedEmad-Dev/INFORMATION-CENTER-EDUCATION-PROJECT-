using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_Center.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Display(Name ="اسم الكورس")]
        public string Title { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public string InstructorId { get; set; }
        public ApplicationUser Instructor { get; set; }
    }
}