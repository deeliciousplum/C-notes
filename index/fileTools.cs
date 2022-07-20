/* C# index...
    1. deleting folders to trashbin
    2. copy folder(s), move copied folder(s) to a new destination - using System.IO
    3. copy file, replace target file w/ copy - using System.IO
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

/*  2. *********************************************************
    *
    * copy folder(s), move copied folder(s) to a new destination
    *
    ************************************************************
*/
public void CopyFolderMoveToDest(string _sourceFolder, string _targetPath)
{
    // using.System.IO
    
    // create the dir where the files and folders will be copied to 
    Directory.CreateDirectory(_targetPath);

    // first:   copy all the files and folders located at the _sourceFolder location
    // next:    at the _targetPath location, create all of the directories that were in the _sourceFoldee location
    // 
    foreach (string dirPath in Directory.GetDirectories(_sourceFolder, "*", SearchOption.AllDirectories))
    {
        Directory.CreateDirectory(dirPath.Replace(_sourceFolder, _targetPath));
    }

    // copy all the files located at the _sourceFolder location
    // place the copied files at the _targetPath location 
    // !!!important note: if a target dir has the same file name, it will be replaced by the copied file
    foreach (string newPath in Directory.GetFiles(_sourceFolder, "*.*", SearchOption.AllDirectories))
    {
        File.Copy(newPath, newPath.Replace(_sourceFolder, _targetPath), true);
    }
}

/*  3. *************************************
    *
    * copy file, replace target file w/ copy
    *
    ****************************************
*/
public void ReplaceFile (string _sourceFile, string _targetfile)
{
    // using.System.IO
    
    /*  true:   the 3rd argument is directing File.Copy to overwrite the destination file
    *           with the copied file if file already exists
    */
    File.Copy(_sourceFile, _targetfile, true);
}
