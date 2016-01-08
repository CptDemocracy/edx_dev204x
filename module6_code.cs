/*
Objectives:

    1. Create a Person base class with common attributes for a person.
    (See: line 36)

    2. Make your Student and Teacher classes inherit from the Person base class
    (See: line 49, line 62)
    
    3. Modify your Student and Teacher classes so that they inherit the common attributes from Person
    (See: line 49, line 62)
    
    4. Modify your Student and Teacher classes so they include characteristics specific to their type.  
    For example, a Teacher object might have a GradeTest() method where a student might have a 
    TakeTest() method.
    (See: line 57, line 63)
    
    5. Run the same code in Program.cs from Module 5 to create instances of your classes so that you 
    can setup a single course that is part of a program and a degree path. Be sure to include at 
    least one Teacher and an array of Students.

    
    6. Ensure the Console.WriteLine statements you included in Homework 5, still output the correct 
    information.
    
    
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication21
{
    public abstract class Person
    {
        public string   FirstName       { get; set; }
        public string   LastName        { get; set; }
        public DateTime BirthDate       { get; set; }
        public string   AddressLine1    { get; set; }
        public string   AddressLine2    { get; set; }
        public string   City            { get; set; }
        public string   StateProvince   { get; set; }
        public string   ZipPostal       { get; set; }
        public string   Country         { get; set; }
    }     

    public class Student : Person
    {
        public Student() {
            ++TotalStudentCount;
        }

        public static int TotalStudentCount { get; private set; }

        public void TakeTest() {
            throw new NotImplementedException("implementation of current method is beyond the scope of given problem");
        }
    }

    public class Teacher : Person {
        public void GradeTest() {
            throw new NotImplementedException("implementation of current method is beyond the scope of given problem");
        }
    }

    public class UProgram {
        public string Name            { get; set; }
        public string DepartmentHead  { get; set; }

        private IList<Degree> _degrees = new List<Degree>();
        
        public IList<Degree> Degrees {
            get {
                Degree[] degreeArray = new Degree[_degrees.Count];
                _degrees.CopyTo(degreeArray, 0);
                return degreeArray;    
            }
        }

        public void AddDegree(Degree degree) {
            if (degree == null) {
                throw new ArgumentNullException("degree");
            }
            _degrees.Add(degree);
        }

        public bool RemoveDegree(Degree degree) {
            if (degree == null) {
                throw new ArgumentNullException("degree");
            }
            return _degrees.Remove(degree);
        }

        public void RemoveDegreeAt(int index) {
            if (index < 0 || index >= _degrees.Count) {
                throw new IndexOutOfRangeException("index");
            }
            _degrees.RemoveAt(index);
        }        
    }

    public class Degree {
        public string Name            { get; set; }
        public int    CreditsRequired { get; set; }

        private IList<Course> _courses = new List<Course>();
        
        public IList<Course> Courses {
            get {
                Course[] courseArray = new Course[_courses.Count];
                _courses.CopyTo(courseArray, 0);
                return courseArray;
            }
        }

        public void AddCourse(Course course) {
            if (course == null) {
                throw new ArgumentNullException("course");
            }
            _courses.Add(course);
        }

        public bool RemoveCourse(Course course) {
            if (course == null) {
                throw new ArgumentNullException("course");
            }
            return _courses.Remove(course);
        }

        public void RemoveCourseAt(int index) {
            if (index < 0 || index >= _courses.Count) {
                throw new IndexOutOfRangeException("index");
            }
            _courses.RemoveAt(index);
        }        
    }

    public class Course {
        public string  Name            { get; set; }
        public int     Credits         { get; set; }
        public int     DurationInWeeks { get; set; }

        private IList<Teacher> _teachers = new List<Teacher>();       
        private IList<Student> _students = new List<Student>();

        public IList<Teacher> Teachers {
            get {
                Teacher[] teacherArray = new Teacher[_teachers.Count];
                _teachers.CopyTo(teacherArray, 0);
                return teacherArray;
            }
        }

        public IList<Student> Students {
            get {
                Student[] studentArray = new Student[_students.Count];
                _students.CopyTo(studentArray, 0);
                return studentArray;
            }
        }

        public void AddTeacher(Teacher teacher) {
            if (teacher == null) {
                throw new ArgumentNullException("teacher");
            }
            _teachers.Add(teacher);
        }       

        public bool RemoveTeacher(Teacher teacher) {
            if (teacher == null) {
                throw new ArgumentNullException("teacher");
            }
            return _teachers.Remove(teacher);
        }

        public void RemoveTeacherAt(int index) {
            if (index < 0 || index >= _teachers.Count) {
                throw new IndexOutOfRangeException("index");
            }
            _teachers.RemoveAt(index);
        }

        public void AddStudent(Student student) {
            if (student == null) {
                throw new ArgumentNullException("student");
            }
            _students.Add(student);
        }

        public bool RemoveStudent(Student student) {
            if (student == null) {
                throw new ArgumentNullException("teacher");
            }
            return _students.Remove(student);
        }

        public void RemoveStudentAt(int index) {
            if (index < 0 || index >= _students.Count) {
                throw new IndexOutOfRangeException("index");
            }
            _students.RemoveAt(index);
        }
    }

    class Program
    {        
        static void Main() {

#region Instantiating 3 Student objects

            var student1 = new Student {
                FirstName       = "Billy",
                LastName        = "Jackson",
                BirthDate       = new DateTime(1990, 12, 12),
                AddressLine1    = "5th Avenue",
                AddressLine2    = String.Empty,
                City            = "Dodge City",
                StateProvince   = "Kansas",
                ZipPostal       = "67801",
                Country         = "U.S.A."
            };

            var student2 = new Student {
                FirstName       = "Eric",
                LastName        = "Kruger",
                BirthDate       = new DateTime(1992, 4, 16),
                AddressLine1    = "Mastodon Avenue, Seattle, Washington",
                AddressLine2    = String.Empty,
                City            = "Seattle",
                StateProvince   = "Washington",
                ZipPostal       = "98113",
                Country         = "U.S.A."
            };

            var student3 = new Student {
                FirstName       = "Jeremy",
                LastName        = "Pokluda",
                BirthDate       = new DateTime(1991, 1, 24),
                AddressLine1    = "Jamestown Boulevard, Jackson, Minnesota",
                AddressLine2    = String.Empty,
                City            = "Jackson",
                StateProvince   = "Minnesota",
                ZipPostal       = "55003",
                Country         = "U.S.A."
            };

#endregion

#region Instantiating a Course object

            var csCourse = new Course {
                Name            = "Programming with C#",
                Credits         = 20,
                DurationInWeeks = 4
            };

#endregion

#region Adding 3 Students to the Course object

            csCourse.AddStudent(student1);
            csCourse.AddStudent(student2);
            csCourse.AddStudent(student3);

#endregion

#region Instantiating a Teacher object

            var teacher = new Teacher {
                FirstName       = "Jimmy",
                LastName        = "Johnes",
                BirthDate       = new DateTime(1970, 1, 7),
                AddressLine1    = "38th Street, Montgomery, Alabama",
                AddressLine2    = String.Empty,
                City            = "Montgomery",
                StateProvince   = "Alabama",
                ZipPostal       = "36109",
                Country         = "U.S.A."
            };

#endregion

#region Adding the Teacher object to the Course object

            csCourse.AddTeacher(teacher);

#endregion

#region Instantiating a Degree object

            var bachelorsDegree = new Degree {
                Name            = "Bachelor of Science",
                CreditsRequired = 120
            };

#endregion

#region Adding the Course object to the Degree object

            bachelorsDegree.AddCourse(csCourse);

#endregion

#region Instantiating a UProgram object called Information Technology

            var uProgram = new UProgram {
                Name            = "Information Technology",
                DepartmentHead  = "Leland Stanford"
            };

#endregion

#region Adding the Degree object to the UProgram object

            uProgram.AddDegree(bachelorsDegree);

#endregion

#region Output
            string uProgramOutputFormatString = "The {0} contains the {1} degree";
            string degreeOutputFormatString   = "The {0} degree contains the course {1}";
            string courseOutputFormatString   = "The {0} contains {1} student{2}";

            foreach (var degree in uProgram.Degrees) {
                Console.WriteLine(uProgramOutputFormatString, uProgram.Name, degree.Name);
                Console.WriteLine();
                foreach (var course in degree.Courses) {
                    Console.WriteLine(degreeOutputFormatString, degree.Name, course.Name);
                    Console.WriteLine();

                    int studentCount = course.Students.Count;
                    Console.WriteLine(courseOutputFormatString, course.Name, studentCount, (studentCount > 1) ? "s" : String.Empty);
                    Console.WriteLine();
                }
            }
#endregion
        }        
    }
}
