using System;

namespace Operators
{

    class Program
    {
        static void Main(string[] args)
        {
            int[,] myMas = new int[5, 5] {
                                          {1, 2, 3, 4, 5},
                                          {5, 4, 3, 2, 1},
                                          {1, 3, 0, 5, 4}, 
                                          {5, 3, 4, 1, 2},
                                          {3, 1, 4, 5, 2 }
                                          }; 
            Matrix mas1 = new Matrix(myMas);
            Console.WriteLine(mas1);
            Console.WriteLine(mas1.Determinant());
            Console.WriteLine(mas1.Track());

           /* Комплексное число
           Complex One = new Complex(5.2, 6.35);
           Complex Two = new Complex(3, -13);
           Complex Three = new Complex(0, 2.5);
           Complex Four = One + Three;
           Console.WriteLine(One);         //5.2+6.35*i
           Console.WriteLine(Two);         //3-13*i
           Console.WriteLine(~Two);        //3.2+13*i
           Console.WriteLine(Three);       //2.5*i
           Console.WriteLine(Four);        //5.4+8.85*i
           Console.WriteLine(Complex.Abs(Two)); //корень от 178 = 13.34 ...
           */

            /* Дробь
            Fract a = new Fract(1, 2);
            Fract b = new Fract(10, 3);
            Fract c = a + b;
            Fract d = new Fract(100, 6);
            Console.WriteLine(a++);     // 1/2
            Console.WriteLine(a);       // 1+ 1/2
            Console.WriteLine(++a);     // 2+ 1/2
            Console.WriteLine(b);       // 3+ 1/3
            Console.WriteLine(c);       // 3+ 5/6
            Console.WriteLine(d);       // 16+ 4/6
            Console.WriteLine(d.Normalize()); // 16+ 2/3
            */

            Console.ReadKey();

        }


    }
}
