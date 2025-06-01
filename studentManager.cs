using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace StudentManagementSystem
{
    class StudentManager
    {
        private List<Student> students = new List<Student>();
        private int idCounter = 1;
        public void menu()
        {
            while (true)
            {
                System.Console.WriteLine("Student Management System");
                System.Console.WriteLine("1. Register new student");
                System.Console.WriteLine("2. Add course & grade");
                System.Console.WriteLine("3. View student report");
                System.Console.WriteLine("4. View all students");
                System.Console.WriteLine("0. Exit");
                System.Console.Write("Choose an option: ");

                int x = int.Parse(Console.ReadLine());

                switch (x)
                {
                    case 1: AddStudent(); break;
                    case 2: AddCourse(); break;
                    case 3: ViewStudents(); break;
                    case 4: ViewAll(); break;
                    case 0: return; 
                    default: System.Console.WriteLine("Invalid input "); break;
                }



            }
        }

        private void AddStudent()
        {
            System.Console.Write("Enter Student name: ");
            string name = Console.ReadLine();
            Student s = new Student { Id = idCounter++, Name = name };
            students.Add(s);
            System.Console.WriteLine("Student Added Successfully...");
        }

        private void AddCourse()
        {
            System.Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());
            Student s = students.Find(x => x.Id == id);
            if (s == null)
            {
                System.Console.WriteLine("This Id is for a student that is not found.");
                return;
            }
            else
            {
                System.Console.Write("Enter course name: ");
                string courseName = Console.ReadLine();
                System.Console.Write("Enter the course grade(1-100): ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out double grade) && grade >= 0 && grade <= 100)
                {
                    s.enrollCourses(courseName, grade);
                    System.Console.WriteLine("Course and grade added perfectly!!!");
                }
                else
                {
                    System.Console.WriteLine("Invalid grade X");
                }
                
            }

        }
        private void ViewStudents()
        {
            System.Console.Write("Enter the student ID:");
            int id = int.Parse(Console.ReadLine());
            Student s = students.Find(x => x.Id == id);
            if (s != null) s.DisplayDetails();
            else System.Console.WriteLine("Invalid student ID x");
        }
        private void ViewAll()
        {
            if (students.Count == 0)
            {
                System.Console.WriteLine("there is no students registered ");
                return;
            }
            else
            {
                foreach (var student in students)
                {
                    student.DisplayDetails();
                    }
            }
        }
    }
}