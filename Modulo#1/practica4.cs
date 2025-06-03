using System;

class VerificadorPrimo
{
	static void Main()
	{
		Console.WriteLine("VERIFICADOR DE NÚMEROS PRIMOS");

		Console.Write("Ingrese un número entero positivo: ");
		int numero;

		// Validación de entrada para asegurar que sea un entero positivo
		while (!int.TryParse(Console.ReadLine(), out numero) || numero < 0)
		{
			Console.Write("Entrada inválida. Ingrese un número entero positivo: ");
		}

		if (EsPrimo(numero))
		{
			Console.WriteLine($"{numero} es un número primo.");
		}
		else
		{
			Console.WriteLine($"{numero} NO es un número primo.");
		}
	}

	static bool EsPrimo(int n)
	{
		if (n <= 1) return false;
		if (n == 2) return true;
		if (n % 2 == 0) return false;

		for (int i = 3; i <= Math.Sqrt(n); i += 2)
		{
			if (n % i == 0)
				return false;
		}

		return true;
	}
}
