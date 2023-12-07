using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TerminatorModel.DAL;
using TerminatorModel.DTO;

namespace TerminatorApp
{
    public partial class Program
    {
        static TerminatorDAL dalTerminator = new TerminatorDAL();

        static void IngresarTerminator()
        {
            string numeroSerie, objetivo;
            int prioridad, yearDestino;
            Tipo tipo = Tipo.T1;

            do
            {
                Console.WriteLine("Ingrese el numero de serie");
                numeroSerie = Console.ReadLine().Trim();
                if (numeroSerie.Length != 7)
                {
                    Console.WriteLine("El numero de serie debe se de largo 7");
                    numeroSerie = "";
                }
                else if (dalTerminator.FindByNumeroSerie(numeroSerie) != null)
                {
                    Console.WriteLine("El terminator ya existe");
                    numeroSerie = string.Empty;
                }
            } while (numeroSerie == string.Empty);

            tipo = GetTipo();

            do
            {
                Console.WriteLine("Ingrese objetivo:");
                objetivo = Console.ReadLine().Trim();
            } while (objetivo == string.Empty);

            if (objetivo.ToLower() == "sarah connor")
            {
                prioridad = 999;
            }
            else
            {
                do
                {
                    Console.WriteLine("Ingrese la prioridad:");
                    string prioridadText = Console.ReadLine().Trim();
                    if (!Int32.TryParse(prioridadText, out prioridad))
                    {
                        prioridad = -1;
                        Console.WriteLine("Prioridad incorrecta");
                    }
                } while (prioridad < 0 || prioridad > 999);
            }

            yearDestino = GetYearDestino();

            Terminator t = new Terminator() //Constructor.
            {
                NumeroSerie = numeroSerie,
                Objetivo = objetivo,
                YearDestino = yearDestino,
                Tipo = tipo,
                Prioridad = prioridad
            };

            dalTerminator.Save(t);
        }

        static void BuscarTerminators()
        {
            Tipo tipo = GetTipo();
            int yearDestino = GetYearDestino();

            List<Terminator> terminators = dalTerminator.FindByModeloAndYear(tipo, yearDestino);
            terminators.ForEach(Console.WriteLine);
        }

        static void MostrarTerminators()
        {
            List<Terminator> terminators = dalTerminator.GetAll();
            terminators.ForEach(t => Console.WriteLine(t));
        }

        static Boolean Menu()
        {
            bool continuar = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Bienvenido a Skynet");
            Console.WriteLine("1.Ingresar Terminator\n2.Mostrar Terminators\n3.Buscar Terminators" + "\n0.Salir");
            string opcion = Console.ReadLine().Trim();
            switch (opcion)
            {
                case "0":
                    continuar = false;
                    break;
                case "1":
                    IngresarTerminator();
                    break;
                case "2":
                    MostrarTerminators();
                    break;
                case "3":
                    BuscarTerminators();
                    break;
                default:
                    Console.WriteLine("Opción no valida");
                    break;
            }
            return continuar;
        }


        static void Main(string[] args)
        {
            while (Menu());
        }
    }
}
