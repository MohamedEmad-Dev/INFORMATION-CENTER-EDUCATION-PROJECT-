using Information_Center.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Information_Center.viewModel
{
    public class InstructorStudentRegisteredViewModel
    {
        public string courseName { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}