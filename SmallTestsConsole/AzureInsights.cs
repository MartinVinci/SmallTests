using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmallTestsConsole
{
    public class AzureInsights
    {
        public static void SimulatedMain()
        {
            BasicExample();




            WriteLine("Nothing more to do in AzureInsights");

        }
        private static TelemetryClient telemetry;

        private static void BasicExample()
        {
            TelemetryConfiguration.Active.InstrumentationKey = "b11a12a9-9eda-4da0-9a8a-0ab111834d3c";
            //while (true)
            //{

            var dtStart = DateTime.Now;

            if (telemetry == null)
            {
                telemetry = new TelemetryClient();
            }

            Random rand = new Random();
            int waitingSeconds = rand.Next(2000, 5000);
            Thread.Sleep(waitingSeconds);

            var timeSpan = DateTime.Now - dtStart;

            // Kolla vilken användare som skickade ordern
            var properties = new Dictionary<string, string>();
            properties.Add("Time Now", DateTime.UtcNow.ToString());

            var metrics = new Dictionary<string, double>();
            metrics.Add("BatmanSeeker", timeSpan.TotalSeconds);

            telemetry.TrackEvent("Batman header", properties, metrics);

            telemetry.Flush();

            //Thread.Sleep(10000);

            //}
        }


        //Utility
        private static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
