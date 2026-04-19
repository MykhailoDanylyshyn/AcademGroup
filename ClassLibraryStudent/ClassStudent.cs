using System;
using ClassLibraryPerson;

namespace ClassLibraryStudent
{
    public class Student : Person
    {
        protected double grade_point_average;
        protected string group_number;

        public double GPA
        {
            get { return grade_point_average; }
            set { grade_point_average = value; }
        }

        public string GroupNumber
        {
            get { return group_number; }
            set { group_number = value; }
        }

        public Student() : base() { }

        public Student(string name, string surname, int age, string phone,
                            double gpa, string groupNumber)
            : base(name, surname, age, phone)
        {
            grade_point_average = gpa;
            group_number = groupNumber;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Середній бал (GPA): {grade_point_average}");
            Console.WriteLine($"Номер групи: {group_number}");
        }
    }
}