using System;

namespace Hord
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0.4;
            double b = 0.5;
            double h = 0.01;
            double x = a;
            int n = 11;
            double[] x1 = new double[n];
            double[] f = new double[n];
            Console.WriteLine("   x\t|       f(x)\t|");
            for (int i = 0; i < n; i++)
            {
                x1[i] = x;
                f[i] = Math.Pow(x, 2) - Math.Cos(Math.PI * x);
                Console.WriteLine($" {x.ToString("0.00")}\t| {f[i].ToString("0.0000000")}\t|");
                x = x + h;
            }
            Console.WriteLine("\nПодозрительный на отрезок изоляции: ");
            Console.WriteLine("\n   x\t|       f(x)\t|");
            for (int i = 1; i < n; i++)
            {
                if (f[i] > 0)
                {
                    if (f[i - 1] < 0)
                    {
                        Console.WriteLine($" {x1[i - 1].ToString("0.00")}\t| {f[i - 1].ToString("0.0000000")}\t|");
                        a = x1[i - 1];
                        Console.WriteLine($" {x1[i].ToString("0.00")}\t| {f[i].ToString("0.0000000")}\t|\n");
                        b = x1[i];
                    }
                }
            }
            x = a;
            double h2 = h / 10;
            double[] x2 = new double[n];
            double[] f2 = new double[n];
            Console.WriteLine("   x\t|       f'(x)\t|");
            for (int i = 0; i < n; i++)
            {
                x2[i] = x;
                f2[i] = 2 * x + Math.PI * Math.Sin(Math.PI * x);
                Console.WriteLine($" {x.ToString("0.000")}\t| {f2[i].ToString("0.0000000")}\t|");
                x = x + h2;
            }
            double[] x3 = new double[n];
            double[] fa = new double[n];
            double[] fb = new double[n];
            
            Console.WriteLine("   a\t|   b\t|       f(a)\t|       f(b)\t|   x\t|");
            for (int i = 1; i < n; i++) 
            {
                  fa[i] = Math.Pow(a, 2) - Math.Cos(Math.PI * a);
                  fb[i] = Math.Pow(b, 2) - Math.Cos(Math.PI * b);
                  x3[i] = a-(fa[i]*(b-a)/(fb[i]-fa[i]));
                  Console.WriteLine($" {a.ToString("0.00000000")}\t|{b.ToString("0.00")}\t| {fa[i].ToString("0.0000000")}\t| {fb[i].ToString("0.0000000")}\t| {x3[i].ToString("0.00000000")}\t|");
                 a = x3[i];
                if (x3[i] == x3[i - 1]) break;
    
            }
        }
    }
}
