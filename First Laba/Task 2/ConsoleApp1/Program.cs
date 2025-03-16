using System.Globalization;


public interface IDateTimePrinter
{
    string Print();
}


public class EuropeanDateTimePrinter : IDateTimePrinter
{
    public string Print()
    {
        return DateTime.Now.ToString(new CultureInfo("fr-FR"));
    }
}


public class AmericanDateTimePrinter : IDateTimePrinter
{
    public string Print()
    {
        return DateTime.Now.ToString(new CultureInfo("en-US"));
    }
}


public abstract class DateTimeDecorator : IDateTimePrinter
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


class Program
{
    static void Main()
    {

        IDateTimePrinter printer = new EuropeanDateTimePrinter();


        printer = new PrefixDecorator(printer, ">>> ");
        printer = new SuffixDecorator(printer, " <<<");


        Console.WriteLine("European DateTime: " + printer.Print());

        printer = new AmericanDateTimePrinter();
        printer = new PrefixDecorator(printer, "*** ");
        printer = new SuffixDecorator(printer, " ***");

        Console.WriteLine("American DateTime: " + printer.Print());
    }
}