using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1

{
    internal class Program
    {
        static void Main(string[] args)

    {  
            Console.Write("Formula Cuadratica");

            Console.Write("Ingrese el coeficiente a: ");
        double a = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Ingrese el coeficiente b: ");
        double b = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Ingreses el coeficiente c: ");
        double c = Convert.ToDouble(Console.ReadLine());
        
        
        double discriminante = b * b - 4 * a * c;
        
        
        if (discriminante > 0)
        {
            double x1 = (-b + Math.Sqrt(discriminante)) / (2 * a);
            double x2 = (-b - Math.Sqrt(discriminante)) / (2 * a);
            Console.WriteLine($"Dos soluciones reales: x1 = {x1}, x2 = {x2}");
        }
        else if (discriminante == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine($"Una solución real: x = {x}");
        }
        else
        {
            double parteReal = -b / (2 * a);
            double parteImag = Math.Sqrt(-discriminante) / (2 * a);
            Console.WriteLine($"Soluciones complejas: x1 = {parteReal} + {parteImag}i, x2 = {parteReal} - {parteImag}i");

}

    }
        }

   
            }