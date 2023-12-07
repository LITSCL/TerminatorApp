using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminatorModel.DTO
{
    public enum Tipo
    {
        T1, T800, T1000, T3000
    }
    public class Terminator
    {
        private string numeroSerie;
        private int prioridad;
        private string objetivo;
        private int yearDestino;
        private Tipo tipo;

        public string NumeroSerie { get => numeroSerie; set => numeroSerie = value; }
        public int Prioridad { get => prioridad; set => prioridad = value; }
        public string Objetivo { get => objetivo; set => objetivo = value; }
        public int YearDestino { get => yearDestino; set => yearDestino = value; }
        public Tipo Tipo { get => tipo; set => tipo = value; }

        public override string ToString()
        {
            return numeroSerie + " " + tipo + " " + objetivo;
        }
    }
}
