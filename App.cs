using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    class App
    {
        public void Scenario1()
        {
            Student stud1 = new Student(1, "Mihir", Convert.ToDateTime("30/11/1999"), new string[2] { "123456", "567890" });
            Student stud2 = new Student(2, "Ram", Convert.ToDateTime("30/11/1999"), new string[2] { "123456", "567890" });
            Student stud3 = new Student(3, "Shyam", Convert.ToDateTime("30/11/1999"), new string[2] { "123456", "567890" });

            Info info = new Info();
            info.Display(stud1);
            info.Display(stud2);
            info.Display(stud3);
        }
        public void Scenario2()
        {
            int n = 3;
            Student[] students = new Student[n];
            students[0] = new Student(1, "Mihir", Convert.ToDateTime("30/11/1999"), new string[2] { "123456", "567890" });
            students[1] = new Student(2, "Ram", Convert.ToDateTime("30/11/1999"), new string[2] { "123456", "567890" });
            students[2] = new Student(3, "Shyam", Convert.ToDateTime("30/11/1999"), new string[2] { "123456", "567890" });

            Info info = new Info();
            foreach (Student stud in students)
            {
                info.Display(stud);
            }
        }

        public void Scenario3()
        {
            int n = 2;
            Student[] students = new Student[n];
            int id;
            string name;
            string[] phnnum = new string[2];
            DateTime dob;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter your id:");
                id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your Name:");
                name = Console.ReadLine();
                Console.WriteLine("Enter your DOB in DD/MM/YYYY:");
                dob = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter your 2 Phone Numbers:");
                phnnum = (Console.ReadLine()).Split(" ");

                students[i] = new Student(id, name, dob, phnnum);
            }
            Info info = new Info();
            foreach (Student stud in students)
            {
                info.Display(stud);
            }
        }

        public void Scenario4()
        {
            int n = 2;
            var students = new ArrayList();
            int id;
            string name;
            string[] phnnum = new string[2];
            DateTime dob;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter your id:");
                id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your Name:");
                name = Console.ReadLine();
                Console.WriteLine("Enter your DOB in DD/MM/YYYY:");
                dob = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter your 2 Phone Numbers:");
                phnnum = (Console.ReadLine()).Split(" ");

                students.Add(new Student(id, name, dob, phnnum));
            }
            Info info = new Info();
            foreach (Student stud in students)
            {
                info.Display(stud);
            }
        }
        public static void Main(string[] args)
        {
            /*App app = new App();
            //app.Scenario1();
            //app.Scenario2();
            //app.Scenario3();
            DiplomaCourse diplomaCourse = new DiplomaCourse(1, "Mihir", 3, 800, "academic");
            diplomaCourse.CalculateMonthlyFee();*/

            Console.WriteLine("WELCOME");
            Console.WriteLine("1.Admin \n2.Student");
            int choice = Convert.ToInt32(Console.ReadLine());
            PersistentAppEngine persistentAppEngine = new PersistentAppEngine();
            switch (choice)
            {
                case 1:
                    Console.WriteLine("1.Introduce Course \n2.Register a student \n3.List Courses \n4.List Students \n5.List Enrollments");
                    int AdminChoice = Convert.ToInt32(Console.ReadLine());
                    switch (AdminChoice)
                    {
                        case 1:
                            persistentAppEngine.IntroduceCourse();
                            break;
                        case 2:
                            persistentAppEngine.RegisterStudent();
                            break;
                        case 3:
                            persistentAppEngine.CallDisplayCourses();
                            break;
                        case 4:
                            persistentAppEngine.CallDisplayStudent();
                            break;
                        case 5:
                            persistentAppEngine.CallDisplayEnrollments();
                            break;
                        default:
                            Console.WriteLine("Invalid");
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("1.Enroll");
                    int StudChoice = Convert.ToInt32(Console.ReadLine());
                    switch (StudChoice)
                    {
                        case 1:
                            persistentAppEngine.Enroll();
                            break;
                        case 2:
                            
                            break;
                        default:
                            Console.WriteLine("Invalid");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        }
    }
}
