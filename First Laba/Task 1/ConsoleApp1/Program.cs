using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Rational
    {
        private int Numerator;
        private int Denominator;

        public Rational(int a, int b)
        {
            if (b == 0)
            {
                throw new ArgumentException("Знаменатель не может равняться 0");
            }

            if (a == 0)
            {
                Numerator = 0;
                Denominator = 1;
                return;
            }

            int gcd = GCD(Math.Abs(a), Math.Abs(b));
            a /= gcd;
            b /= gcd;

            if ((a < 0) && (b < 0))
            {
                a *= -1;
                b *= -1;
            }

            Numerator = a;
            Denominator = b;
        }

        public override string ToString()
        {
            if (Numerator == 0)
            {
                return "0";
            }
            string result = $"{Math.Abs(Numerator)}/{Math.Abs(Denominator)}";
            if ((Numerator < 0) || (Denominator < 0))
            {
                result = "-" + result;
            }
            return result;
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static Rational operator +(Rational first, Rational second)
        {
            int NewFirstNumerator = first.Numerator * second.Denominator;
            int NewSecondNumerator = second.Numerator * first.Denominator;
            return new Rational(NewFirstNumerator + NewSecondNumerator, first.Denominator * second.Denominator);
        }

        public static Rational operator -(Rational first, Rational second)
        {
            int NewFirstNumerator = first.Numerator * second.Denominator;
            int NewSecondNumerator = second.Numerator * first.Denominator;
            return new Rational(NewFirstNumerator - NewSecondNumerator, first.Denominator * second.Denominator);
        }

        public static Rational operator *(Rational first, Rational second)
        {
            return new Rational(first.Numerator * second.Numerator, first.Denominator * second.Denominator);
        }

        public static Rational operator /(Rational first, Rational second)
        {
            if (second.Numerator == 0)
            {
                throw new ArgumentException("Нельзя делить на 0");
            }
            Rational SwitchedSecond = new Rational(second.Denominator, second.Numerator);
            return first * SwitchedSecond;
        }

        public static Rational operator -(Rational first)
        {
            return new Rational(first.Numerator * -1, first.Denominator);
        }

        public static bool operator ==(Rational first, Rational second)
        {
            return first.Numerator == second.Numerator && first.Denominator == second.Denominator;
        }

        public static bool operator !=(Rational first, Rational second)
        {
            return first.Numerator != second.Numerator && first.Denominator == second.Denominator;
        }

        public static bool operator >(Rational first, Rational second)
        {
            int NewFirstNumerator = first.Numerator * second.Denominator;
            int NewSecondNumerator = second.Numerator * first.Denominator;
            return NewFirstNumerator > NewSecondNumerator;
        }

        public static bool operator <(Rational first, Rational second)
        {
            int NewFirstNumerator = first.Numerator * second.Denominator;
            int NewSecondNumerator = second.Numerator * first.Denominator;
            return NewFirstNumerator < NewSecondNumerator;
        }

        public static bool operator >=(Rational first, Rational second)
        {
            int NewFirstNumerator = first.Numerator * second.Denominator;
            int NewSecondNumerator = second.Numerator * first.Denominator;
            return NewFirstNumerator >= NewSecondNumerator;
        }

        public static bool operator <=(Rational first, Rational second)
        {
            int NewFirstNumerator = first.Numerator * second.Denominator;
            int NewSecondNumerator = second.Numerator * first.Denominator;
            return NewFirstNumerator <= NewSecondNumerator;
        }
    }

    class Program
    {
        static void Main() { Console.WriteLine("I am good"); }
    }
}