/*
Objectives:

1. Delete the Student array in your Course object that you created in Module 5.

2. Create an ArrayList to replace the array and to hold students, inside the Course object.

3. Modify your code to use the ArrayList collection as the replacement to the array.  
In other words, when you add a Student to the Course object, you will add it to the ArrayList 
and not an array.

4. Create a Stack object inside the Student object, called Grades, to store test scores.

5. Create 3 student objects.

6. Add 5 grades to the the Stack in the each Student object. (this does not have to be inside 
the constructor because you may not have grades for a student when you create a new student.)

7. Add the three Student objects to the Students ArrayList inside the Course object.

8. Using a foreach loop, iterate over the Students in the ArrayList and output their first and 
last names to the console window. (For this exercise you MUST cast the returned object from the 
ArrayList to a Student object.  Also, place each student name on its own line)

9. Create a method inside the Course object called ListStudents() that contains the foreach loop.

10. Call the ListStudents() method from Main().

Grading Criteria:

1. Used an ArrayList of Students, inside the Course object.
(See: line 242)

2. Added a Stack called Grades inside the Student object.
(See: line 162)

3. Added 3 Student objects to this ArrayList using the ArrayList method for adding objects.
(See: line 381)

4. Used a foreach loop to output the first and last name of each Student in the ArrayList.
(See: line 260)

5. Cast the object from the ArrayList to Student, inside the foreach loop, before printing out 
the name information.
(See: line 268)

*/

using System;
using System.Collections;

namespace ConsoleApplication22
{
    // we want to provide for various types of grading, i.e. (A, B...F or 100.0, 90.0...10.0)
    // hence the Grade class. Grade class has been defined abstract so that any of the derived
    // types could implement their grade value validation functions.
    public abstract class Grade
    {        
        // ideally Grade would be declared as Grade<T> to provide for different values used in
        // various grading policies, however since we are in a non-generics field here, we opt
        // to use a traditional "pre-generics" approach.
        public Object Value { get; set; }

        public Grade(Object value) {
            if (value == null) {
                throw new ArgumentNullException("value");
            }
            ValidateGradeValue(value);
            Value = value;
        }

        protected abstract void ValidateGradeValue(Object value);
    }

    public class NumericGrade : Grade
    {
        public NumericGrade(double value)
            : base(value) { }

        protected override void ValidateGradeValue(Object value) {

            if (value == null) {
                throw new ArgumentNullException("value");
            }

            if (value.GetType() != typeof(Double) &&
                value.GetType() != typeof(Int32))
            {
                throw new ArgumentException("value must either be of type Double or Int32");
            }
            
            const double MAX_GRADE_VALUE = 100.0;
            const double MIN_GRADE_VALUE = 0.0;

            double castValue = (double)value;

            if (castValue < MIN_GRADE_VALUE || castValue > MAX_GRADE_VALUE) {
                throw new ArgumentOutOfRangeException("grade value exceeds legal range");
            }
        }
    }

    public abstract class Person {
        // no initializer lists folks, we are in the pre-generics era!
        public Person(string   firstName,
                      string   lastName,
                      DateTime birthDate,
                      string   addressLine1,
                      string   addressLine2,
                      string   city,
                      string   stateProvince,
                      string   zipPostal,
                      string   country)
        {
            if (firstName == null) {
                throw new ArgumentNullException("firstName");
            }
            if (lastName == null) {
                throw new ArgumentNullException("lastName");
            }
            if (addressLine1 == null) {
                throw new ArgumentNullException("addressLine1");
            }
            if (addressLine2 == null) {
                throw new ArgumentNullException("addressLine2");
            }
            if (city == null) {
                throw new ArgumentNullException("city");
            }
            if (stateProvince == null) {
                throw new ArgumentNullException("stateProvince");
            }
            if (zipPostal == null) {
                throw new ArgumentNullException("zipPostal");
            }
            if (country == null) {
                throw new ArgumentNullException("country");
            }
            FirstName     = firstName;
            LastName      = lastName;
            BirthDate     = birthDate;
            AddressLine1  = addressLine1;
            AddressLine2  = addressLine2;
            City          = city;
            StateProvince = stateProvince;
            ZipPostal     = zipPostal;
            Country       = country;
        }

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

    public class Student : Person {
        private Stack _gradeStack = new Stack();

        public Student(string   firstName,
                       string   lastName,
                       DateTime birthDate,
                       string   addressLine1,
                       string   addressLine2,
                       string   city,
                       string   stateProvince,
                       string   zipPostal,
                       string   country)
            : base(firstName, lastName, birthDate, addressLine1, addressLine2, city, stateProvince, zipPostal, country)
        {
            ++TotalStudentCount;
        }

        public static int TotalStudentCount { get; private set; }

        public Grade[] Grades {
            get {
                Grade[] gradeArray = new Grade[_gradeStack.Count];
                _gradeStack.CopyTo(gradeArray, 0);
                return gradeArray;            
            }
        }

        public void PushGrade(Grade grade) {
            if (grade == null) {
                throw new ArgumentNullException("grade");
            }
            _gradeStack.Push(grade);
        }

        public Grade PopGrade() {
            if (_gradeStack.Count == 0) {
                throw new InvalidOperationException("can't pop off of an empty stack");
            }
            // downcasting is acceptable since _gradeStack is guaranteed to only contain
            // objects of class Grade
            return (Grade)_gradeStack.Pop();
        }
    }

    public class Teacher : Person {
        public Teacher(string   firstName,
                       string   lastName,
                       DateTime birthDate,
                       string   addressLine1,
                       string   addressLine2,
                       string   city,
                       string   stateProvince,
                       string   zipPostal,
                       string   country)
            : base(firstName, lastName, birthDate, addressLine1, addressLine2, city, stateProvince, zipPostal, country)
        { }
    }

    public class Course
    {
        // no initializer lists folks, we are in the pre-generics era!
        public Course(string name, int credits, int durationInWeeks) {
            if (name == null) {
                throw new ArgumentNullException("name");
            }
            if (credits < 0) {
                throw new ArgumentOutOfRangeException("credits");
            }
            if (durationInWeeks < 0) {
                throw new ArgumentOutOfRangeException("durationInWeeks");
            }
            Name = name;
            Credits = credits;
            DurationInWeeks = durationInWeeks;
        }
        
        public string  Name            { get; set; }
        public int     Credits         { get; set; }
        public int     DurationInWeeks { get; set; }

        private ArrayList _teachers = new ArrayList();       
        private ArrayList _students = new ArrayList();

        public Teacher[] Teachers {
            get {
                Teacher[] teacherArray = new Teacher[_teachers.Count];
                _teachers.CopyTo(teacherArray, 0);
                return teacherArray;
            }
        }

        public Student[] Students {
            get {
                Student[] studentArray = new Student[_students.Count];
                _students.CopyTo(studentArray, 0);
                return studentArray;
            }
        }

        public void ListStudents() {
            const string OUTPUT_FORMAT_STRING = "Student #{0}\nFirst Name: {1}\nLast Name: {2}";

            int studentCount = 1;
            foreach (Object studentObj in _students) {

                // this downcast is relatively safe because we are guaranteed to
                // only have Student objects in the _students ArrayList.
                Student student = (Student)studentObj; 

                Console.WriteLine(OUTPUT_FORMAT_STRING, studentCount, student.FirstName, student.LastName);
                Console.WriteLine();
                ++studentCount;
            }
        }

        public void AddTeacher(Teacher teacher) {
            if (teacher == null) {
                throw new ArgumentNullException("teacher");
            }
            _teachers.Add(teacher);
        }       

        public void RemoveTeacher(Teacher teacher) {
            if (teacher == null) {
                throw new ArgumentNullException("teacher");
            }
            _teachers.Remove(teacher);
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

        public void RemoveStudent(Student student) {
            if (student == null) {
                throw new ArgumentNullException("teacher");
            }
            _students.Remove(student);
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
        static void Main()
        {
            // we could use named arguments here for clarity, 
            // but in the pre-C#4.0 era they were not available yet.
            Student student1 = new Student (
                "Billy",
                "Jackson",
                new DateTime(1990, 12, 12),
                "5th Avenue",
                String.Empty,
                "Dodge City",
                "Kansas",
                "67801",
                "U.S.A."
            );
            student1.PushGrade( new NumericGrade(90.0) );
            student1.PushGrade( new NumericGrade(70.0) );
            student1.PushGrade( new NumericGrade(95.0) );
            student1.PushGrade( new NumericGrade(65.0) );
            student1.PushGrade( new NumericGrade(80.0) );

            Student student2 = new Student (
                "Eric",
                "Kruger",
                new DateTime(1992, 4, 16),
                "Mastodon Avenue, Seattle, Washington",
                String.Empty,
                "Seattle",
                "Washington",
                "98113",
                "U.S.A."
            );
            student2.PushGrade( new NumericGrade(90.0) );
            student2.PushGrade( new NumericGrade(90.0) );
            student2.PushGrade( new NumericGrade(95.0) );
            student2.PushGrade( new NumericGrade(85.0) );
            student2.PushGrade( new NumericGrade(100.0) );

            Student student3 = new Student (
                "Jeremy",
                "Pokluda",
                new DateTime(1991, 1, 24),
                "Jamestown Boulevard, Jackson, Minnesota",
                String.Empty,
                "Jackson",
                "Minnesota",
                "55003",
                "U.S.A."
            );
            student3.PushGrade( new NumericGrade(100.0) );
            student3.PushGrade( new NumericGrade(100.0) );
            student3.PushGrade( new NumericGrade(95.0) );
            student3.PushGrade( new NumericGrade(65.0) );
            student3.PushGrade( new NumericGrade(90.0) );

            Course csCourse = new Course (
                "Programming with C#",
                20,
                4
            );
            csCourse.AddStudent(student1);
            csCourse.AddStudent(student2);
            csCourse.AddStudent(student3);

            csCourse.ListStudents();
        }
    }
}
