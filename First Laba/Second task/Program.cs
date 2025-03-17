using Second_task;


IDateTimePrinter printer = new EuropeanDateTimePrinter();


printer = new PrefixDecorator(printer, ">>> ");
printer = new SuffixDecorator(printer, " <<<");


Console.WriteLine("European DateTime: " + printer.Print());

printer = new AmericanDateTimePrinter();
printer = new PrefixDecorator(printer, "*** ");
printer = new SuffixDecorator(printer, " ***");

Console.WriteLine("American DateTime: " + printer.Print());