using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Information_Center.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public virtual ApplicationUser Student { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public DateTime EnrollDate { get; set; }
    }
}