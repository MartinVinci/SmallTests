using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTestsConsole.Object
{
    public class DbPhoneNumber
    {
        public string NumberType { get; set; }
        public string TheNumber{ get; set; }

        public DbPhoneNumber(string numberType, string theNumber)
        {
            NumberType = numberType;
            TheNumber = theNumber;
        }
    }
}
