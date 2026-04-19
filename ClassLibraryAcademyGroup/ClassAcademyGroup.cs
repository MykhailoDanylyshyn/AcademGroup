using System;
using System.IO;
using ClassLibraryStudent;

namespace ClassLibraryAcademyGroup
{
    public class Academy_Group
    {
        private Student[] students;
        private int count;

        public int Count => count;

        public Academy_Group()
        {
            students = new Student[0];
            count = 0;
        }

        public void Add(Student student)
        {
            Student[] newArray = new Student[count + 1];

            for (int i = 0; i < count; i++)
                newArray[i] = students[i];

            newArray[count] = student;

            students = newArray;
            count++;
        }
        public void Remove(string surname)
        {
            int index = -1;

            for (int i = 0; i < count; i++)
            {
                if (students[i].Surname == surname)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1) return;

            Student[] newArray = new Student[count - 1];

            for (int i = 0, j = 0; i < count; i++)
            {
                if (i != index)
                {
                    newArray[j] = students[i];
                    j++;
                }
            }

            students = newArray;
            count--;
        }

        public void Edit(string surname, Student newData)
        {
            for (int i = 0; i < count; i++)
            {
                if (students[i].Surname == surname)
                {
                    students[i] = newData;
                    return;
                }
            }
        }

        public void Print()
        {
            if (count == 0)
            {
                Console.WriteLine("Група порожня.");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nСтудент #{i + 1}:");
                students[i].Print();
            }
        }

        public Student Search(string surname)
        {
            for (int i = 0; i < count; i++)
            {
                if (students[i].Surname == surname)
                    return students[i];
            }

            return null;
        }

        public void Save(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < count; i++)
                {
                    writer.WriteLine(
                        $"{students[i].Name};{students[i].Surname};{students[i].Age};{students[i].Phone};{students[i].GPA};{students[i].GroupNumber}"
                    );
                }
            }
        }

        public void Load(string path)
        {
            if (!File.Exists(path)) return;

            string[] lines = File.ReadAllLines(path);

            students = new Student[0];
            count = 0;

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');

                Student student = new Student(
                    parts[0],
                    parts[1],
                    int.Parse(parts[2]),
                    parts[3],
                    double.Parse(parts[4]),
                    parts[5]
                );

                Add(student);
            }
        }
    }
}