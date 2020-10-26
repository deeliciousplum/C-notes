/*	My beginner's notes on working with/exploring C$
		[20201026] exploring accessing as well as reading/writing to a file
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using Newtonsoft.Json;    // an addon namespace which helps to parse a Json file & to convert its data to a class obj

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
            Console.WriteLine(lines.Capacity + "\n");

            // output one of the array elements
	    //
	    Console.WriteLine(lines[0]);
            Console.ReadLine();             // a placeholder call for waiting for the user to hit enter before continuing
	    
	    // foreach loop: loops through an array & temporarily places an element value into line
	    //
	    foreach (string line in lines)
                Console.WriteLine(line);
            Console.ReadLine();
	    
	    // for loop which outputs all of the elements of the array
	    //
	    for (int i = 0; i < lines.Capacity; i++)
            {
                Console.WriteLine(lines[i]);
            }
            Console.ReadLine();
	    
	    

        }
    }
}
