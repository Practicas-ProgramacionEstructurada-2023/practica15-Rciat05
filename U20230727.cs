using System;
using System.Diagnostics.Contracts;
using System.IO;

namespace MyApp// Note: actual namespace depends on the project name.
{
    internal class Program
    {
       class ConsultaMedica
       {
        public string? NombrePaciente {get; set; }

        public DateTime FechaCita {get; set;}

        public string? RazonConsulta {get; set;}

        public double CostoConsulta{get; set;}
       }

       static void Main(string[] args)
       {

        Console.Write("\n--------------------------Citas para clinica Dentista-----------------------");
        Console.Write("\nIngrese una cantidad de citas a crear: ");
        int cantidadCitas = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= cantidadCitas; i++)
        {
            ConsultaMedica consulta = new ConsultaMedica();

            Console.WriteLine($"Ingrese los datos para la primera cita {i}: ");
            Console.Write("Nombre del paciente: ");
            consulta.NombrePaciente = Console.ReadLine();

            Console.Write("Fecha de la primera cita (DD/MM/YY HH:MM): ");
            consulta.FechaCita = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Costo de la consulta: ");
            consulta.CostoConsulta = Convert.ToDouble(Console.ReadLine());

            //Crear el nombre del archivo según el formato especificado 
            string nombreArchivo = $"Cita{i:D3}";
            GuardarConsultaenArchivo(consulta, nombreArchivo);
        }

            static void GuardarConsultaenArchivo(ConsultaMedica consulta, string nombreArchivo)
            {
                //Agregar el número de iteración al nombre del archivo
                string nombreCompleto = $"{nombreArchivo}#{consulta.NombrePaciente}.txt";

                // Crear el contenido del archivo 
                string contenido = $"Nombre del paciente: {consulta.NombrePaciente}\n" +
                                        $"Fecha de cita: {consulta.FechaCita}\n" +
                                        $"Razón de Consulta: {consulta.RazonConsulta}\n" +
                                        $"Costo de Consulta: ${consulta.CostoConsulta}";

                //Guardar el contenido del archivo
                File.WriteAllText(nombreCompleto,contenido);

                Console.WriteLine($"\nCita guardada en el archivo: {nombreCompleto}");                       

            }

       }
    }
}