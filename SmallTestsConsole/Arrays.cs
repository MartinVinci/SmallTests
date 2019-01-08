using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTestsConsole
{
    public class Arrays
    {
        public static void SimulatedMain()
        {
            TryArray();

            WriteLine("Nothing more to do in Arrays");
            ReadLine();
        }

        private static void TryArray()
        {
            string[] fileRows = new string[4];
            fileRows[0] = "STOCKHOLM;63;Batman";
            fileRows[1] = "STOCKHOLM;63;Superman";

            fileRows[2] = "STOCKHOLM;67;Ironman";
            fileRows[3] = "STOCKHOLM;67;Spiderman";

            Dictionary<string, List<string>> fileRowsDict = new Dictionary<string, List<string>>();

            foreach (var fileRow in fileRows)
            {
                var row = fileRow.Split(';');

                var site = row[0].ToString();
                var section = row[1].ToString();

                string siteSection = site + section;

                if (fileRowsDict.ContainsKey(siteSection))
                {
                    List<string> currentList = fileRowsDict[siteSection];
                    currentList.Add(fileRow);

                    fileRowsDict[siteSection] = currentList;
                }
                else
                {
                    fileRowsDict.Add(siteSection, new List<string> { fileRow });
                }
            }

            foreach (var fileRowDict in fileRowsDict)
            {
                string[] arrayOfFileRows = fileRowsDict[fileRowDict.Key].ToArray();
                List<string> testlist = new List<string>();
                string[] s = testlist.ToArray();
            }

        }

        //private static List<string> AddStringToList(List<string> currentValue, string orderRow)
        //{
        //    currentValue.Add(orderRow);

        //    return currentValue.Add(orderRow);
        //}

        //Utility
        private static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
        private static void ReadLine()
        {
            Console.ReadLine();
        }
    }
}
