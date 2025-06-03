using System;

class DiaNacimiento
{
    static void Main()
    {
        Console.WriteLine("DIA DE LA SEMANA DE NACIMIENTO");

        while (true)
        {
            Console.Write("\nIngresa tu fecha (dd/mm/aaaa): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null,
                System.Globalization.DateTimeStyles.None, out DateTime fecha))
            {
                string[] dias = { "domingo", "lunes", "martes", "miércoles",
                                  "jueves", "viernes", "sábado" };
                Console.WriteLine($"Naciste un {dias[(int)fecha.DayOfWeek]}");
            }
            else
            {
                Console.WriteLine("Fecha inválida. Usa formato dd/mm/aaaa");
            }

            Console.Write("¿Otra fecha? (s/n): ");
            if (Console.ReadLine().ToLower() != "s") break;
        }
    }
}