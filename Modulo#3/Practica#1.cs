using System;
using System.Linq;

class InicialesNombre
{
    static void Main()
    {
        Console.WriteLine("PROGRAMA DE INICIALES DE NOMBRE");
        Console.Write("\nIngresa tu nombre completo: ");

        string nombreCompleto = Console.ReadLine().Trim();

        if (string.IsNullOrWhiteSpace(nombreCompleto))
        {
            Console.WriteLine("No ingresaste ningún nombre");
            return;
        }

        char inicial = nombreCompleto[0];

        string[] palabras = nombreCompleto.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string iniciales = string.Join(" ", palabras.Select(p => p[0].ToString().ToUpper() + "."));

        Console.WriteLine($"\nNombre completo: {nombreCompleto}");
        Console.WriteLine($"Inicial: {char.ToUpper(inicial)}.");
        Console.WriteLine($"Iniciales de cada palabra: {iniciales}");
    }
}