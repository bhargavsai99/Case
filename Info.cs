using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    class Info
    {
        public void Display(Student student)
        {
            Console.WriteLine(student.GetID() + ' ' + student.GetName() + ' '
                + student.GetDob() + ' ' + Student.CollegeName + ' ' + string.Join(", ", student.PhoneNumbers));
        }

        public void DisplayCourse(Course course)
        {
            Console.WriteLine(course.id + ' ' + course.name + ' '
                + course.duration + ' ' + course.fees);
        }
    }
}
