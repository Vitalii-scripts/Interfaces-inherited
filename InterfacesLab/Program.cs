using System;
using System.Collections.Generic;
using Lab;
class Program
{
    static void TestAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        T aPlusB = a.Add(b);
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.WriteLine("(a + b) = " + aPlusB);
        Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
        Console.WriteLine(" = = = ");
        T curr = a.Multiply(a);
        Console.WriteLine("a^2 = " + curr);
        T wholeRightPart = curr;
        curr = a.Multiply(b); // ab
        curr = curr.Add(curr); // ab + ab = 2a
        Console.WriteLine("2*a*b = " + curr);
        wholeRightPart = wholeRightPart.Add(curr);
        curr = b.Multiply(b);
        Console.WriteLine("b^2 = " + curr);
        wholeRightPart = wholeRightPart.Add(curr);
        Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
        Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
    }
    static void Main()
    {
        TestAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
        TestAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));
        TestSquaresDifference(new MyFrac(1, 3), new MyFrac(1, 6));
        TestSquaresDifference(new MyComplex(1, 3), new MyComplex(1, 6));
        List<MyFrac> fracs = new() { new MyFrac(1, 3), new MyFrac(1, 6), new MyFrac(2, 5) };
        fracs.Sort();
        Console.WriteLine("Sorted: " + string.Join(" ", fracs));
        Console.ReadKey();
    }
    static void TestSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine($"a = {a}, b={b}");
        Console.WriteLine($"a - b = {a.Substract(b)}");
        Console.WriteLine($"(a^2 - b^2) / (a + b) = {a.Multiply(a).Substract((b.Multiply(b))).Divide(a.Add(b))}");
        if (a is MyFrac fa && b is MyFrac fb)
        {
            MyFrac left = fa.Substract(fb);
            MyFrac right = fa.Multiply(fa).Substract(fb.Multiply(fb)).Divide(fa.Add(fb));
            int cmp = left.CompareTo(right);
            Console.WriteLine($"Comparing (a-b) and (a^2-b^2)/(a+b): {cmp} (0 means equal)");
        }
    }

}