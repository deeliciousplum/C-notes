// Exploring the Windows Form for designing a GUI/UI

// ToolBox Common Controls:
// checkBox
//
        checkBox1.Checked = false;    //for (un)checking a checkBox
    
// textBox
//
        textBox1.Text = "";             // for clearing a textBox
      

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
        listBox1.Items.Add("My text to output in a listBox")

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
