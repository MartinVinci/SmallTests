using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmallTestsConsole
{
    public class EventViewer
    {
        public static void SimulatedMain()
        {
            ReadFromEventViewer();


            WriteLine("Nothing more to do in EventViewer");
        }

        private static void ReadFromEventViewer()
        {
            try
            {
                EventLog log = new EventLog("Application");

                var entries = log.Entries.Cast<EventLogEntry>()
                    .Where(x => x.TimeWritten > DateTime.Now.AddDays(-6)
                    && x.EntryType == EventLogEntryType.Error                                           
                ).ToList();

                WriteToLocalTextFile(entries);

                var stophere = 3;
            }
            catch (Exception e)
            {

                throw;
            }



        }

        private static void WriteToLocalTextFile(List<EventLogEntry> entries)
        {
            try
            {
                string time = DateTime.Now.ToString();

                time = time.Replace(':', '-');

                Directory.CreateDirectory(@"C:\Nordkvist");

                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(string.Format(@"C:\Nordkvist\EventViewer {0}.txt",time), true))
                {
                    file.WriteLine(string.Format("{0} \n\n"));

                    foreach (var entry in entries)
                    {
                        int messageCount = entry.Message.Length <= 100 ? entry.Message.Length : 100;

                        string message = entry.Message.Substring(0, messageCount);

                        message = message.Replace("\r", " ");
                        message = message.Replace("\n", " ");
                        var text = string.Format("{0}, {1}, {2}, {3}, \n{4}\n \n", entry.EntryType, entry.TimeWritten, entry.Source, entry.InstanceId, message);

                        file.WriteLine(text);
                    }
                }
            }
            catch(Exception e)
            {
                var stophere = 3;
            }

        }





        //Utility
        private static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }



    }
}
