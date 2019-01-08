using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTestsConsole.Object
{
    public class DbPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DbPhoneNumber PhoneNumber { get; set; }

        public DbPerson(string name, int age, DbPhoneNumber phoneNumber)
        {
            Name = name;
            Age = age;
            PhoneNumber = phoneNumber;
        }
    }
}
