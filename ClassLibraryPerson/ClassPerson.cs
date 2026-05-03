using System;

namespace ClassLibraryPerson
{
    public class Person
    {
        protected string name;
        protected string surname;
        protected int age;
        protected string phone;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public Person() 
        {
            name = " ";
            surname = " ";
            age = 0;
            phone = " ";
        }

        public Person(string Name, string Surname, int Age, string Phone)
        {
            name = Name;
            surname = Surname;
            age = Age;
            phone = Phone;
        }

        public virtual void Print()
        {
            Console.Write("{0} {1} (вік {2}), тел.{3}", Name, Surname, Age, Phone);
        }
    }
}