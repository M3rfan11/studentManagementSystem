namespace StudentManagementSystem
{
    class Course
    {
        public string courseName { get; set; }
        public double courseGrade { get; set; }

        public Course(string name, double grade)
        {
            this.courseName = name;
            this.courseGrade = grade;
        }
    }
}