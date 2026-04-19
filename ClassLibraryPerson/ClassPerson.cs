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

        public Person() { }

        public Person(string Name, string Surname, int Age, string Phone)
        {
            name = Name;
            surname = Surname;
            age = Age;
            phone = Phone;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Ім'я: {name}");
            Console.WriteLine($"Прізвище: {surname}");
            Console.WriteLine($"Вік: {age}");
            Console.WriteLine($"Телефон: {phone}");
        }
    }
}