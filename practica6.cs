using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Serie Fibonacci (1-50):");

            for (int a = 0, b = 1, c = 0; c <= 50; a = b, b = c, c = a + b)
            {
                if (c > 0) Console.WriteLine(c);
            }
        }
    }
}
