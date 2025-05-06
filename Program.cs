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
            Console.Write("Prograama divide dos numeros");

            try
            {
                
                Console.Write("Ingrese el primer número (dividendo): ");
                double dividendo = Convert.ToDouble(Console.ReadLine());

                
                Console.Write("Ingrese el segundo número (divisor): ");
                double divisor = Convert.ToDouble(Console.ReadLine());

               
                if (divisor == 0)
                
                {
                    Console.WriteLine("Error: No se puede dividir por cero.");
                }

                else
                {
                   
                    double resultado = dividendo / divisor;

                  
                    Console.WriteLine($"El resultado de {dividendo} ÷ {divisor} es: {resultado}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Por favor ingrese números válidos.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();

            ;        }
    }
}
