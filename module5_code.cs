/*

1. Create a class file for a Student.
2. Create a class file for a Teacher.
3. Create a class file for a UProgram.
4. Create a class file for a Degree.
5. Create a class file for a Course.
6. Ensure that you encapsulate your member variables in the class files using properties.
7. The Course object should contain an array of Student objects so ensure that you create 
an array inside the Course object to hold Students as well as an array to contain Teacher 
objects as each course may have more than one teacher or TAs.  
8. Create arrays of size 3 for students and the same for teachers.  
9. The UProgram object should be able to contain degrees and the degrees should be able to 
contain courses as well but for the purposes of this assignment, just ensure you have a 
single variable in UProgram to hold a Degree and single variable in Degree to hold a Course.  
10. Add a static class variable to the Student class to track the number of students currently 
enrolled in a school.
11. Increment a student object count every time a Student is created.
12. In the Main() method instantiate three Student objects.
13. In the Main() method instantiate a Course object called Programming with C#.
14. In the Main() method add your three students to this Course object.
15. In the Main() method instantiate at least one Teacher object.
16. In the Main() method add that Teacher object to your Course object
YOU ARE HERE ----> 17. In the Main() method instantiate a Degree object, such as Bachelor.
18. In the Main() method add your Course object to the Degree object.
19. In the Main() method instantiate a UProgram object called Information Technology.
20. In the Main() method add the Degree object to the UProgram object.
21. In the Main() method using Console.WriteLine statements, output the name of the program and the degree it contains
22. In the Main() method using Console.WriteLine statements, output the name of the course in the degree
23. In the Main() method using Console.WriteLine statements, output the count of the number of students in the course.

Your output should look similar to this:
    >>>The Information Technology program contains the Bachelor of Science degree
    >>>
    >>>The Bachelor of Science degree contains the course Programming with C#
    >>>
    >>>The Programming with C# course contains 3 student(s)|

*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dev204x {

    abstract class Person {
        public string   FirstName       { get; set; }
        public string   LastName        { get; set; }
        public DateTime BirthDate       { get; set; }
        public string   AddressLine1    { get; set; }
        public string   AddressLine2    { get; set; }
        public string   City            { get; set; }
        public string   StateProvince   { get; set; }
        public string   ZipPostal       { get; set; }
        public string   Country         { get; set; }
        
        public override string ToString() {
            return "First Name:     " + FirstName                     + '\n' +
                   "Last Name:      " + LastName                      + '\n' +
                   "Birthdate:      " + BirthDate.ToShortDateString() + '\n' +
                   "Address Line 1: " + AddressLine1                  + '\n' +
                   "Address Line 2: " + AddressLine2                  + '\n' +
                   "City:           " + City                          + '\n' +
                   "State/Province: " + StateProvince                 + '\n' +
                   "Zip/Postal:     " + ZipPostal                     + '\n' +
                   "Country:        " + Country;
        }
    }               

    class Student : Person {
        public Student() {
            ++TotalStudentCount;
        }
        public static int TotalStudentCount { get; private set; }
    }

    class Teacher : Person { }

    class UProgram {
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

    class Degree {
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

    class Course {
        public string  Name            { get; set; }
        public int     Credits         { get; set; }
        public int     DurationInWeeks { get; set; }

        private IList<Teacher> _teachers = new List<Teacher>();       
        private IList<Student> _students = new List<Student>();

        public IList<Teacher> Teachers {
            get {
                Teacher[] teacherArray = new Teacher[_teachers.Count];
                _teachers.CopyTo(teacherArray, 0);
                return _teachers;
            }
        }

        public IList<Student> Students {
            get {
                Student[] studentArray = new Student[_students.Count];
                _students.CopyTo(studentArray, 0);
                return _students;
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

    class Program {
            
        static void Main() {
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

            var csCourse = new Course {
                Name            = "Programming with C#",
                Credits         = 20,
                DurationInWeeks = 4
            };

            csCourse.AddStudent(student1);
            csCourse.AddStudent(student2);
            csCourse.AddStudent(student3);

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

            csCourse.AddTeacher(teacher);
                
            var bachelorsDegree = new Degree {
                Name            = "Bachelor of Science",
                CreditsRequired = 120
            };

            bachelorsDegree.AddCourse(csCourse);

            var uProgram = new UProgram {
                Name            = "Information Technology",
                DepartmentHead  = "Leland Stanford"
            };
            uProgram.AddDegree(bachelorsDegree);

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
        }
        
    }
}
