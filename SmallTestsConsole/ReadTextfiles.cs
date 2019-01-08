using System;
using System.Collections.Generic;
using System.Configuration;
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
            ReadAccountUpsert();

            WriteLine("Nothing more to do in ReadTextfiles");
        }
        private static void ReadAccountUpsert()
        {
            #region PickupAdressUpsert.csv
            //string path = string.Format(@"C:\Salesforce\PickUpAddressUpsert.csv");

            //string fileString = File.ReadAllText(path);

            //var fileRows = fileString.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            //int totalConter = fileRows.Length;


            //int counter = 0;
            //int succeedCounter = 0;
            //int failCounter = 0;

            //foreach (var fileRow in fileRows)
            //{
            //    counter++;

            //    var rowData = fileRow.Split(',');

            //    if (rowData.Length == 12)
            //    {
            //        succeedCounter++;
            //    }
            //    else
            //    {
            //        failCounter++;
            //    }
            //}

            #endregion
            #region AccountUpsert.csv

            string path = string.Format(@"C:\Salesforce\AccountUpsert.csv");

            string fileString = File.ReadAllText(path);

            var fileRows = fileString.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            int totalConter = fileRows.Length;


            int counter = 0;
            int succeedCounter = 0;
            int failCounter = 0;

            List<string> allIds = new List<string>();
            List<string> duplicates = new List<string>();

            foreach (var fileRow in fileRows)
            {
                counter++;

                var rowData = fileRow.Split(',');


                if (allIds.Contains(rowData[0]))
                {
                    duplicates.Add(rowData[0]);
                }

                allIds.Add(rowData[0]);

                //if (rowData.Length == 30)
                //{
                //    succeedCounter++;
                //}
                //else
                //{
                //    failCounter++;
                //}
            }
            #endregion
        }

        private static void SimulateDiffTool()
        {
            string catalogPath = ConfigurationManager.AppSettings["OutPutFolderVarianceTextFile"];

            string time = DateTime.Now.ToString();
            time = time.Replace(":", "-");

            string fileName = string.Format("BatchId_{0}_{1}.csv", 123, time);
            string filePath = string.Format("{0}\\{1}", catalogPath, fileName);

            // This line does "Create if not exists"
            Directory.CreateDirectory(catalogPath);

            var varianceData = new List<string>();
            varianceData.Add("Batman");
            varianceData.Add("Robin");

            using (StreamWriter sw = File.AppendText(filePath))
            {
                foreach (var data in varianceData)
                {
                    sw.WriteLine(string.Format("{0};{1};{2};{3};{4}", "etta", "tv", "tr", "fy", "fe"));

                }
            }
        }
        private static void CreateTextFile5297()
        {
            string timeForKaStart = DateTime.UtcNow.ToString();
            timeForKaStart = timeForKaStart.Replace(":", "-");

            string environment = "KA";
            string path = string.Format(@"C:\Optimering\{0}\{1}.txt", timeForKaStart, environment);

            System.IO.FileInfo file = new System.IO.FileInfo(path);
            file.Directory.Create();

            if (!File.Exists(path))
            { using (StreamWriter sw = File.CreateText(path)) { } }
        }
        private static void SimulateMosit()
        {
            DateTime firstInitialize5297;
            firstInitialize5297 = DateTime.UtcNow;


            double stoptime = (DateTime.UtcNow - firstInitialize5297).TotalMilliseconds;

            string timeForKaStart = DateTime.UtcNow.ToString();
            timeForKaStart = timeForKaStart.Replace(":", "-");

            string environment = "KA";
            string path = string.Format(@"C:\Optimering\{0}\{1}.txt", timeForKaStart, environment);

            System.IO.FileInfo file = new System.IO.FileInfo(path);
            file.Directory.Create();

            if (!File.Exists(path))
            { using (StreamWriter sw = File.CreateText(path)) { } }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("This");
                sw.WriteLine("is Extra");
                sw.WriteLine("Text");
            }


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
                    var fileData = line.Split(',');





                }
            }
        }






        //Utility
        private static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

    }

}
