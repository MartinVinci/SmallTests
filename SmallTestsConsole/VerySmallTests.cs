using SmallTestsConsole.Object;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmallTestsConsole
{
    public class VerySmallTests
    {
        public VerySmallTests()
        {

        }
        public static void SimulatedMain()
        {
            //GetDateTimes("20170818", "0400");
            //var worker = new VerySmallTests();
            //var result = worker.TryTask();
            //List<bool> SomeResult = TryParallelForeach();

            TryGetClassName();

            WriteLine("Nothing more to do in VerySmallTests");
            ReadLine();
        }

        private static string TryGetClassName()
        {
            try
            {
                int zero = 0;
                int error = 4 / zero;
                return "some try value";
            }
            catch (Exception e)
            {
                string stringToLog = string.Format("Exception in method: '{0}'. Exception message {1}", GetClassName(), e.Message.ToString());

                return "some catch value";
            }
        }

        private static string GetClassName()
        {
            return new StackTrace().GetFrame(1).GetMethod().Name;
        }

        private static string GetClassAndMethod()
        {
            var stackTrace = new StackTrace();
            string className = stackTrace.GetFrame(2).GetMethod().ReflectedType.FullName;
            string methodName = stackTrace.GetFrame(2).GetMethod().Name;
            methodName = methodName.Replace(".ctor", "ctor");
            return "Class: " + className + " Method: " + methodName;
        }

        private static void TestSeparatorSplit()
        {
            //var propertyCompareReference = "PhoneNumberType|Number";
            var propertyCompareReference = "CustomerId";

            List<string> identifiers;

            identifiers = propertyCompareReference.Split('|').ToList();

            //if (propertyCompareReference.Contains("|"))
            //{
            //    identifiers = propertyCompareReference.Split('|').ToList();
            //}
            //else
            //{
            //    identifiers = 
            // }


        }

        private static void TestConvertCommaAndPeriod()
        {
            var testComma = ConvertStringToNullableDecimal("3.25");
            var testPeriod = ConvertStringToNullableDecimal("3,25");
            var testNothing = ConvertStringToNullableDecimal("325");
            var testEmptyString = ConvertStringToNullableDecimal("");

        }

        private static decimal? ConvertStringToNullableDecimal(string theString)
        {
            // When BFUS had an update, for example PRICENOVAT had NUMBER(19,5) as data type. However, in MDS this column
            // was set to nvarchar(50). Thats the reason we need to convert from string
            try
            {
                if (theString != null && theString != "")
                {
                    string correctDecimalChar = ConfigurationManager.AppSettings["CorrectDecimalChar"];

                    if (theString.Contains(".") || theString.Contains(","))
                    {
                        if (theString.Contains(".") && correctDecimalChar == ",")
                        {
                            theString = theString.Replace('.', ',');
                        }
                        else if(theString.Contains(",") && correctDecimalChar == ".")
                        {
                            theString = theString.Replace(',', '.');
                        }
                    }

                    decimal stringAsDecimal = Convert.ToDecimal(theString);

                    decimal? returnValue = (decimal?)stringAsDecimal;

                    return returnValue;
                }

                return null;
            }
            catch (Exception e)
            {
                // If database has string in column that should have decimal values, we return a bogus value
                return 99999;
            }
        }




        private static string[] EpiServerErrorsLog()
        {
            var files = Directory.GetFiles(@"C:\Nordkvist\Website.Web").ToList();

            files = (from hits in files
                     where hits.Contains("EPiServerErrors.log")
                     orderby hits descending
                     select hits).ToList();

            var returnList = new List<string>();

            // Add the errorlog last in list, which will be the one from today since it does not have any date yet.
            returnList.Add(files[files.Count - 1]);

            int daysBack = GetDaysBack();

            returnList.AddRange(files.Take(daysBack));

            return returnList.ToArray();
        }
        private static int GetDaysBack()
        {
            var today = DateTime.Now;

            if (today.DayOfWeek == DayOfWeek.Monday)
            {
                return 3;
            }
            else
            {
                return 1;
            }
        }
        private static void WriteToLocalTextFile()
        {
            try
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Nordkvist\PositionLog.txt", true))
                {
                    file.WriteLine("hej");
                }
            }
            catch { }
        }

        static int customersIdsCounter = 0;

        private static List<bool> TryParallelForeach()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            WriteLine("Starting the Test");
            int threadsInParallelCust = 3;

            ConcurrentBag<long> customerIdsBag = new ConcurrentBag<long>();

            for (int i = 9; i >= 1; i--)
            {
                customerIdsBag.Add(i);
            }

            List<bool> returnList = new List<bool>();

            Parallel.ForEach(customerIdsBag, new ParallelOptions { MaxDegreeOfParallelism = threadsInParallelCust }, theId =>
            {
                returnList.Add(DoSomethingThatTakesTime(theId));
            });

            //foreach (var theId in customerIdsBag)
            //{
            //    returnList.Add(DoSomethingThatTakesTime(theId));
            //}

            while (customersIdsCounter < customerIdsBag.Count())
            {
                Thread.Sleep(1000);
            }

            var stophere = 3;

            WriteLine("Ending the Test");

            return returnList;
        }

        private static bool DoSomethingThatTakesTime(long counter)
        {
            WriteLine(counter.ToString());

            Thread.Sleep(5000);

            customersIdsCounter++;
            return true;
        }





        private static void TryTryCatch()
        {
            // Add this lines in SimulatedMain()
            WriteLine("Start");
            try
            {
                TryTryCatch();

            }
            catch (Exception)
            {
                WriteLine("Continue from catch");
            }



            var simulateTimerStop = "_timer.Stop()";

            bool doFetchDeviations = true;

            if (doFetchDeviations)
            {
                DateTime fetchDeviationsStartTime = DateTime.Now;
                string randomId = "123";

                string fetchDevStart = ("FetchDeviations with random id " + randomId + ", Start: " + fetchDeviationsStartTime);
                //deviationLogger.WriteLog(LogLevel.DEBUG, fetchDevStart);

                //// Simulate Error here
                //var zeroOne = 0;
                //var errorOne = 1 / zeroOne;

                try
                {
                    // Simulate Error here
                    var zeroTwo = 0;
                    var errorTwo = 1 / zeroTwo;

                }
                catch (Exception ex)
                {
                    // Simulate Error here
                    var zeroThree = 0;
                    var errorThree = 1 / zeroThree;
                }

                // Simulate Error here
                var zeroFour = 0;
                var errorFour = 1 / zeroFour;

                string fetchDevStop = "FetchDeviations with random id ";
                //deviationLogger.WriteLog(LogLevel.DEBUG, fetchDevStop);
            }

            // Do we come here?
            var someTextA = "_timer.Interval = _timeInterval";
            var someTextB = "_timer.Start()";
        }

        private static void TryLoopCounter()
        {
            long counter = 0;
            //for (long i = 0; i < 9223372036854775807; i++)
            for (long i = 0; i < 1000000000; i++)
            {
                int t = 3;
                int f = 3;
                if (t == f)
                {
                    counter++;

                }
            }


            var stophere = counter;

        }
        private static void SubStringDate()
        {
            string dbDate = "2017-08-04 00:00:00.000";

            string date = dbDate.Substring(0, 10);
        }
        private static void TryStringEmpty()
        {
            var signatur = "";
            var signatur2 = " ";

            if (signatur != string.Empty)
            {
            }

            if (signatur2 != string.Empty)
            {
            }

        }
        private static void SortListOfString()
        {
            var list = new List<string>();

            list.Add("2");
            list.Add("1");
            list.Add("4");
            list.Add("3");

            list = (from hits in list
                    orderby hits ascending
                    select hits).ToList();

        }
        private static void ToScreen(string message)
        {
            Console.WriteLine(message);
        }



        private void StringToInt()
        {
            string four = "4";

            int test2 = Convert.ToInt32(four);
        }
        private void PrintCacheName()
        {

            string dateString = ((String)(DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToLongTimeString())).Replace(" ", "").Replace(":", "");

            var hej = _isFirstCacheRound;
            //string filename = $@"{path}Mosit-cache-{dateString}.txt";
            //string filenameJson = $@"{path}Mosit-json-{dateString}.txt";

        }
        private Boolean _isFirstCacheRound;

        private static void CastErrorOne()
        {
            try
            {
                CastErrorTwo();
            }
            catch (Exception ex)
            {

            }
        }
        private static void CastErrorTwo()
        {
            string dbWorkOrder = null;
            if (dbWorkOrder == null)
            {
                try
                {
                    throw new Exception("Could not find workorder in database with id: ");

                }
                catch (Exception ex)
                {
                    //_errorHandler.HandleError(ex);
                }

            }
        }
        private static void MakePercent()
        {

            double totalAmountIdsInRandom = 10789;
            double totalAmountIdsInLatest = 124;
            double totalErrorsInRandom = 53;
            double totalErrorsInLatest = 8;

            double percentErrorsInRandom = (totalErrorsInRandom / totalAmountIdsInRandom) * 100;
            double percentErrorsInLatest = (totalErrorsInLatest / totalAmountIdsInLatest) * 100;

            percentErrorsInRandom = Math.Round(percentErrorsInRandom, 2);
            percentErrorsInLatest = Math.Round(percentErrorsInLatest, 2);

        }
        private static void ForLoopBackWardsOld()
        {
            List<Person> deletedWorkOrdersFromMonitoring = new List<Person>();

            deletedWorkOrdersFromMonitoring.Add(new Person("Martin", 34, "000"));
            deletedWorkOrdersFromMonitoring.Add(new Person("Anna", 34, "000"));




            for (int i = deletedWorkOrdersFromMonitoring.Count() - 1; i >= 0; i--)
            {
                deletedWorkOrdersFromMonitoring.RemoveAt(i);
            }



        }
        private static void AddNullToList()
        {
            var personsList = new List<Person>();

            var person1 = new Person("Martin", 34, "000");
            personsList.Add(person1);

            Person person2 = null;

            var person3 = new Person("Kalle", 23, "000");


            personsList.Add(person2);
            personsList.Add(person3);

        }


        private static void ProbablyTimer()
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(5);

            var timer = new System.Threading.Timer((e) =>
            {
                //MyMethod();
            }, null, startTimeSpan, periodTimeSpan);
        }

        private string TryTask()
        {
            Task t = Task.Run(() =>
            {
                DoStuff();
            });

            return "Batman";
        }

        private void DoStuff()
        {
            Thread.Sleep(2000);
        }


        private static List<DateTime> GetDateTimes(string endDate, string timeOnDay)
        {
            var lastRun = MakeDateTime(endDate, timeOnDay);
            var returnList = new List<DateTime>();
            returnList.Add(lastRun);

            var timeNow = DateTime.UtcNow;


            DateTime possibleRun;
            while (true)
            {
                lastRun = lastRun.AddDays(-1);

                if (lastRun > timeNow)
                {
                    returnList.Add(lastRun);
                }
                else
                {
                    break;
                }
            }

            return returnList;
        }
        private static DateTime MakeDateTime(string endDate, string timeOnDay)
        {
            endDate = endDate.Insert(4, "-");
            endDate = endDate.Insert(7, "-");
            endDate += " ";

            timeOnDay = timeOnDay.Insert(2, ":");
            timeOnDay = timeOnDay += ":00";

            return Convert.ToDateTime(endDate + timeOnDay);
        }

        private static void ReadEnum()
        {
            SubObjectTypesEnum myEnum = SubObjectTypesEnum.Gas;

            var hej = myEnum;
            int something = (int)myEnum;
        }
        private static void MakeFolderName()
        {
            string file = "2345234";

            string todaysDate = DateTime.Now.ToShortDateString();
            string asdf = DateTime.Now.ToString();
            var filePath = Path.Combine(Path.GetTempPath(), "LW_WorkOrdersIncoming", todaysDate);

            string fileName = Guid.NewGuid().ToString() + " _ " + file + ".txt";
        }

        private static void ConvertNullToString()
        {
            string myNull = null;

            string testString = Convert.ToString(myNull);
        }

        private static void ParseDateRSS()
        {

            StringBuilder elementText = new StringBuilder();
            DateTime PubDate;
            elementText.Append("Mon, 04 Dec 2017 00:00:00 +0100");

            try
            {
                DateTime publishedDate = new DateTime();

                bool parseSuccessfulByTryParseExact = DateTime.TryParseExact(elementText.ToString(), "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'", CultureInfo.GetCultureInfo("en-GB").DateTimeFormat, DateTimeStyles.None, out publishedDate);

                // Alternativ 1: Att ändra TryParseExact till bara TryParse
                bool parseSuccessfulByTryParseExactOption1 = DateTime.TryParse(elementText.ToString(), out publishedDate);


                if (!parseSuccessfulByTryParseExact)
                {
                    DateTime.TryParse(elementText.ToString(), out publishedDate);
                }

                PubDate = publishedDate;
            }
            catch (Exception e)
            {
                try
                {
                    string tmp = elementText.ToString();
                    tmp = tmp.Substring(0, tmp.Length - 5);
                    tmp += "GMT";
                    PubDate = DateTime.Parse(tmp);
                }
                catch (Exception ea)
                {
                    var ex = ea.ToString();
                }
            }
        }





        private static void DateTimeToString()
        {
            DateTime theTime = DateTime.Now;

            string hello1 = theTime.ToShortDateString();
            string hello2 = theTime.ToShortTimeString();
            string hello3 = theTime.ToLongDateString();
            string hello4 = theTime.ToLongTimeString();
            string hello5 = theTime.ToString();
        }

        private static void CountTimeInMethod()
        {

            DateTime startTime = DateTime.UtcNow;

            Thread.Sleep(1000);

            DateTime stopTime = DateTime.UtcNow;

            string hej = (stopTime - startTime).TotalSeconds.ToString();




        }

        private static void RandomOneOrTwo()
        {
            Random rand = new Random();
            List<int> intList = new List<int>();

            for (int i = 0; i < 20; i++)
            {
                int num = rand.Next(1, 3);

                intList.Add(num);

            }



            var stophere = 3;



        }

        private static void ConvertToDouble()
        {
            string value = "1,5";

            if (value.Contains(","))
            {
                value = value.Replace(',', '.');
            }


            string hej = Math.Round(Convert.ToDouble(value, CultureInfo.InvariantCulture.NumberFormat)).ToString();



            double valueAsDouble = Convert.ToDouble(value);

            string result = Convert.ToInt32(valueAsDouble).ToString();

        }





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
