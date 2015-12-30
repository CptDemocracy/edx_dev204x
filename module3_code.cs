/*

    static void GetStudentInformation()
    {
          Console.WriteLine("Enter the student's first name: ");
          string firstName = Console.ReadLine();
          Console.WriteLine("Enter the student's last name");
          string lastName = Console.ReadLine();
           // Code to finish getting the rest of the student data
          .....
    }

    static void PrintStudentDetails(string first, string last, string birthday)
    {
        Console.WriteLine("{0} {1} was born on: {2}", first, last, birthday);
    }

    Objectives:

    1. Using the above partial code sample, complete the method for getting student data.
    (See: line 87)

    2. Create a method to get information for a teacher, a course, a uprogram, and a degree 
       using a similar method as above.
    (See: line 87, line 234, line 321, line 385)

    3. Create methods to print the information to the screen for each object such as 
        static void PrintStudentDetails(...).
    (See: line 193, line 315, line 380, line 465) 

    4. From within Main(), call each of the methods to prompt for input from a user of your application.
    (See: line 477, line 481, line 485, line 489)

    5. Just enter enough information to show you understand how to use methods.  (At least three 
       attributes each).

    6. Assign the values that are input, to the proper variables.

    7. Output the values of each object using the "print" methods that you created.
    (See: line 475, line 479, line 483, line 487)

    8. Create a new method for validating a student's birthday.  You won't write any validation code 
       in this method, but you will throw the NotImplementedException in this method.
    (See: line 181)

    9. Call the method from Main() to verify your exception is thrown.
    (See: line 494)


*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev204x {

    interface ISettableFromInput {
        void SetInformationFromInput();
    }

    interface IDetailsPrintable {
        void PrintDetails();
    }

    abstract class Person : ISettableFromInput, IDetailsPrintable
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

        public void SetInformationFromInput() {

            const string FIRST_NAME_USER_PROMPT       = "Please enter the person's first name: ";
            const string LAST_NAME_USER_PROMPT        = "Please enter the person's last name: ";
            const string BIRTH_DATE_USER_PROMPT       = "Please enter the person's birthdate (mm/dd/yyyy): ";
            const string ADDRESS_LINE_1_USER_PROMPT   = "Please enter the person's address line 1: ";
            const string ADDRESS_LINE_2_USER_PROMPT   = "Please enter the person's address line 2 or leave it empty if not applicable: ";
            const string CITY_USER_PROMPT             = "Please enter the person's city: ";
            const string STATE_PROVINCE_USER_PROMPT   = "Please enter the person's state/province: ";
            const string ZIP_POSTAL_USER_PROMPT       = "Please enter the person's Zip/Postal: ";
            const string COUNTRY_USER_PROMPT          = "Please enter the person's country: ";

            /*
                    If it throws during input gathering, we want to make
                    sure, our Student object will not be corrupted.
                    We could define new variables to save user input to,
                    and then after we were fairly confident that input was
                    good to go, we would set it to object's fields, however...

                    But what if, though highly unlikely, setters throw?
                    That would leave our object half-mutated and with corrupt
                    data. Fortunately, we can pay the price of caching
                    object's fields and simply restore object's values in
                    the catch block if something does go wrong. Hence,
                    no need to define new variables just to collect user data.                    
           */

            string   firstNameFieldCopy       = FirstName;
            string   lastNameFieldCopy        = LastName;
            DateTime birthDateFieldCopy       = BirthDate;
            string   addressLine1FieldCopy    = AddressLine1;
            string   addressLine2FieldCopy    = AddressLine2;
            string   cityFieldCopy            = City;
            string   stateProvinceFieldCopy   = StateProvince;
            string   zipPostalFieldCopy       = ZipPostal;
            string   countryFieldCopy         = Country;

            try
            {

                #region input gathering
                
                Console.WriteLine(FIRST_NAME_USER_PROMPT);
                FirstName = Console.ReadLine();

                Console.WriteLine(LAST_NAME_USER_PROMPT);
                LastName = Console.ReadLine();

                Console.WriteLine(BIRTH_DATE_USER_PROMPT);
                BirthDate = DateTime.Parse( Console.ReadLine() );
            
                Console.WriteLine(ADDRESS_LINE_1_USER_PROMPT);
                AddressLine1 = Console.ReadLine();

                Console.WriteLine(ADDRESS_LINE_2_USER_PROMPT);
                AddressLine2 = Console.ReadLine();

                Console.WriteLine(CITY_USER_PROMPT);
                City = Console.ReadLine();

                Console.WriteLine(STATE_PROVINCE_USER_PROMPT);
                StateProvince = Console.ReadLine();

                Console.WriteLine(ZIP_POSTAL_USER_PROMPT);
                ZipPostal = Console.ReadLine();
            
                Console.WriteLine(COUNTRY_USER_PROMPT);
                Country = Console.ReadLine();

                #endregion                

            }
            catch {
                
                #region restoring fields

                FirstName       = firstNameFieldCopy;
                LastName        = lastNameFieldCopy;
                BirthDate       = birthDateFieldCopy;
                AddressLine1    = addressLine1FieldCopy;
                AddressLine2    = addressLine2FieldCopy;
                City            = cityFieldCopy;
                StateProvince   = stateProvinceFieldCopy;
                ZipPostal       = zipPostalFieldCopy;
                Country         = countryFieldCopy;

                #endregion

                throw;
            }
        }

        internal bool ValidatePersonBirthdate(string birthDateString, out DateTime birthDate) {
            throw new NotImplementedException();
            /*
            if (birthDateString == null) {
                throw new ArgumentNullException("birthDateString");
            }
            return DateTime.TryParse(birthDateString, out birthDate);
            */
        }

        public void PrintDetails() {
            Console.WriteLine( ToString() );
            // could as well be Console.WriteLine( this.ToString() ) or even Console.WriteLine(this)
        }
    }               

    class Student : Person { }

    class Teacher : Person { }

    class UProgram : ISettableFromInput, IDetailsPrintable {
        public string Name            { get; set; }
        public string DepartmentHead  { get; set; }

        private IList<Degree> _degrees = new List<Degree>();
        public  IList<Degree> Degrees {
            get {
                Degree[] retArray = new Degree[_degrees.Count];
                _degrees.CopyTo(retArray, 0);

                return retArray;
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

        public void SetInformationFromInput() {

            const string UPROGRAM_NAME_USER_PROMPT   = "Please enter a UProgram's name: ";
            const string DEPARTMENT_HEAD_USER_PROMPT = "Please enter the department's head first and last name: ";
            const string DEGREE_COUNT_USER_PROMPT    = "Please enter the number of degrees offered by this UProgram: ";

            /*
                    If it throws during input gathering, we want to make
                    sure, our Student object will not be corrupted.
                    We could define new variables to save user input to,
                    and then after we were fairly confident that input was
                    good to go, we would set it to object's fields, however...

                    But what if, though highly unlikely, setters throw?
                    That would leave our object half-mutated and with corrupt
                    data. Fortunately, we can pay the price of caching
                    object's fields and simply restore object's values in
                    the catch block if something does go wrong. Hence,
                    no need to define new variables just to collect user data.                    
           */

            string uProgramNameFieldCopy   = Name;
            string departmentHeadFieldCopy = DepartmentHead;

            // we won't be altering any internals of Degree objects inside the
            // _degrees so all we need is a copy of the collection.

            Degree[] degreesFieldCopy      = new Degree[_degrees.Count];
            _degrees.CopyTo(degreesFieldCopy, 0);

            try
            {

                #region input gathering
                
                Console.WriteLine(UPROGRAM_NAME_USER_PROMPT);
                Name = Console.ReadLine();

                Console.WriteLine(DEPARTMENT_HEAD_USER_PROMPT);
                DepartmentHead = Console.ReadLine();

                Console.WriteLine(DEGREE_COUNT_USER_PROMPT);
                int newDegreesCount = Int32.Parse( Console.ReadLine() );

                IList<Degree> newDegrees = new List<Degree>(newDegreesCount);

                // delegate user input collection to newly initialized
                // Degree objects.
                
                for (int i = 0; i < newDegreesCount; ++i) {
                    newDegrees.Add(new Degree());
                    // newDegrees.Count - 1 is the same as i, however, we want to
                    // make sure we indeed to write to the newly created object
                    newDegrees[newDegrees.Count - 1].SetInformationFromInput();
                }
                _degrees = newDegrees;

                #endregion                

            }
            catch {
                
                #region restoring fields

                Name = uProgramNameFieldCopy;
                DepartmentHead = departmentHeadFieldCopy;

                // Degree objects inside degreesFieldCopy are not altered,
                // so we just reassign the reference to it.
                _degrees = degreesFieldCopy;

                #endregion

                throw;
            }
        }

        public void PrintDetails() {
            Console.WriteLine( ToString() );
            // could as well be Console.WriteLine( this.ToString() ) or even Console.WriteLine(this)
        }
    }

    class Degree : ISettableFromInput, IDetailsPrintable {
        public string Name            { get; set; }
        public int    CreditsRequired { get; set; }

        public override string ToString() {
            return "Name:             " + Name            + '\n' +
                   "Credits required: " + CreditsRequired;
        }

        public void SetInformationFromInput() {

            const string DEGREE_NAME_USER_PROMPT      = "Please enter a degree's name:               ";
            const string CREDITS_REQUIRED_USER_PROMPT = "Please enter the number of credits offered: ";        

            /*
                    If it throws during input gathering, we want to make
                    sure, our Student object will not be corrupted.
                    We could define new variables to save user input to,
                    and then after we were fairly confident that input was
                    good to go, we would set it to object's fields, however...

                    But what if, though highly unlikely, setters throw?
                    That would leave our object half-mutated and with corrupt
                    data. Fortunately, we can pay the price of caching
                    object's fields and simply restore object's values in
                    the catch block if something does go wrong. Hence,
                    no need to define new variables just to collect user data.                    
           */

            string degreeNameFieldCopy      = Name;
            int    creditsRequiredFieldCopy = CreditsRequired;

            try
            {

                #region input gathering
                
                Console.WriteLine(DEGREE_NAME_USER_PROMPT);
                Name = Console.ReadLine();

                Console.WriteLine(CREDITS_REQUIRED_USER_PROMPT);
                CreditsRequired = Int32.Parse( Console.ReadLine() );

                #endregion                

            }
            catch {
                                
                #region restoring fields

                Name            = degreeNameFieldCopy;
                CreditsRequired = creditsRequiredFieldCopy;

                #endregion

                throw;
            }
        }

        public void PrintDetails() {
            Console.WriteLine( ToString() );
            // could as well be Console.WriteLine( this.ToString() ) or even Console.WriteLine(this)
        }
    }

    class Course : ISettableFromInput, IDetailsPrintable {
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

        public void SetInformationFromInput() {

            const string COURSE_NAME_USER_PROMPT       = "Please enter the course name:       ";
            const string CREDITS_USER_PROMPT           = "Please enter the number of credits: ";
            const string DURATION_IN_WEEKS_USER_PROMPT = "Please enter the duration in weeks: ";
            const string TEACHER_INFO_USER_PROMPT      = "Please enter information about course's teacher. ";

            /*
                    If it throws during input gathering, we want to make
                    sure, our Student object will not be corrupted.
                    We could define new variables to save user input to,
                    and then after we were fairly confident that input was
                    good to go, we would set it to object's fields, however...

                    But what if, though highly unlikely, setters throw?
                    That would leave our object half-mutated and with corrupt
                    data. Fortunately, we can pay the price of caching
                    object's fields and simply restore object's values in
                    the catch block if something does go wrong. Hence,
                    no need to define new variables just to collect user data.                    
           */

            string  nameFieldCopy            = Name;
            int     creditsFieldCopy         = Credits;
            int     durationInWeeksFieldCopy = DurationInWeeks;            

            try
            {

                #region input gathering

                Console.WriteLine(COURSE_NAME_USER_PROMPT);
                Name = Console.ReadLine();

                Console.WriteLine(CREDITS_USER_PROMPT);
                Credits = Int32.Parse( Console.ReadLine() );

                Console.WriteLine(DURATION_IN_WEEKS_USER_PROMPT);
                DurationInWeeks = Int32.Parse( Console.ReadLine() );

                Console.WriteLine(TEACHER_INFO_USER_PROMPT);

                // delegate input collection and data restoration on throw
                // for Teacher to Teacher's own method
                Teacher = new Teacher();
                Teacher.SetInformationFromInput();

                #endregion                

            }
            catch {

                #region restoring fields

                Name = nameFieldCopy;
                Credits = creditsFieldCopy;
                DurationInWeeks = durationInWeeksFieldCopy;
                // Teacher restoration is delegated to its own SetInformationFromInput method

                #endregion

                throw;
            }

        }

        public void PrintDetails() {
            Console.WriteLine( ToString() );
            // could as well be Console.WriteLine( this.ToString() ) or even Console.WriteLine(this)
        }
    }

    class Program {

        static void Main() {

            #region object definition
            Person student = new Student();
            student.SetInformationFromInput();
            student.PrintDetails();

            Person teacher = new Teacher();
            teacher.SetInformationFromInput();
            teacher.PrintDetails();

            UProgram uProgram = new UProgram();
            uProgram.SetInformationFromInput();
            uProgram.PrintDetails();

            Course course = new Course();
            course.SetInformationFromInput();
            course.PrintDetails();
            #endregion

            #region call method with NotImplementedException
            DateTime birthDate;
            string birthDateString = "12/01/1900"; // mm/dd/yyyy
            student.ValidatePersonBirthdate(birthDateString, out birthDate);
            #endregion

        }

    }
}
