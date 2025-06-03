using System;

class CalculadoraChida
{
	static void Main()
	{
		Console.WriteLine(" ¡BIENVENIDO A LA CALCULADORA CHIDA! ");
		Console.WriteLine("(Hecha por ti, con un poco de ayuda de tu amigo código)\n");

		bool seguir = true;

		while (seguir)
		{
			Console.WriteLine("\nElige una opción:");
			Console.WriteLine("1️ Suma (+)");
			Console.WriteLine("2️ Resta (-)");
			Console.WriteLine("3️ Multiplicación (×)");
			Console.WriteLine("4️ División (÷)");
			Console.WriteLine("5️ Potencia (^)");
			Console.WriteLine("6️ Salir ()");
			Console.Write(" Tu opción: ");

			int opcion;
			if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 6)
			{
				Console.WriteLine(" ¡Ups! Opción inválida. Intenta del 1 al 6.");
				continue;
			}

			if (opcion == 6)
			{
				seguir = false;
				Console.WriteLine("\n ¡Adiós! Nos vemos en el próximo código. ");
				break;
			}

			Console.Write("Ingresa el primer número: ");
			double num1 = Convert.ToDouble(Console.ReadLine());
			Console.Write("Ingresa el segundo número: ");
			double num2 = Convert.ToDouble(Console.ReadLine());

			switch (opcion)
			{
				case 1:
					Console.WriteLine($"\n Resultado: {num1} + {num2} = {num1 + num2}");
					break;
				case 2:
					Console.WriteLine($"\n Resultado: {num1} - {num2} = {num1 - num2}");
					break;
				case 3:
					Console.WriteLine($"\n Resultado: {num1} × {num2} = {num1 * num2}");
					break;
				case 4:
					if (num2 == 0)
					{
						Console.WriteLine("\n ¡Error! No se puede dividir entre cero (a menos que quieras romper el universo).");
					}
					else
					{
						Console.WriteLine($"\n Resultado: {num1} ÷ {num2} = {num1 / num2}");
					}
					break;
				case 5:
					Console.WriteLine($"\n Resultado: {num1} ^ {num2} = {Math.Pow(num1, num2)}");
					break;
			}
		}
	}
}