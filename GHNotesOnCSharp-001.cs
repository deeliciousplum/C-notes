/*	My beginner's notes on working with/exploring C#
		[20201026] exploring accessing as well as reading/writing to a file
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;    // an addon namespace which helps to parse a Json file & to convert its data to a class obj

namespace GHNotesOnCSharp_001
{
    class Program
    {
        static void Main(string[] args)
        {
            // creating a var to hold the location of our test files
            //
            string myFileLoc = @"C:\Users\thede\source\testFiles\";

            // reads a file, places each line as an array element
            //
            List<string> lines = File.ReadAllLines(myFileLoc + "simpleTestFile.txt").ToList();


            // output the number of elements in the lines array
            //
            Console.WriteLine("To grab the number of elements in the array that was created by the List object...");
            Console.WriteLine(lines.Capacity + "\n");

            // output one of the array elements
            //
            Console.WriteLine("Outputting one element of the array that was created...");
            Console.WriteLine(lines[0]);
            Console.ReadLine();             // a placeholder call for waiting for the user to hit enter before continuing

            // foreach loop: loops through an array & temporarily places an element value into line
            //
            Console.WriteLine("A foreach loop to output all of the elements of the array...");
            foreach (string line in lines)
                Console.WriteLine(line);
            Console.ReadLine();

            // for loop which outputs all of the elements of the array
            //
            Console.WriteLine("A for loop which outputs all of the elements of the array that had been created...");
            for (int i = 0; i < lines.Capacity; i++)
            {
                Console.WriteLine(lines[i]);
            }
            Console.ReadLine();
            Console.Clear(); // clears the Console screen

            // --------------------------------------------------------
            //  Arithmetic operators:
            //                          + - * / % ++ --

            // --------------------------------------------------------
            //  Assignment operators:
            //                          = += -= /= %= &= |= ^= >>= <<=

            // --------------------------------------------------------
            //  Comparison operators:
            //                          == != > < >= <=

            // --------------------------------------------------------
            //  Logical operators:
            //                          && || !

            // DeSerializing a json file's values into a C# class object. 
            // And, if changes were made to the values of the objects, then serializing it again.
            // We'll need to add Newtonsoft.Json to the list of using namespaces for the next example
            // In the properties window: rightClick the namespace, in this case it is: GHNotesOnCSharp-001
            //      Manage NuGet Packages > Browse > install Newtonsoft.Json
            //
            // Now, we'll need to make a class for holding our getters & setters
            // In the properties window: rightClick the namespace, in this case it is: GHNotesOnCSharp-001
            //      Add > Class > name it: PetAccount

            // Place these getters & setters into the body of the new class:
            /*
                    class PetAccount
                    {
                        // serialized object from a json file:
                        public string Account { get; set; }
                        public string Character { get; set; }
                        public string Password { get; set; }
                    } 
            */
            /*  Notes on the class objects:
                    It is important to use the appropriate data type for the obj variables.
                    If not, the serializing and deserializing of a Json or of an object will not match the original
            */


            // Necessary variable
            int profileMenu = 0;    // for selecting which object of the element of the array to output from the simpleTestFile.json file

            // Let's deserialize:
            //
            List<string> linesB = File.ReadAllLines(myFileLoc + "simpleTestFile.json").ToList();
            string jsonTemp = linesB[profileMenu];
            PetAccount petAccounts = JsonConvert.DeserializeObject<PetAccount>(jsonTemp);

            Console.WriteLine("Outputting one of the object values from our petAccounts object...");
            Console.WriteLine($"Account: {petAccounts.Account}");
            Console.ReadLine();
            
            // Let's serialize:
            //
            Console.WriteLine("Changing some of the object values from our petAccounts object...");
            petAccounts.Account = "myGoat";
            petAccounts.Character = "kids";
            petAccounts.Password = "888666";
		
            // Serialize the object back to a json and save to simpleTestFile.json
            //
            string petAccountsTemp = JsonConvert.SerializeObject(petAccounts, Formatting.None);
            File.WriteAllText(myFileLoc + "simpleTestFile.json", JsonConvert.SerializeObject(petAccountsTemp));

            Console.WriteLine("The serialized (json formatted) values have now been saved...");
            Console.ReadLine();            
        }
    }
}
