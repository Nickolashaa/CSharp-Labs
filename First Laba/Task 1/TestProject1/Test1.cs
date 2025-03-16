using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program;

namespace Program.Tests
{
    [TestClass]
    public class RationalTest
    {
        // Тест для метода ToString
        [TestMethod]
        public void TestToString_PositiveNumbers()
        {
            var a = 15;
            var b = 7;
            var expected = "15/7";
            Assert.IsTrue(new Rational(a, b).ToString() == expected);
        }

        [TestMethod]
        public void TestToString_NegativeNumbers()
        {
            var a = -15;
            var b = 7;
            var expected = "-15/7";
            Assert.IsTrue(new Rational(a, b).ToString() == expected);
        }

        // Тест для конструктора
        [TestMethod]
        public void TestConstructor_ValidInput()
        {
            var a = 3;
            var b = 4;
            var rational = new Rational(a, b);
            Assert.IsTrue(rational.ToString() == "3/4");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructor_ZeroDenominator()
        {
            var a = 3;
            var b = 0;
            var rational = new Rational(a, b);
        }

        // Тест для оператора сложения (+)
        [TestMethod]
        public void TestAdd_PositiveNumbers()
        {
            var a = new Rational(1, 2);
            var b = new Rational(4, 5);
            Assert.IsTrue((a + b).ToString() == "13/10");
        }

        [TestMethod]
        public void TestAdd_NegativeNumbers()
        {
            var a = new Rational(-1, 2);
            var b = new Rational(4, 5);
            Assert.IsTrue((a + b).ToString() == "3/10");
        }

        // Тест для оператора вычитания (-)
        [TestMethod]
        public void TestSub_PositiveNumbers()
        {
            var a = new Rational(1, 2);
            var b = new Rational(1, 3);
            Assert.IsTrue((a - b).ToString() == "1/6");
        }

        [TestMethod]
        public void TestSub_NegativeNumbers()
        {
            var a = new Rational(1, 2);
            var b = new Rational(-1, 3);
            Assert.IsTrue((a - b).ToString() == "5/6");
        }

        // Тест для оператора умножения (*)
        [TestMethod]
        public void TestMul_PositiveNumbers()
        {
            var a = new Rational(1, 2);
            var b = new Rational(1, 3);
            Assert.IsTrue((a * b).ToString() == "1/6");
        }

        [TestMethod]
        public void TestMul_NegativeNumbers()
        {
            var a = new Rational(-1, 2);
            var b = new Rational(1, 3);
            Assert.IsTrue((a * b).ToString() == "-1/6");
        }

        // Тест для оператора деления (/)
        [TestMethod]
        public void TestDiv_PositiveNumbers()
        {
            var a = new Rational(1, 2);
            var b = new Rational(1, 3);
            Assert.IsTrue((a / b).ToString() == "3/2");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDiv_DivideByZero()
        {
            var a = new Rational(1, 2);
            var b = new Rational(0, 1);
            var result = a / b;
        }

        // Тест для оператора равенства (==)
        [TestMethod]
        public void TestEquality_EqualNumbers()
        {
            var a = new Rational(1, 2);
            var b = new Rational(1, 2);
            Assert.IsTrue(a.ToString() == b.ToString());
        }

        [TestMethod]
        public void TestEquality_NotEqualNumbers()
        {
            var a = new Rational(1, 2);
            var b = new Rational(2, 3);
            Assert.IsTrue(a.ToString() != b.ToString());
        }

        // Тест для оператора неравенства (!=)
        [TestMethod]
        public void TestInequality_NotEqualNumbers()
        {
            var a = new Rational(1, 2);
            var b = new Rational(2, 3);
            Assert.IsTrue(a.ToString() != b.ToString());
        }

        [TestMethod]
        public void TestInequality_EqualNumbers()
        {
            var a = new Rational(1, 2);
            var b = new Rational(1, 2);
            Assert.IsTrue(!(a.ToString() != b.ToString()));
        }

        // Тест для оператора больше (>)
        [TestMethod]
        public void TestGreaterThan_True()
        {
            var a = new Rational(3, 4);
            var b = new Rational(1, 2);
            Assert.IsTrue(a > b);
        }

        [TestMethod]
        public void TestGreaterThan_False()
        {
            var a = new Rational(1, 2);
            var b = new Rational(3, 4);
            Assert.IsTrue(!(a > b));
        }

        // Тест для оператора меньше (<)
        [TestMethod]
        public void TestLessThan_True()
        {
            var a = new Rational(1, 2);
            var b = new Rational(3, 4);
            Assert.IsTrue(a < b);
        }

        [TestMethod]
        public void TestLessThan_False()
        {
            var a = new Rational(3, 4);
            var b = new Rational(1, 2);
            Assert.IsTrue(!(a < b));
        }

        // Тест для оператора больше или равно (>=)
        [TestMethod]
        public void TestGreaterThanOrEqual_True()
        {
            var a = new Rational(3, 4);
            var b = new Rational(1, 2);
            Assert.IsTrue(a >= b);
        }

        [TestMethod]
        public void TestGreaterThanOrEqual_Equal()
        {
            var a = new Rational(1, 2);
            var b = new Rational(1, 2);
            Assert.IsTrue(a >= b);
        }

        // Тест для оператора меньше или равно (<=)
        [TestMethod]
        public void TestLessThanOrEqual_True()
        {
            var a = new Rational(1, 2);
            var b = new Rational(3, 4);
            Assert.IsTrue(a <= b);
        }

        [TestMethod]
        public void TestLessThanOrEqual_Equal()
        {
            var a = new Rational(1, 2);
            var b = new Rational(1, 2);
            Assert.IsTrue(a <= b);
        }
    }
}