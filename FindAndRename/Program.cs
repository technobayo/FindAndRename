using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FindAndRename
{

    /*
     * In summary, I want to access the content of a directory
     * I want to rename the files    
     * 
     */    
    class MainClass
    {
        public static void Main(string[] args)
        {
            SubClass sb = new SubClass();
            //sb.GetDetails();
            sb.DoRename();
        }

    }

    public class SubClass
    {
        private string GetDirectory()
        {
            //First, get the name of the file path
            Console.WriteLine("Enter the fullpath of where the files are stored and press enter");
            var folderName = Console.ReadLine();
            return folderName;
        }

        public void DoRename()
        {
            string sourcePath = GetDirectory();  //"/Users/GETTO/Desktop/Test/Animals";

            try
            {
                Console.WriteLine("Enter the filter i.e. a phrase contained with the file to be renamed");
                string filterName = Console.ReadLine();

                Console.WriteLine("What do you want to rename the files?");
                string newFilename = Console.ReadLine();

                //Get list of files (full paths) that contain the string 'fam'. Note the use of Linq & Lambda
                IEnumerable<string> strFileWithPaths = Directory.EnumerateFiles(sourcePath).Where(s => s.Contains(filterName));

                if (strFileWithPaths.Any()) 
                {
                    int i = 0;  //counter for use in file rename
                    foreach (var files in strFileWithPaths)
                    {
                        i++;
                        string f = Path.GetFileName(files); //get only filename
                        string ext = Path.GetExtension(files);
                        string destFile = Path.Combine(sourcePath, newFilename + i + ext);    //create path for the files as new names
                        File.Move(files, destFile);
                        Console.WriteLine("File {0} was renamed to {1}", f, Path.GetFileName(destFile));
                    }
                }
                else
                {
                    Console.WriteLine("No matching name");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
            }
        }
    }
}
