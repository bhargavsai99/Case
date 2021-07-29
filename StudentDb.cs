using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    class Student
    {
        internal int id { get; set; }
        internal string name { get; set; }
        internal DateTime dob { get; set; }
        internal static string CollegeName = "VCET";

        internal string[] PhoneNumbers = new string[2];

        internal Student()
        {

        }
        internal Student(int id, string name, DateTime dob, string[] PhoneNumbers)
        {
            this.id = id;
            this.name = name;
            this.dob = dob;
            this.PhoneNumbers = PhoneNumbers;
        }

        internal string GetID()
        {
            return id.ToString();
            //Console.WriteLine("ID: {0}",id);
        }

        internal string GetName()
        {
            return name;
            //Console.WriteLine("Name: {0}", name);
        }

        internal string GetDob()
        {
            return dob.ToString("dd/MM/yyyy");
            //Console.WriteLine("Dob: {0}",dob.ToString("dd/MM/yyyy"));
        }
        internal string GetCollege()
        {
            return CollegeName;
            //Console.WriteLine("College: {0}",CollegeName);
        }
    }
    
    class StudentDb
    {
        
    }
}
