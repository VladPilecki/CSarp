using System;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please,write two rational numbers: \n");
            Rational a = new Rational();
            Rational b = new Rational();
            Console.WriteLine(a.ToString() + "  " + b.ToString());

            Console.WriteLine($" 1) {a} >= {b} = " + (a >= b));
            Console.WriteLine($" 2) {a.ToStringfloat()} >= {b.ToStringfloat()} = " + (a >= b));
            Console.WriteLine($" 3) {a} < {b} = " + (a < b));
            Console.WriteLine($" 4) {a.ToStringfloat()} < {b.ToStringfloat()} = " + (a < b));
            Console.WriteLine($" 5) {a} <= {b} = " + (a <= b));
            Console.WriteLine($" 6) {a.ToStringfloat()} <= {b.ToStringfloat()} = " + (a <= b));
            Console.WriteLine($" 7) {a} != {b} = " + (a != b));
            Console.WriteLine($" 8) {a.ToStringfloat()} != {b.ToStringfloat()} = " + (a != b));
            Console.WriteLine($" 9) {a} - {b} = " + (a - b));
            Console.WriteLine($" 10) {a.ToStringfloat()} - {b.ToStringfloat()} = " + (a - b).ToStringfloat());
            Console.WriteLine($" 11) {a} + {b} = " + (a + b));
            Console.WriteLine($" 12) {a.ToStringfloat()} + {b.ToStringfloat()} = " + (a + b).ToStringfloat());
            Console.WriteLine($" 13) {a} * {b} = " + (a * b));
            Console.WriteLine($" 14) {a.ToStringfloat()} * {b.ToStringfloat()} = " + (a * b).ToStringfloat());
            Console.WriteLine($" 15) {a} / {b} = " + (a / b));
            Console.WriteLine($" 16) {a.ToStringfloat()} / {b.ToStringfloat()} = " + (a / b).ToStringfloat());


            Console.WriteLine("Rational number in string form: " + a.ToString());
            Console.WriteLine("Rational number as float: " + a.ToStringfloat());
            Console.WriteLine("Rational number as double: " + a.ToStringDouble() + "\n");

            Console.ReadLine();
        }
    }
    class Rational : IComparable<Rational>, IEquatable<Rational>
    {
        private int numerator;
        private int denominator;

        public static int NOD(int a, int b)
        {
            if (a == 0)
                return b;
            else
                return Math.Abs(NOD(b % a, a));
        }

        public Rational()
        {
            int a;
            int b;
            Console.Write("Write numerator ");
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.Write("Wrong input, try again: ");
            }
            Console.Write("Write denominator ");
            while (!int.TryParse(Console.ReadLine(), out b) || b <= 0)
            {
                Console.Write("Wrong input, try again: ");
            }
            numerator = a;
            denominator = b;
        }
        public Rational(int a, int b = 1)
        {
            numerator = a;
            denominator = b;
        }

        public int CompareTo(Rational other)
        {
            if (other == null)
                return 1;
            int newNum1 = this.numerator * other.denominator;
            int newNum2 = other.numerator * this.denominator;
            return newNum1 - newNum2;
        }

        private void Simplify()
        {
            int nod = NOD(denominator, numerator);
            denominator /= nod;
            numerator /= nod;
        }

        private int CountIntPart()
        {
            int number;
            if (numerator > denominator)
                number = numerator / denominator;
            else
                number = 0;
            return number;
        }

        public bool Equals(Rational other)
        {
            if (other != null && this.CompareTo(other) == 0)
                return true;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is Rational && Equals((Rational)obj))
                return true;
            else
                return false;
        }

        public static bool operator >(Rational number1, Rational number2)
        {

            if (number1.CompareTo(number2) > 0)
                return true;
            else
                return false;
        }

        public static bool operator <(Rational number1, Rational number2)
        {
            if (number1.CompareTo(number2) < 0)
                return true;
            else
                return false;
        }

        public static bool operator >=(Rational number1, Rational number2)
        {
            if (number1.CompareTo(number2) < 0)
                return false;
            else
                return true;
        }

        public static bool operator <=(Rational number1, Rational number2)
        {
            if (number1.CompareTo(number2) > 0)
                return false;
            else
                return true;
        }

        public static bool operator ==(Rational number1, Rational number2)
        {
            if (number1 is null && number2 is null)
                return true;
            else if ((number1 is null && !(number2 is null)) || (!(number1 is null) && number2 is null))
                return false;
            else
            {
                if (number1.CompareTo(number2) == 0)
                    return true;
                else
                    return false;
            }
        }

        public static bool operator !=(Rational number1, Rational number2)
        {
            if (number1 == number2)
                return false;
            else
                return true;
        }

        public static Rational operator -(Rational number)
        {
            int newNumerator = -number.numerator;
            Rational newNumber = new Rational(newNumerator, number.denominator);
            return newNumber;
        }

        public static Rational operator -(Rational number1, Rational number2)
        {
            Rational result = new Rational(0);
            result.numerator = number1.numerator * number2.denominator - number2.numerator * number1.denominator;
            result.denominator = number1.denominator * number2.denominator;
            result.Simplify();
            return result;
        }

        public static Rational operator +(Rational number1, Rational number2)
        {
            Rational result = new Rational(0);
            result.numerator = number1.numerator * number2.denominator + number2.numerator * number1.denominator;
            result.denominator = number1.denominator * number2.denominator;
            result.Simplify();
            return result;
        }

        public static Rational operator *(Rational number1, Rational number2)
        {
            Rational result = new Rational(0);
            result.numerator = number1.numerator * number2.numerator;
            result.denominator = number1.denominator * number2.denominator;
            result.Simplify();
            return result;
        }

        public static Rational operator /(Rational number1, Rational number2)
        {
            Rational result = new Rational(0);
            result.numerator = number1.numerator * number2.denominator;
            result.denominator = number1.denominator * number2.numerator;
            if (result.denominator < 0)
            {
                result.denominator = -result.denominator;
                result.numerator = -result.numerator;
            }
            result.Simplify();
            return result;
        }

        public static explicit operator int(Rational number)
        {
            return number.CountIntPart();
        }

        public static implicit operator float(Rational number)
        {
            return (float)number.numerator / number.denominator;
        }

        public static implicit operator double(Rational number)
        {
            return (double)number.numerator / number.denominator;
        }

        public static implicit operator Rational(int a)
        {
            return new Rational(a);
        }

        public override string ToString()
        {
            int intPart = CountIntPart();
            int num = numerator - intPart * denominator;
            int denom = denominator;
            if (intPart == 0 && num == 0)
                return 0.ToString();
            else if (intPart == 0)
                return String.Format("{0}/{1}", num, denom);
            else if (intPart != 0 && num == 0)
                return intPart.ToString();
            else
                return String.Format("{0} {1}/{2}", intPart, num, denom);
        }

        public string ToStringfloat()
        {
            return ((float)numerator / denominator).ToString();
        }

        public string ToStringDouble()
        {
            return ((double)numerator / denominator).ToString();
        }
    }
}