using System;
using System.Collections.Generic;
namespace zadacha_koshi
{
    class Program
    {
        static int n = 10;
        static double V = 8.0;
        static double h;
        static void Show(List<double> mas)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0:f2} ", mas[i]);
            }
            Console.WriteLine();
        }

        static void Show(double[] mas)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0:f2} ", mas[i]);
            }
            Console.WriteLine();
        }
        static double fDef(double x0, double V)
        {
            return 4 * x0 * x0 * x0 - 3 * x0 * x0 * V;
        }
        static void Main(string[] args)
        {
            Console.Write("h = ");
            h = double.Parse(Console.ReadLine());
            List<double> X = new List<double>();
            List<double> ym = new List<double>();
            List<double> ytoch = new List<double>();
            double[] Eps = new double[n];
            ym.Add(0);
            double m = 8;
            for (double i = 0; i < 10; i++)
            {
                X.Add(m);
                ytoch.Add(m * m * m * m - m*m*m*V);
                m += h;
            }
            for (int i = 1; i < n; i++)
            {
                ym.Add(ym[i - 1] + h * fDef(X[i - 1], V));
            }
            for (int i = 0; i < n; i++)
            {
                Eps[i] = Math.Abs(ym[i] - ytoch[i]);
            }
            Console.WriteLine("Метод Эйлера:");
            Console.Write("x(k): ");
            Show(X);
            Console.Write("Ym: ");
            Show(ym);
            Console.Write("Yt: ");
            Show(ytoch);
            Console.Write("e(k): ");
            Show(Eps);
            Console.WriteLine();
            ym.Clear();
            ym.Add(0);
            for (int i = 1; i < n; i++)
            {
                ym.Add(ym[i - 1] + h * fDef(X[i - 1] + h / 2, V));
            }
            for (int i = 0; i < n; i++)
            {
                Eps[i] = Math.Abs(ym[i] - ytoch[i]);
            }
            Console.WriteLine("Усовершенствованный метод Эйлера:");
            Console.Write("x(k): ");
            Show(X);
            Console.Write("Ym: ");
            Show(ym);
            Console.Write("Yt: ");
            Show(ytoch);
            Console.Write("e(k): ");
            Show(Eps);
            Console.WriteLine();
            ym.Clear();
            ym.Add(0);
            for (int i = 1; i < n; i++)
            {
                ym.Add(ym[i - 1] + h * fDef(X[i - 1], V));
                ym[i] = ym[i - 1] + (h / 2) * (fDef(X[i - 1], V) + fDef(X[i], V + h));

            }
            for (int i = 0; i < n; i++)
            {
                Eps[i] = Math.Abs(ym[i] - ytoch[i]);
            }
            Console.WriteLine("Метод предиктора-корректора:");
            Console.Write("x(k): ");
            Show(X);
            Console.Write("Ym: ");
            Show(ym);
            Console.Write("Yt: ");
            Show(ytoch);
            Console.Write("e(k): ");
            Show(Eps);
            Console.ReadLine();
        }
    }
}