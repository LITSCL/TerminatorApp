using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TerminatorModel.DTO;

namespace TerminatorApp
{
    partial class Program
    {
        public static Tipo GetTipo()
        {
            Tipo tipo = Tipo.T1;
            string respuesta;
            do
            {
                Console.WriteLine("Seleccione tipo");
                Console.WriteLine("1. T-1, 2. T-800, 3. T-1000, 4. T-3000");
                respuesta = Console.ReadLine().Trim();
                switch (respuesta)
                {
                    case "1":
                        tipo = Tipo.T1;
                        break;
                    case "2":
                        tipo = Tipo.T800;
                        break;
                    case "3":
                        tipo = Tipo.T1000;
                        break;
                    case "4":
                        tipo = Tipo.T3000;
                        break;
                    default:
                        Console.WriteLine("Tipo incorrecto, reingreselo");
                        respuesta = string.Empty;
                        break;
                }
            } while (respuesta == "");
            return tipo;
        }

        public static int GetYearDestino()
        {
            int yearDestino;
            do
            {
                Console.WriteLine("Ingrese año de destino:");
                if (!int.TryParse(Console.ReadLine().Trim(), out yearDestino))
                {
                    Console.WriteLine("El año de destino debe ser numerico");
                    yearDestino = -1;
                }
                else if (yearDestino < 1984 || yearDestino > 3000)
                {
                    Console.WriteLine("El año de destino esta fuera de los rangos permitidos");
                    yearDestino = -1;
                }
            } while (yearDestino < 1984 || yearDestino > 3000);
            return yearDestino;
        }
    }
}
