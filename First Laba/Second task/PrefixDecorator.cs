using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_task
{
    public class PrefixDecorator : DateTimeDecorator
    {
        private string prefix;

        public PrefixDecorator(IDateTimePrinter printer, string prefix) : base(printer)
        {
            this.prefix = prefix;
        }

        public override string Print()
        {
            return prefix + printer.Print();
        }
    }
}
