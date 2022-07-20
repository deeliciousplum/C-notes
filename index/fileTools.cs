/* C# index...
    1. deleting folders to trashbin
*/



/*  1. *******************************
    *
    * deleteing folders to trash bin
    *
    **********************************
*/
public void DeleteFolder(string _dirName)
{
    /* Using the reference Microsoft.VisualBasic
     *      right click Reference in the Solution Explorer panel
     *      Add References -> enable Microsoft.VisualBasic
     *      
     *      This reference allows for when a dir or a file is deleted, it is sent to the Trash bin
     *      C# does not have a similar feature of utilizing the Trash bin for deleted items
     *
     *      !!!important note:
     *                      using Microsoft.VisualBasic.FileIO; <- this may lead to conflicts with using System.IO;
     *                      both utilize SearchOption 
     *                      maybe, avoid adding Microsoft.VisualBasic.FileIO as a using namespace thingy
     *
     *      ref.: https://www.demo2s.com/csharp/csharp-filesystem-deletedirectory-string-directory-microsoft-visualb-errn.html
     *      ref.: https://www.demo2s.com/csharp/csharp-microsoft-visualbasic-fileio-filesystem.html
    */
    Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(_dirName,
        Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
        Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
}
