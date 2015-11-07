using System;

namespace Dev204x {
    class Program {
        static void Main() {
            /* declaration stage */
            string firstName;
            string lastName;
            string addressLine1;
            string addressLine2;
            string city;
            string stateOrProvince;
            string zipOrPostal;
            string country;
            DateTime birthDate;

            /* assignment stage as implied (?) by the module 1 pset */
            firstName = "Elvis";
            lastName  = "Presley";
            addressLine1 = "Jailhouse Street, 35";
            addressLine2 = String.Empty;
            city = "Tupelo";
            stateOrProvince = "Mississippi";

            // this could indeed be an integer, but we keep it as
            // a string because some folks out there use alphabetical
            // characters in their zip codes.
            zipOrPostal = "38801";

            country = "U.S.A.";
            birthDate = new DateTime(1935, 1, 8);     
            
            /* outputting to console */
            const int leftColumnWidth = -20;
            const int rightColumnWidth = -10;
            string line = "{0," + leftColumnWidth + "} {1," + rightColumnWidth + "}";
            Console.WriteLine(line, "First Name:", firstName);
            Console.WriteLine(line, "Last Name:", lastName);       
            Console.WriteLine(line, "Address Line 1:", addressLine1);
            Console.WriteLine(line, "Address Line 2:", addressLine2);
            Console.WriteLine(line, "City:", city);
            Console.WriteLine(line, "State:", stateOrProvince);
            Console.WriteLine(line, "ZIP:", zipOrPostal);
            Console.WriteLine(line, "Country:", country);
            Console.WriteLine(line, "Birthdate:", birthDate.ToShortDateString());
            
        }
    }
}
