using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingresa 10 números (presiona Enter después de cada uno):");

        int[] numeros = new int[10]; // Creamos un arreglo de 10 posiciones

        //  Leer los 10 números
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Número {i + 1}: ");
            numeros[i] = Convert.ToInt32(Console.ReadLine());
        }

        //  Ordenar el arreglo (usando Bubble Sort)
        for (int i = 0; i < numeros.Length - 1; i++)
        {
            for (int j = 0; j < numeros.Length - i - 1; j++)
            {
                if (numeros[j] > numeros[j + 1])
                {
                    // Intercambio los números si están en el orden incorrecto
                    int temp = numeros[j];
                    numeros[j] = numeros[j + 1];
                    numeros[j + 1] = temp;
                }
            }
        }

        // Muestro el arreglo ordenado
        Console.WriteLine("\n Números ordenados de menor a mayor:");
        foreach (int num in numeros)
        {
            Console.Write(num + " ");
        }

        Console.WriteLine("\n\n🎉 ¡Listo! ¿Quieres probar con otros números? (Ejecuta de nuevo)");
    }
}