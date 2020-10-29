/*	My beginner's notes on working with/exploring C$
		[20201026] exploring accessing as well as reading/writing to a file
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;      // an addon namespace which helps to parse a Json file & to convert its data to a class obj
using System.Text.Json;     // using the namespace's Manage NuGet Packages to install this namespace
using IniParser;            // https://github.com/rickyah/ini-parser | https://www.nuget.org/packages/ini-parser/ | https://github.com/rickyah/ini-parser/wiki
using IniParser.Model;

namespace GHNotesOnCSharp_001
{
    class Program
    {
        static void Main(string[] args)
        {
            // creating a var to hold the location of our test files
            //
            string myFileLoc = @"C:\Users\thede\source\repos\GHNotesOnCSharp-001\GHNotesOnCSharp-001\";

            // reads a file, places each line as an array element
            //

            // Before I forget, do make a json file called: myTempFile.json
            /* Now, place these three lines into it:
              
                    {"Account":"myKitchen","Character":"stove","Password":"111111"}
                    {"Account":"myCat","Character":"kittens","Password":"888666"}
                    {"Account":"myFrog","Character":"poliwogs","Password":"555555"}
            */

            List<string> lines = File.ReadAllLines(myFileLoc + "myTempFile.json").ToList();


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


            // ** Works up to here! **
            Console.WriteLine("/n/n** THE CODE WORKS THIS FAR! **");
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

            // Serializing the json file's values into a C# class object
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
            int profileMenu = 1;    // for selecting which object of the element of the array to output from the simpleTestFile.json file

            // Let's deserialize:
            // **Note**: the following will work for a single line of a json file
            //
            //List<string> linesB = File.ReadAllLines(myFileLoc + "myTempFile.json").ToList();
            string jsonTemp = lines[profileMenu];
            PetAccount petAccounts = JsonConvert.DeserializeObject<PetAccount>(jsonTemp);

            Console.WriteLine("Outputting one of the object values from our petAccounts object...");
            Console.WriteLine($"Account: {petAccounts.Account}");
            Console.ReadLine();

            // Let's serialize.
            // First, we'll change the values of one of the ojects:
            Console.WriteLine("Changing some of the object values from our petAccounts object...");
            petAccounts.Account = "myGoat";
            petAccounts.Character = "kids";
            petAccounts.Password = "888666";

            // Since we changed an object's values, we now need to serialize the object

            string petAccountsTemp = JsonConvert.SerializeObject(petAccounts, Formatting.None);
            Console.WriteLine(petAccountsTemp);
            Console.ReadLine();

            lines[profileMenu] = petAccountsTemp;

            Console.WriteLine("A foreach loop to output each of the elements of the altered array...");
            foreach (string line in lines)
                Console.WriteLine(line);
            Console.ReadLine();

            // Now, and to save the newly altered and serialzed json lines we need to merge them...
            //

            string LinesTemp = lines[0];    // this initiates the temp var for the numerous json lines

            for (int i = 1; i < lines.Capacity; i++)
            {
                LinesTemp += ("\n" + lines[i]);
            }
            Console.WriteLine("Now, we'll see the json lines all stacked one on top of the other...");
            Console.WriteLine(LinesTemp);
            Console.ReadLine();

            Console.WriteLine("Now, it will save a new json file called myTempFile2.json");
            File.WriteAllText(myFileLoc + "myTempFile2.json", LinesTemp);
            Console.ReadLine();

		
            //  Working with ini files using ini-parser
            //

            // using an example ini:
            /*  myTestIni.ini:
                    [settings]
                    UserProfileEnabled=true
                    ExitOnCompletion=true

            */
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("myTestIni.ini");

            // string UserProfileEnabled = data["settings"]["UserProfileEnabled"];
            // UseProfileScript contains "true"
            // bool UseProfileEnbld = bool.Parse(UserProfileEnabled);

            data["settings"]["UserProfileEnabled"] = "false";
            parser.WriteFile("myTestIni.ini", data);

        }
    }
}
