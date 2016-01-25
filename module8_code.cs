/*
Objectives:
    1. Create a List<T>, of the proper data type, to replace the ArrayList and to hold students, 
       inside the Course object.


    2. Modify your code to use the List<T> collection as the replacement to the ArrayList.
    
     
    3. Create a Stack<T> object, of the proper data type, inside the Student object, called 
       Grades, to store test scores.


    4. Create 3 student objects.


    5. Add 5 grades to the the Stack<T>  in the each Student object. (this does not have to be inside 
       the constructor because you may not have grades for a student when you create a new student.)


    6. Add the three Student objects to the List<T>  inside the Course object.


    7. Using a foreach loop, iterate over the Students in the List<T> and output their first and 
       last names to the console window. (For this exercise, casting is no longer required.  Also, 
       place each student name on its own line)


    8. Create a method inside the Course object called ListStudents() that contains the foreach loop.


    9. Call the ListStudents() method from Main().
    
    Grading Criteria:

    1. Used a List<T> collection of the proper data type, inside the Course object.
    (See: line 156, line 157)

    2. Added a Stack<T> of the proper data type, called Grades, inside the Student object.
    (See: line 108)

    3. Added 3 Student objects to this List<T> using the List<T> method for adding objects.
    (See: line 288, line 289, line 290)

    4. Used a foreach loop to output the first and last name of each Student in the List<T>.
    (See: line 217)

*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication23 {

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

    // we want to provide for various types of grading, i.e. (A, B...F or 100.0, 90.0...10.0)
    // hence the Grade class. Grade class has been defined abstract so that any of the derived
    // types could implement their grade value validation functions.
    public abstract class Grade<T>
    {        
        public T Value { get; set; }

        public Grade(T value) {
            if (default(T) == null && value == null) {
                throw new ArgumentNullException("value");
            }
            ValidateGradeValue(value);
            Value = value;
        }

        protected abstract void ValidateGradeValue(T value);
    }

    public class NumericGrade : Grade<double>
    {
        public NumericGrade(double value)
            : base(value) { }

        protected override void ValidateGradeValue(double value) {
            
            const double MAX_GRADE_VALUE = 100.0;
            const double MIN_GRADE_VALUE = 0.0;

            if (value < MIN_GRADE_VALUE || value > MAX_GRADE_VALUE) {
                throw new ArgumentOutOfRangeException("grade value exceeds legal range");
            }
        }
    }

    public class Student<TGrade> : Person
    {
        private Stack<TGrade> _gradeStack = new Stack<TGrade>();

        public Student() {
            ++TotalStudentCount;
        }

        public TGrade[] Grades {
            get {
                TGrade[] gradeArray = new TGrade[_gradeStack.Count];
                _gradeStack.CopyTo(gradeArray, 0);
                return gradeArray;            
            }
        }

        public void PushGrade(TGrade grade) {
            if (grade == null) {
                throw new ArgumentNullException("grade");
            }
            _gradeStack.Push(grade);
        }

        public TGrade PopGrade() {
            if (_gradeStack.Count == 0) {
                throw new InvalidOperationException("can't pop off of an empty stack");
            }
            return _gradeStack.Pop();
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

    public class Course<TGrade> {
        public string  Name            { get; set; }
        public int     Credits         { get; set; }
        public int     DurationInWeeks { get; set; }

        private IList<Teacher>          _teachers = new List<Teacher>();       
        private IList<Student<TGrade> > _students = new List<Student<TGrade> >();

        public Teacher[] Teachers {
            get {
                Teacher[] teacherArray = new Teacher[_teachers.Count];
                _teachers.CopyTo(teacherArray, 0);
                return teacherArray;
            }
        }

        public Student<TGrade>[] Students {
            get {
                Student<TGrade>[] studentArray = new Student<TGrade>[_students.Count];
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

        public void AddStudent(Student<TGrade> student) {
            if (student == null) {
                throw new ArgumentNullException("student");
            }
            _students.Add(student);
        }

        public bool RemoveStudent(Student<TGrade> student) {
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

        public void ListStudents() {
            const string OUTPUT_FORMAT_STRING = "Student #{0}\nFirst Name: {1}\nLast Name: {2}";

            int studentCount = 1;
            foreach (Student<TGrade> student in _students) {

                Console.WriteLine(OUTPUT_FORMAT_STRING, studentCount, student.FirstName, student.LastName);
                Console.WriteLine();
                ++studentCount;
            }
        }
    }

    class Program {
        public static void Main() {
            Student<NumericGrade> student1 = new Student<NumericGrade> {
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
            student1.PushGrade( new NumericGrade(90.0) );
            student1.PushGrade( new NumericGrade(70.0) );
            student1.PushGrade( new NumericGrade(95.0) );
            student1.PushGrade( new NumericGrade(65.0) );
            student1.PushGrade( new NumericGrade(80.0) );

            Student<NumericGrade> student2 = new Student<NumericGrade> {
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
            student2.PushGrade( new NumericGrade(90.0) );
            student2.PushGrade( new NumericGrade(90.0) );
            student2.PushGrade( new NumericGrade(95.0) );
            student2.PushGrade( new NumericGrade(85.0) );
            student2.PushGrade( new NumericGrade(100.0) );

            Student<NumericGrade> student3 = new Student<NumericGrade> {
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
            student3.PushGrade( new NumericGrade(100.0) );
            student3.PushGrade( new NumericGrade(100.0) );
            student3.PushGrade( new NumericGrade(95.0) );
            student3.PushGrade( new NumericGrade(65.0) );
            student3.PushGrade( new NumericGrade(90.0) );

            Course<NumericGrade> csCourse = new Course<NumericGrade> {
                Name            = "Programming with C#",
                Credits         = 20,
                DurationInWeeks = 4
            };
            csCourse.AddStudent(student1);
            csCourse.AddStudent(student2);
            csCourse.AddStudent(student3);

            csCourse.ListStudents();
        }
    }
}
