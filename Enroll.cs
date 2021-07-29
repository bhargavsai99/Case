using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    class Enroll
    {
        private Student Student { get; set; }
        private Course Course { get; set; }
        private DateTime EnrollmentDate { get; set; }

        internal Enroll(Student Student, Course Course, DateTime EnrollmentDate)
        {
            this.Student = Student;
            this.Course = Course;
            this.EnrollmentDate = EnrollmentDate;
        }
    }
}
