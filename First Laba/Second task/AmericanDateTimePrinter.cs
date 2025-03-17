using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_task
{
    public class AmericanDateTimePrinter : IDateTimePrinter
    {
        public string Print()
        {
            return DateTime.Now.ToString(new CultureInfo("en-US"));
        }
    }
}
