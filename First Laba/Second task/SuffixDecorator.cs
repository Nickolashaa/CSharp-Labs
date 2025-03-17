using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_task
{
    public class SuffixDecorator : DateTimeDecorator
    {
        private string suffix;

        public SuffixDecorator(IDateTimePrinter printer, string suffix) : base(printer)
        {
            this.suffix = suffix;
        }

        public override string Print()
        {
            return printer.Print() + suffix;
        }
    }
}
