using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StudentManagementSystem
{
    class Student
    {
        private int id;
        private string name;
        private List<Course> courses = new List<Course>();
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public void enrollCourses(String courseName, double grade)
        {
            courses.Add(new Course(courseName, grade));
        }

        public virtual void DisplayDetails()
        {
            System.Console.WriteLine($"\nStudent ID: {id}");
            System.Console.WriteLine($"\nStudent name: {name}");
            if (courses.Count == 0)
            {
                System.Console.WriteLine("Student is not enrolled in any courses");
            }
            else
            {
                double total = 0;
                System.Console.WriteLine("Courses:");
                foreach (var course in courses)
                {
                    System.Console.WriteLine($" - {course.courseName}: {course.courseGrade}");
                    total += course.courseGrade;
                }
                System.Console.WriteLine($"Average Grade: {(total/courses.Count):F2}");
           }

        }
    }
}