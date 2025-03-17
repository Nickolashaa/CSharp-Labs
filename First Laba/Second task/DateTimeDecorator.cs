using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_task
{
    public class DateTimeDecorator : IDateTimePrinter
    {
        protected IDateTimePrinter printer;

        public DateTimeDecorator(IDateTimePrinter printer)
        {
            this.printer = printer;
        }

        public virtual string Print()
        {
            return printer.Print();
        }
    }
}
