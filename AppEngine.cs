using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    interface IAppEngine
    {
        public void Introduce(Course course);
        public void Register(Student student);
        public List<Student> ListOfStudents();
        public void Enroll(Student student, Course course);
        public List<Enroll> ListOfEnrollments();
    }

    class InMemoryAppEngine : IAppEngine
    {
        List<Student> Students = new List<Student>();
        List<Enroll> Enrollments = new List<Enroll>();

        public void Introduce(Course course)
        {
            Console.WriteLine(course.id + ' ' + course.name + ' '
                + course.duration + ' ' + course.fees);
        }
        public void Register(Student student)
        {
            string?[] phonenumbers = new string?[2];
            Console.WriteLine("Enter the Id: ");
            student.id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Name: ");
            student.name = Console.ReadLine();
            Console.WriteLine("Enter the Date in dd/mm/yyyy fromat: ");
            student.dob = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter your first phone number:");
            phonenumbers[0] = Console.ReadLine();
            Console.WriteLine("Enter your second phone number:");
            phonenumbers[1] = Console.ReadLine();
            student.PhoneNumbers = phonenumbers;
            //Storing the Students in <students LIST>
            Students.Add(student);
        }

        public List<Student> ListOfStudents()
        {
            return Students;
        }

        public void Enroll(Student student, Course course)
        {
            Enroll enroll = new Enroll(student, course, DateTime.Today);
            Enrollments.Add(enroll);
        }
        public List<Enroll> ListOfEnrollments()
        {
            return Enrollments;
        }
    }
}
