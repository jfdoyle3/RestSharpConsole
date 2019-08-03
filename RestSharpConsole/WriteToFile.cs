using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpConsole
{
    public class WriteToFile
    {
        public static void ToFile(string input)
        { 
            String Folder = @"D:\repository\webScraper\dotNET\";
            String FileName = "Output.txt";

            String file = Folder + FileName;
            StreamWriter streamWriter = new StreamWriter(file);

            streamWriter.WriteLine(input);
            streamWriter.Close();
        }
    }
}
