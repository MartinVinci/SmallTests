using SmallTestsConsole.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTestsConsole
{
    public class BjornTretton
    {
        public BjornTretton()
        {

        }
        public static void SimulatedMain()
        {
            //TryLambda();
            //TryInstanceInIfStatement();

            TryDateTimes();

            WriteLine("Nothing more to do in BjornTretton");
            ReadLine();
        }

        private static void TryDateTimes()
        {
            var orig = DateTime.UtcNow;
            var altr = DateTimeOffset.UtcNow;
        }

        private static void TryLambda()
        {
            // Stub objects
            var dbPhoneOne = new DbPhoneNumber("Home", "040-123456");
            var dbPhoneTwo = new DbPhoneNumber("Mobile", "070-1234567");

            var dbPersonOne = new DbPerson("Adam", 20, dbPhoneOne);
            var dbPersonTwo = new DbPerson("Bertil", 25, dbPhoneTwo);

            var dbPersonList = new List<DbPerson>();
            dbPersonList.Add(dbPersonOne);
            dbPersonList.Add(dbPersonTwo);


            // Do the test - new way
            var personList = dbPersonList.Select(a =>
            {
                return new Person()
                {
                    Name = a.Name,
                    Age = a.Age,
                    PhoneNumber = a.PhoneNumber.TheNumber
                };
            }).ToList();
        }

        private static void TryInstanceInIfStatement()
        {
            var name = "No name";

            if (ReturnTrueOrFalse("Some text", out Person person))
            {
                name = person.Name;
            }
            else
            {

            }

            var number = person.PhoneNumber;
        }

        private static bool ReturnTrueOrFalse(string text, out Person person)
        {
            person = new Person("Adam", 51, "040-123456");

            return true;
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
