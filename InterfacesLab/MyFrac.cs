using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Lab
{
    public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        public BigInteger nom { get; set; }
        public BigInteger denom { get; set; }

        public MyFrac(BigInteger nom, BigInteger denom)
        {
            if (denom.IsZero)
                throw new DivideByZeroException("Denominator cannot be zero.");

            if (denom < 0)
            {
                nom = -nom;
                denom = -denom;
            }

            BigInteger gcd = BigInteger.GreatestCommonDivisor(BigInteger.Abs(nom), BigInteger.Abs(denom));
            this.nom = nom / gcd;
            this.denom = denom / gcd;
        }
         public MyFrac(BigInteger nom) : this(nom, 1) { }

        public MyFrac(int nom, int denom) : this((BigInteger)nom, (BigInteger)denom) { }

        public MyFrac(MyFrac copy)
        {
            nom = copy.nom;
            denom = copy.denom;
        }
        public MyFrac Add(MyFrac that)
        {
            return new MyFrac(nom * that.denom + that.nom * denom, denom * that.denom);
        }

        public MyFrac Divide(MyFrac that)
        {
            if (that.nom.IsZero)
                throw new DivideByZeroException("Can't divide by 0");
            return new MyFrac(nom * that.denom, denom * that.nom);
        }

        public MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(nom * that.nom, denom * that.denom);
        }

        public MyFrac Substract(MyFrac that)
        {
            return new MyFrac(nom * that.denom - that.nom * denom, denom * that.denom);
        }
        public (BigInteger num, BigInteger denum) Simplify()
        {
            BigInteger gcd = BigInteger.GreatestCommonDivisor(BigInteger.Abs(nom), BigInteger.Abs(denom));
            return (nom / gcd, denom / gcd);
        }

        public override string ToString()
        {
            var (num, denum) = Simplify();
            if (denum == 1)
                return $"{num}";
            else
                return $"{num}/{denum}";
        }
        public int CompareTo(MyFrac? other)
        {
            if (other is null) return 1;
            BigInteger left = nom * other.denom;
            BigInteger right = other.nom * denom;
            return left.CompareTo(right);
        }
    }
}
