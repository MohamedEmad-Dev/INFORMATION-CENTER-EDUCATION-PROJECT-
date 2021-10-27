using Information_Center.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Information_Center.viewModel
{
    public class HomePageViewModel
    {
        public int instructors { get; set; }
        public int student { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}