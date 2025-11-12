using System;

namespace Lab;

public class MyComplex : IMyNumber<MyComplex>
{
     public double re { get; set; }
    public double im { get; set; }
    public MyComplex(double re, double im)
    {
        this.re = re;
        this.im = im;
    }
    public MyComplex Add(MyComplex that)
    {
        return new MyComplex(re+that.re,im+that.im);
    }

    public MyComplex Divide(MyComplex that)
    {
        if (that.re * that.re + that.im * that.im == 0 || that.re * that.re + that.im * that.im==0)
            throw new DivideByZeroException("Can't be divided by 0");
        return new MyComplex((re*that.re+im*that.im)/(that.re*that.re+that.im*that.im),(im*that.re-re*that.im)/(that.re*that.re+that.im*that.im));
    }

    public MyComplex Multiply(MyComplex that)
    {
        return new MyComplex(re*that.re-im*that.im,re*that.im+im*that.re);
    }

    public MyComplex Substract(MyComplex that)
    {
        return new MyComplex(re - that.re, im - that.im);
    }
    public override string ToString()
    {
        if (im < 0)
            return $"{re}{im}i";
        return $"{re}+{im}i";
    }
}
