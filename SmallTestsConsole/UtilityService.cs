using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmallTestsConsole
{
    public class UtilityService
    {
        public UtilityService()
        {

        }

        static UtilityService myDoer = new UtilityService();
        #region longList
        static List<long> longList = new List<long>
            {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            11,
            12,
            13,
            14,
            15,
            16,
            17,
            18,
            19,
            20,
            };
        #endregion

        public static void SimulatedMain()
        {
            
            myDoer.CompareUtilityServices("12345", "TheCaller", longList);

            WriteLine("Nothing more to do in UtilityService");
            while (true)
            {

            }
        }

        private static Semaphore sem = new Semaphore(5, 5); 
        public delegate bool MyDelegateMethod(string batchId, string callerName, long id);

        public void asyncResult(IAsyncResult inputResult)
        {
            // Retrieve the delegate.
            AsyncResult result = (AsyncResult)inputResult;
            MyDelegateMethod caller = (MyDelegateMethod)result.AsyncDelegate;

            // Call EndInvoke to retrieve the results.
            bool returnValue = caller.EndInvoke(inputResult);

            //WriteLine(returnValue.ToString());
        }

        
        public bool CompareUtilityServices(string batchId, string callerName, List<long> utilityServiceIds)
        {
            try
            {
                
                var worker = new MyDelegateMethod(CompareUtilityService);

                foreach (var utilServiceId in utilityServiceIds)
                {
                    //var worker2 = new MyDelegateMethod(RandomMethod);
                    var fireAndForget = worker.BeginInvoke(batchId, callerName, utilServiceId, new AsyncCallback(asyncResult), null);

                    //bool variances = CompareUtilityService(batchId, callerName, utilServiceId);
                }

                return true;
            }
            catch (Exception e)
            {
                var stophere = 4;
                return false;
            }
        }



        





        public bool CompareUtilityService(string batchId, string callerName, long utilityServiceId)
        {
            sem.WaitOne();
            Green(string.Format("Start: {0}", utilityServiceId));
            Thread.Sleep(5000);

            
            Red(string.Format("Stop: {0}", utilityServiceId));
            sem.Release();
            return true;
        }
        private static void Red(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;

        }
        private static void Green(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        //Utility
        private static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

    }
}
