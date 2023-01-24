namespace ConsoleApp1
{
    public class MyMath
    {
        public static int Evklid(int x, int y)
        {
            x = Math.Abs(x);
            y = Math.Abs(y);
            while (x * y != 0)
            {
                if (x > y) { x = x % y; }
                else { y = y % x; }
            }
            return x + y;

        }
    }
    public class Ratio
    {

        public int numerator;
        public int denominator;

        public Ratio Simple_fraction()
        {
            int NOD;
            NOD = MyMath.Evklid(numerator, denominator);
            numerator /= NOD;
            denominator /= NOD;
            return new Ratio(numerator, denominator);
        }

        public Ratio(int num, int den)
        {
            numerator = num;
            denominator = den;
            if (denominator < 0)
            {
                numerator *= -1;
                denominator *= -1;
            }
        }

        public Ratio(int num) : this(num, 1) { }

        public override string ToString()
        {
            if (denominator != 1)
            {
                if (denominator < 0 && numerator > 0)
                {
                    denominator *= -1;
                    numerator *= -1;
                    return $"{numerator}/{denominator}";
                }
                else if (denominator < 0 && numerator < 0)
                {
                    denominator *= -1;
                    numerator *= -1;
                    return $"{numerator}/{denominator}";
                }
                return $"{numerator}/{denominator}";
            }

            return $"{numerator}";
        }

        public double ToDuble()
        {
            return (double)numerator / denominator;
        }

        public static Ratio operator *(Ratio x, Ratio y)
        {
            int N, D;
            Ratio NewR;
            N = x.numerator * y.numerator;
            D = x.denominator * y.denominator;
            NewR = new Ratio(N, D);
            return NewR;
        }

        public static Ratio operator *(int x, Ratio y)
        {
            Ratio N = new Ratio(x);
            return N * y;
        }

        public static Ratio operator *(Ratio y, int x)
        {
            Ratio N = new Ratio(x);
            return N * y;
        }
        // /
        public static Ratio operator /(Ratio x, Ratio y)
        {
            int N, D;
            Ratio NewR;
            N = x.numerator * y.denominator;
            D = x.denominator * y.numerator;
            NewR = new Ratio(N, D);
            return NewR.Simple_fraction();
        }
        public static Ratio operator /(int x, Ratio y)
        {
            Ratio N = new Ratio(x);
            Ratio res = N / y;
            return res.Simple_fraction();
        }

        public static Ratio operator /(Ratio y, int x)
        {
            Ratio N = new Ratio(x);
            Ratio res = y / N;
            return res.Simple_fraction();
        }

        // +
        public static Ratio operator +(Ratio x, Ratio y)
        {
            int N, D;
            Ratio NewR;
            N = x.numerator * y.denominator + x.denominator * y.numerator;
            D = x.denominator * y.denominator;
            NewR = new Ratio(N, D);
            return NewR.Simple_fraction();
        }
        public static Ratio operator +(int x, Ratio y)
        {
            Ratio N = new Ratio(x);
            Ratio res = y + N;
            return res.Simple_fraction();
        }

        public static Ratio operator +(Ratio y, int x)
        {
            Ratio N = new Ratio(x);
            Ratio res = y + N;
            return res.Simple_fraction();
        }
        // -
        public static Ratio operator -(Ratio x, Ratio y)
        {
            int N, D;
            Ratio NewR;
            D = x.denominator * y.denominator;
            N = x.numerator * y.denominator - x.denominator * y.numerator;
            NewR = new Ratio(N, D);
            return NewR.Simple_fraction();
        }
        public static Ratio operator -(int x, Ratio y)
        {
            Ratio N = new Ratio(x);
            Ratio res = N - y;
            return res.Simple_fraction();
        }

        public static Ratio operator -(Ratio y, int x)
        {
            Ratio N = new Ratio(x);
            Ratio res = y - N;
            return res.Simple_fraction();
        }
        // ++ --
        public static Ratio operator ++(Ratio x)
        {
            Ratio N = new Ratio(x.denominator, x.denominator);
            Ratio res = N + x;
            return res.Simple_fraction();
        }
        public static Ratio operator --(Ratio x)
        {
            Ratio N = new Ratio(x.denominator, x.denominator);
            Ratio res = x - N;
            return res.Simple_fraction();
        }

        // == !=
        public static bool operator !=(Ratio x, Ratio y)
        {
            return x.numerator * y.denominator != x.denominator * y.numerator;
        }
        public static bool operator ==(Ratio x, Ratio y)
        {
            return x.numerator * y.denominator == x.denominator * y.numerator;
        }
        // < >
        public static bool operator >(Ratio x, Ratio y)
        {
            return x.numerator * y.denominator > x.denominator * y.numerator;
        }
        public static bool operator <(Ratio x, Ratio y)
        {
            return x.numerator * y.denominator < x.denominator * y.numerator;
        }

        // >= <=
        public static bool operator >=(Ratio x, Ratio y)
        {
            return x.numerator * y.denominator >= x.denominator * y.numerator;
        }
        public static bool operator <=(Ratio x, Ratio y)
        {
            return x.numerator * y.denominator <= x.denominator * y.numerator;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var r1 = new Ratio(1, 4);
            var r2 = new Ratio(1, 5);
            r1 += r2;
            Console.WriteLine(r1);
        }
    }
}