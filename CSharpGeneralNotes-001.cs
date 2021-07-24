// Exploring the Windows Form for designing a GUI/UI

// quick copying of ToolBox items: select the items on the design form, hold down the ctrl btn, and drag. Copies are made of the items selected.

// ToolBox Common Controls:
// checkBox
//
        checkBox1.Checked = false;                      // for (un)checking a checkBox
        string.IsNullOrWhiteSpace(TextBox1.Text)        // conditional check if a TextBox is left blank or with with solely spacebar chars
    
// textBox
//
        textBox1.Text = "";             // for clearing a textBox
      
// copying renaming files
//
        string myProfileOrigLoc = @"C:\origFolder\";
        string myProfileEditsLoc = @"C:\testFolder\";
        File.Copy(myProfileOrigLoc + "origFile.js", myProfileEditsLoc + "testFile.js"); // using System.IO;

// replacing a file
//
        string FileToMoveAndDelete = @"C:\origFolder\thisFile.txt";
        string FileToReplace = @"C:\origFolder\thatFile.txt";
        string BackupOfFileToReplace = @"C:\origFolder\thatFile.txt-bak";
        File.Replace(FileToMoveAndDelete, FileToReplace, BackupOfFileToReplace, false);

// deleting a dir
//
        System.IO.Directory.Delete(@"C:\deleteMe", true)
                
        or
        
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@"C:\deleteMe");
        di.Delete(true);

// copying a dir and its subfolder(s) then saving that to a new location 
//
     public static void Main() {
         string sourceDir = @"d:\thisDir";
         string targetDir = @"e:\thatDir";
         DirectoryInfo srcDir = new DirectoryInfo(sourceDir);
         DirectoryInfo trgtDir = new DirectoryInfo(targetDir);
         CopyAll(srcDir, trgtDir);
         
         Console.ReadLine();
      }
      public static void CopyAll(DirectoryInfo source, DirectoryInfo target) {
         Directory.CreateDirectory(target.FullName);
         foreach (FileInfo fi in source.GetFiles()) {
            fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
         }
         foreach (DirectoryInfo diSourceSubDir in source.GetDirectories()) {
            DirectoryInfo nextTargetSubDir =
            target.CreateSubdirectory(diSourceSubDir.Name);
            CopyAll(diSourceSubDir, nextTargetSubDir);
         }
      }


// Method call examples
//
        ClearChkTextBoxes();                // for calling the method
  
        private void ClearChkTextBoxes()
        {
                textBox1.Text = "";
                checkBox1.Checked = false;
        }

// listBox thingies
//
        listBox1.Items.Clear();
        listBox1.Items.Add("My text to output in a listBox");

// calling methods, for loop, and a recursion
//
        {
                myForLoopMethod();
                myRecursiveMethod(100);
        }
        private static void myForLoopmethod()
        {
                Console.WriteLine("myForLoopMethod");
                for (int i = 0; i <= 100; i++)
                {
                        Console.WriteLine(i);       
                }
        }
        private static void myRecursionMethod(int n)
        {
                Console.WriteLine("myRecursionMethod");
                if n > 100
                        return 1;
                Console.WriteLine(n);
                
                return myRecursionMethod(n+1);
        }

// reading in a file while storing each line in a specified array
//
        if (File.Exists(@"C:\tmp\testFile.txt"))
                string[] lines = File.ReadAllLines(@"C:\tmp\testFile.txt");

                foreach (string line in lines)
                        LB_myTestLB.Items.Add(line);
        }

// working with aarays
// removing an element of an array using .Where()
//
        int[] array = { 1, 3, 4, 5, 4, 2 };
        int item = 4;
 
        array = array.Where(e => e != item).ToArray();
        Console.WriteLine(String.Join(",", array));             // outputs: 1, 3, 5, 2 - removed all element instances of '4'

// removing an element of an array using .FindAll()
//        
        int[] array = { 1, 3, 4, 5, 4, 2 };
        int item = 4;
 
        array = Array.FindAll(array, i => i != item).ToArray();
        Console.WriteLine(String.Join(",", array));            // outputs: 1, 3, 5, 2 - removed all element instances of '4'

// when deleting a file, how to send it to the recycle bin
//

// In the Solution Explorer panel, add to the References tree Microsoft.VisualBasic (right click on References add that)

        using Microsoft.VisualBasic.FileIO;

        if (File.Exists(testConfigDir + delCharProfileName + ".js"))
        {
                FileSystem.DeleteFile(
                        "testFileToBeDeleted.js",
                        UIOption.AllDialogs,
                        RecycleOption.SendToRecycleBin
                );
        }
