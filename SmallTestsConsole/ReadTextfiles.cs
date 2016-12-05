using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTestsConsole
{
    public class ReadTextfiles
    {
        public static void SimulatedMain()
        {




            WriteLine("Nothing more to do in ReadTextfiles");

        }
        private static void ReadFiles()
        {
            string targetDirectory = @"C:\InFiles";

            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                ProcessFile(fileName);
            }
        }
        public static void ProcessFile(string path)
        {

            using (var reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var fileData = line.Split(';');

                    var comment = fileData[0].Trim();
                    var amountOrdered = fileData[1].Trim();
                    var priorityOrder = fileData[2].Trim();

                    WriteLine(comment);
                    WriteLine(amountOrdered);
                    WriteLine(priorityOrder);



                }
            }
        }






        //Utility
        private static string WriteLine(string text)
        {
            return text;
        }

    }

}
