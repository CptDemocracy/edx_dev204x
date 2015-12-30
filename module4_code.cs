/*
For this assignment, complete the following tasks. For the structs, just include member variables and 
a constructor.  Do not create properties at this time. Include all the variables that you have created 
up to this point in time.

    1. Create a struct to represent a student.
    (See: line 43)

    2. Create a struct to represent a teacher.
    (See: line 67)

    3. Create a struct to represent a program.
    (See: line 91)

    4. Create a struct to represent a course.
    (See: line 142)

    5. Create an array to hold 5 student structs.
    (See: line 225)

    6. Assign values to the fields in at least one of the student structs in the array.
    (See: line 161, 173, 185, 197, 209)

    7. Using a series of Console.WriteLine() statements, output the values for the student struct that 
       you assigned in the previous step.
    (See: line 239)


*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev204x
{
    // in real-life scenario we would declare Student and Teacher
    // as classes instead of structs and make them inherit from a 
    // class Person

    public struct Student {
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

    public struct Teacher {
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

    public struct Program {
        public string Name            { get; set; }
        public string DepartmentHead  { get; set; }

        private IList<Degree> _degrees;
        public  IList<Degree> Degrees {
            get {
                if (_degrees != null) {
                    Degree[] retArray = new Degree[_degrees.Count];
                    _degrees.CopyTo(retArray, 0);

                    return retArray;
                }
                return null;
            }
            set {
                if (value == null) {
                    throw new ArgumentNullException("value");
                }
                _degrees = value;
            }
        }

        public override string ToString() {
            var buffer = new StringBuilder();
            buffer.Append("Name: ");
            buffer.AppendLine(Name);
            buffer.Append("Department Head: ");
            buffer.AppendLine(DepartmentHead);
            buffer.AppendLine("Degrees: ");
            foreach (Degree degree in _degrees) {
                buffer.AppendLine();               
                buffer.AppendLine(degree.ToString());
                buffer.AppendLine();
            }
            return buffer.ToString();
        }
    }

    public struct Degree {

        public string Name            { get; set; }
        public int    CreditsRequired { get; set; }

        public override string ToString() {
            return "Name:             " + Name + '\n' +
                   "Credits required: " + CreditsRequired;
        }

    }

    public struct Course {
        public string  Name            { get; set; }
        public int     Credits         { get; set; }
        public int     DurationInWeeks { get; set; }
        public Teacher Teacher         { get; set; }

        public override string ToString() {
            return "Name:               " + Name            + '\n' +
                   "Credits:            " + Credits         + '\n' +
                   "Duration in weeks:  " + DurationInWeeks + '\n' +
                   "Teacher:            " + Teacher;
        }
    }

    class App
    {     
        static void Main() {
            #region defining Student objects

            var student1 = new Student {
                FirstName       = "Jimmy",
                LastName        = "Johnes",
                BirthDate       = new DateTime(1990, 10, 12),
                AddressLine1    = "38th Street, Montgomery, Alabama",
                AddressLine2    = String.Empty,
                City            = "Montgomery",
                StateProvince   = "Alabama",
                ZipPostal       = "36109",
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

            var student4 = new Student {
                FirstName       = "William",
                LastName        = "Morrison",
                BirthDate       = new DateTime(1989, 3, 7),
                AddressLine1    = "5th Avenue, New York, New York State",
                AddressLine2    = String.Empty,
                City            = "New York",
                StateProvince   = "New York State",
                ZipPostal       = "10005",
                Country         = "U.S.A."
            };

            var student5 = new Student {
                FirstName       = "Carl",
                LastName        = "Steiner",
                BirthDate       = new DateTime(1993, 5, 5),
                AddressLine1    = "Greenwich Boulevard, New York, New York State",
                AddressLine2    = String.Empty,
                City            = "New York",
                StateProvince   = "New York State",
                ZipPostal       = "10003",
                Country         = "U.S.A."
            };

            #endregion

            #region defining an array of Student objects

            var studentArray = new Student[] {
                student1,
                student2,
                student3,
                student4,
                student5
            };

            #endregion

            #region outputting Student objects from the array to console

            int count = 1;
            foreach (var student in studentArray) {
                Console.WriteLine("Student #{0}", count);
                Console.WriteLine(student);
                Console.WriteLine();
                ++count;
            }
            
            #endregion
        }
    }
}
