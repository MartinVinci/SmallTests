using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTestsConsole
{
    public enum ObjectTypesEnum
    {
        UtilityService,
        Customer,
        Contract
    }

    public enum SubObjectTypesEnum
    {
        All = 0,
        Gas = 40020100,
        Vatten = 40020200,
        Cooling = 40020400,
        Heating = 40020300,
        Electricity = 40020000,
        Broadband = 40020500
    }
}
