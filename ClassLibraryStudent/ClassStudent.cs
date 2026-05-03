using ClassLibraryPerson;
using System;
using System.Collections;

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
            GPA = gpa;
            GroupNumber = groupNumber;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine(" Середній бал (GPA): {0}. Номер групи: {1}", GPA, GroupNumber);
        }

        public class SortBySurname : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return ((obj1 as Student).surname).CompareTo((obj2 as Student).surname);

                throw new NotImplementedException();
            }
        }
        public class SortByAge : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return ((obj1 as Student).age).CompareTo((obj2 as Student).age);

                throw new NotImplementedException();
            }
        }
        public class SortByGPA : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return ((obj1 as Student).grade_point_average).CompareTo((obj2 as Student).grade_point_average);

                throw new NotImplementedException();
            }
        }
        public class SortByGroupNumber : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return ((obj1 as Student).group_number).CompareTo((obj2 as Student).group_number);

                throw new NotImplementedException();
            }
        }        
    }
}