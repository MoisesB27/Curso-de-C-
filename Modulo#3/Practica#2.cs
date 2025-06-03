using System;

class CalendarioMesActual
{
    static void Main()
    {
        DateTime hoy = DateTime.Today;
        DateTime primerDiaMes = new DateTime(hoy.Year, hoy.Month, 1);
        int diasEnMes = DateTime.DaysInMonth(hoy.Year, hoy.Month);

        Console.WriteLine($"\n{hoy.ToString("MMMM yyyy").ToUpper()}\n");
        Console.WriteLine("lu ma mi ju vi sá do");

    
        int diaSemana = (int)primerDiaMes.DayOfWeek;
        diaSemana = diaSemana == 0 ? 6 : diaSemana - 1; 

        for (int i = 0; i < diaSemana; i++)
            Console.Write("   ");

       
        for (int dia = 1; dia <= diasEnMes; dia++)
        {
            Console.Write($"{dia,2} ");

            if ((dia + diaSemana) % 7 == 0 || dia == diasEnMes)
                Console.WriteLine();
        }
    }
}