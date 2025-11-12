using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Lab
{
    public class MyFrac : IMyNumber<MyFrac>
    {
        public BigInteger nom { get; set; }
        public BigInteger denom { get; set; }

        public MyFrac(BigInteger nom, BigInteger denom)
        {
            this.nom = nom;
            this.denom = denom;
        }

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

        public override string ToString()
        {
            if (denom == 1)
                return $"{nom}";
            else
                return $"{nom}/{denom}";
        }
    }
}
