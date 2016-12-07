using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SmallTestsConsole
{
    public class VerySmallTests
    {
        public static void SimulatedMain()
        {
            CallApi();


            WriteLine("Nothing more to do in ReadTextfiles");
            StopLine();
        }
        
        private static void CallApi()
        {
            var client = new ManoBranchApi();
            var response = client.Contact.Get();
            //var response2 = client.Contact.GetById(3);

            var contacts = response;

            foreach (var contact in contacts)
            {
                WriteLine(string.Format("{0} {1}", contact.Id, contact.Name));
            }

        }





        //Utility
        private static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
        private static void StopLine()
        {
            Console.ReadLine();
        }
    }
}
