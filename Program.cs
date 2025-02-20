using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static List<string> estudiantes = new List<string>();
    static List<double> calificaciones = new List<double>();

    static void Main()
    {
        Console.WriteLine("Bienvenido al sistema de gestión de estudiantes.");

        int opcion = 0;
        do
        {
            Console.WriteLine("\n1. Agregar estudiante");
            Console.WriteLine("2. Mostrar lista de estudiantes");
            Console.WriteLine("3. Calcular promedio de calificaciones");
            Console.WriteLine("4. Mostrar estudiante con la calificación más alta");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    aggestu();
                    break;
                case 2:
                    mlista();
                    break;
                case 3:
                    pmdio();
                    break;
                case 4:
                    clasialta();
                    break;
                case 5:
                    Console.WriteLine("Cierre de programa");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        } while (opcion != 5);
    }

    static void aggestu()
    {
        Console.Write("Ingrese el número de estudiantes que desea agregar: ");
        if (!int.TryParse(Console.ReadLine(), out int numestudiantes) || numestudiantes <= 0)
        {
            Console.WriteLine("Número inválido. Intente de nuevo.\n");
            return;
        }

        for (int a = 0; a < numestudiantes; a++)
        {
            Console.Write($"Ingrese el nombre del estudiante {a + 1}: ");
            string? nombre = Console.ReadLine();
            if (string.IsNullOrEmpty(nombre) || !Regex.IsMatch(nombre, @"^[a-zA-Z]+$")) // Expresión regular para solo letras
            {
                Console.WriteLine("Error: Solo se permiten letras. Intente de nuevo.\n");
                a--; // Para repetir la entrada de este estudiante
                continue;
            }

            Console.Write("Ingrese la calificación del estudiante: ");
            if (!double.TryParse(Console.ReadLine(), out double calificacion) || calificacion < 0 || calificacion > 100)
            {
                Console.WriteLine("Calificación inválida. Debe estar entre 0 y 100.\n");
                a--; // Para repetir la entrada de este estudiante
                continue;
            }

            estudiantes.Add(nombre);
            calificaciones.Add(calificacion);
        }
    }




    static void mlista()
    {
        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
            return;
        }

        Console.WriteLine("\nLista de estudiantes:");
        for (int i = 0; i < estudiantes.Count; i++)
        {
            Console.WriteLine($"{estudiantes[i]} - Calificación: {calificaciones[i]}");
        }
    }

    static void pmdio()
    {
        if (calificaciones.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
            return;
        }

        double suma = 0;
        foreach (double calificacion in calificaciones)
        {
            suma += calificacion;
        }

        double promedio = suma / calificaciones.Count;
        Console.WriteLine($"El promedio de calificaciones es: {promedio:F2}");
    }

    static void clasialta()
    {
        if (calificaciones.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
            return;
        }

        double maxCalificacion = calificaciones[0];
        string estudianteMax = estudiantes[0];

        for (int i = 1; i < calificaciones.Count; i++)
        {
            if (calificaciones[i] > maxCalificacion)
            {
                maxCalificacion = calificaciones[i];
                estudianteMax = estudiantes[i];
            }
        }

        Console.WriteLine($"El estudiante con la calificación más alta es: {estudianteMax} con {maxCalificacion}");
    }
}