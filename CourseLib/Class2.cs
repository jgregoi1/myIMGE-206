﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseLib
{
    public class Course
    {
        public string courseCode;
        public string Description;
        public string TeacherEmail;
        public Schedule schedule;

        public Course(string courseCode, string Description)
        {
            this.courseCode = courseCode;
            this.Description = Description;

        }

    }
}
