using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTestsConsole.Object
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public Person(string name, int age, string phoneNumber)
        {
            Name = name;
            Age = age;
            PhoneNumber = phoneNumber;
        }
        public Person()
        {

        }
    }
}
